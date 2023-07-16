using BlinkReader;
using PokemonBDSPRNGLibrary.RestoreSeed;
using PokemonPRNG.XorShift128;
using Project_eXcelSior.Misc;
using MathNet.Numerics.LinearRegression;

namespace Project_eXcelSior.Forms
{
    public partial class MainWindow : Form
    {
        private async void reidentifyButton_Click(object sender, EventArgs e)
        {
            //もし既に任意キャプチャが走っている場合はキャンセルする
            if (captureInProgress)
            {
                cts.Cancel();
                setCaptureControlButtonsText("Start");
                setCaptureStatusLabels("Standby", Color.Gray);
                captureInProgress = false;
                return;
            }
            //もし瞬き画像が指定されていない場合は何もしない
            if (reidentifyImageName.Text == "")
            {
                return;
            }

            //そうでない場合はAdv開始
            captureInProgress = true;
            setCaptureControlButtonsText("Cancel");
            setCaptureStatusLabels("InProgress", Color.SteelBlue);

            //キャンセルトークン生成
            cts = new CancellationTokenSource();
            //エントロピーの値をリセット
            this.identifyEntropy.Value = 0;
            //テーブルをリセット
            this.dataGridView1.Rows.Clear();

            var searcher = new PlayerLinearSearch();
            var imagePath = GetEyeimageDirPath() + "/" + reidentifyImageName.Text;
            using (detector = new BlinkDetector(imagePath, (double)detectorThreshold.Value))
            {
                var en = BlinkCapturerer.CaptureBlinkAsync(cts.Token, detector, captureWindowForm, FPS).GetAsyncEnumerator();

                uint idx = default;
                double nextPokeBlink = 0;
                long nextPokeBlinkTick = long.MaxValue;
                (uint, uint, uint, uint) restored = default;

                int count = 0;
                long prev = 0;
                long current = 0;

                //瞬きタイミングを線形回帰でフィッティングするための準備
                var X = new List<long>();
                var Y = new List<long>();

                //SingleかDoubleかを判別する必要はない
                //観測した瞬きを用いて即座に特定を行う.
                while (await en.MoveNextAsync())
                {
                    current = en.Current;
                    //初回のみprevとfirstblinkを更新してループに戻る
                    if (prev == 0)
                    {
                        dataGridView1.Rows.Add(count++, "-", "*");
                        prev = current;
                        //回帰用のリストにも詰める
                        X.Add(0);
                        Y.Add(current);
                        continue;
                    }
                    var intvl = (current - prev) / 10_000_000.0 / BLINKCONST;
                    //二回瞬きの場合はblinktypeを上書きしてループに戻る
                    if (intvl < 0.6)
                    {
                        dataGridView1.Rows[^1].Cells[^1].Value += "*";
                        continue;
                    }
                    //四捨五入して瞬き間隔を計算
                    var interval = (uint)(intvl + 0.5);
                    searcher.AddInterval(interval);
                    dataGridView1.Rows.Add(count++, interval, "*");
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

                    //回帰用のリストにも詰めておく
                    X.Add(X.Last() + interval);
                    Y.Add(current);
                    prev = current;

                    //最低観測回数に達していないならループ継続
                    if (count <= minBlinkCount.Value) continue;

                    //最低観測回数に達していれば再特定開始
                    //textboxのBaseSeedからstateを取得
                    var x0 = Convert.ToUInt64(seed0.Text, 16);
                    var x1 = Convert.ToUInt64(seed1.Text, 16);
                    var state = ((uint)(x0 >> 32), (uint)(x0 & 0xFFFFFFFF), (uint)(x1 >> 32), (uint)(x1 & 0xFFFFFFFF));
                    for (var i = 0; i < searchMin.Value; i++) state.Advance();
                    var searchRange = (uint)(searchMax.Value - searchMin.Value);

                    if (isInNoisy.Checked)
                    {
                        //ノイズを考慮する場合
                        var results = searcher.SearchInNoisy(state, searchRange).ToList();
                        //1個以上見つかった場合は同期フェーズに移行(複数候補が見つかりうる)
                        if (results.Count > 1)
                        {
                            (idx, var first, restored) = results.First();
                            //中央値を取るための細工をする
                            (_,var last, _) = results.Where(r=>r.state == restored).Last();
                            nextPokeBlink = (first + last) / 2;
                            idx += (uint)searchMin.Value;
                            break;
                        }
                        //一個も見つからなかった場合は特定失敗として打ち切り
                        else if (results.Count == 0)
                        {
                            cts.Cancel();
                            cts.Dispose();
                            cts = new CancellationTokenSource();
                            setCaptureControlButtonsText("Start");
                            setCaptureStatusLabels("Failure...", Color.OrangeRed);
                            captureInProgress = false;
                            return;
                        }
                        //それ以外はループ継続
                    }
                    else
                    {
                        //ノイズを考慮しない場合
                        var results = searcher.Search(state, searchRange).ToList();
                        //ちょうど1個見つかった場合は同期フェーズに移行
                        if (results.Count == 1)
                        {
                            (idx, restored) = results[0];
                            idx += (uint)searchMin.Value;
                            break;
                        }
                        //一個も見つからなかった場合は特定失敗として打ち切り
                        else if (results.Count == 0)
                        {
                            cts.Cancel();
                            cts.Dispose();
                            cts = new CancellationTokenSource();
                            setCaptureControlButtonsText("Start");
                            setCaptureStatusLabels("Failure...", Color.OrangeRed);
                            captureInProgress = false;
                            return;
                        }
                        //それ以外はループ継続
                    }
                }
                //もしキャンセルリクエストが来ていた場合はここで終了
                if (cts.IsCancellationRequested)
                {
                    cts = new CancellationTokenSource();
                    return;
                }
                setCaptureStatusLabels("Success!!", Color.OliveDrab);
                
                //Advanceの更新
                currentAdvance.Value = idx;
                //検索範囲の下限もついでに更新
                searchMin.Value = idx;

                //瞬きタイミングの推定
                (var intercept, var slope) = SimpleRegression.Fit(X.Select(_=>(double)_).ToArray(),Y.Select(_ => (double)_).ToArray());
                var estimatedCurrent = (long)(X[^1] * slope + intercept);
                var nextPlayerBlinkTick = estimatedCurrent + (long)(BLINKCONST * 10_000_000);
                if(isInNoisy.Checked) nextPokeBlinkTick = estimatedCurrent + (long)(nextPokeBlink * 10_000_000);
                //同期開始
                SyncAdvance(restored, nextPlayerBlinkTick, nextPokeBlinkTick);
            }
        }

        private void reidentifyImageName_Click(object sender, EventArgs e)
        {
            loadImageNames();
        }
    }
}
