using BlinkReader;
using Project_eXcelSior.Misc;
using PokemonBDSPRNGLibrary.RestoreSeed;
using PokemonPRNG.XorShift128;

namespace Project_eXcelSior.Forms
{
    public partial class MainWindow : Form
    {
        private async void identifyButton_Click(object sender, EventArgs e)
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
            if (identifyImageName.Text == "")
            {
                return;
            }

            //そうでない場合はSeed特定開始
            captureInProgress = true;
            setCaptureControlButtonsText("Cancel");
            setCaptureStatusLabels("InProgress", Color.SteelBlue);

            //キャンセルトークン生成
            cts = new CancellationTokenSource();
            //エントロピーの値をリセット
            this.identifyEntropy.Value = 0;
            //テーブルをリセット
            this.dataGridView1.Rows.Clear();

            var inverter = new PlayerBlinkInverter();
            var imagePath = GetEyeimageDirPath() + "/" + identifyImageName.Text;
            using (detector = new BlinkDetector(imagePath, (double)detectorThreshold.Value))
            {
                var en = BlinkCapturerer.CaptureBlinkAsync(cts.Token, detector, captureWindowForm, FPS).GetAsyncEnumerator();
                
                (uint, uint, uint, uint) restored = default;

                int count = 0;
                long prev = 0;
                long current = 0;
                long firstblink = 0;
                var prevBlinkType = PlayerBlink.Single;

                //特定結果検証用に間隔を記録しておく
                var intervals = new List<int>();
                //最初に観測した段階では, 次の瞬きが来るまでSingleかDoubleかを判別することは出来ない.
                //観測した瞬きを用いて即座に判定を行うのではなく, 前回までの観測結果を元にSeed特定を行う.
                while (await en.MoveNextAsync())
                {
                    current = en.Current;
                    //初回のみprevとfirstblinkを更新してループに戻る
                    if (prev == 0)
                    {
                        dataGridView1.Rows.Add(count++, "-", "*");
                        prev = current;
                        firstblink = current;
                        continue;
                    }
                    var intvl = (current - prev) / 10_000_000.0 / BLINKCONST;
                    //二回瞬きの場合はblinktypeを上書きしてループに戻る
                    if (intvl < 0.6)
                    {
                        prevBlinkType = PlayerBlink.Double;
                        dataGridView1.Rows[^1].Cells[^1].Value += "*";
                        continue;
                    }
                    //いずれにも該当しないので前回までの観測結果を入れる
                    inverter.AddBlink(prevBlinkType);
                    //エントロピーの値を更新
                    this.identifyEntropy.Value = inverter.Entropy;
                    //復元を試みる
                    if (inverter.TryRestoreState(out restored)) break;

                    //失敗した場合は今回の瞬き間隔分だけ瞬き無し(None)をいれる
                    //四捨五入して瞬き間隔を計算
                    var interval = (int)(intvl + 0.5);
                    //検証リストへの追加
                    intervals.Add(interval);
                    //interval-1だけNoneを追加
                    for( var i = 0; i < interval - 1; i++)
                    {
                        inverter.AddBlink(PlayerBlink.None);
                    }
                    dataGridView1.Rows.Add(count++, interval, "*");
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                    //
                    prev = current;
                    prevBlinkType = PlayerBlink.Single;

                    //もし観測回数が50回を超える(エントロピーが200より大きい)場合は強制打ち切り
                    if (inverter.Entropy > 200)
                    {
                        cts.Cancel();
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                        setCaptureControlButtonsText("Start");
                        setCaptureStatusLabels("Failure...", Color.OrangeRed);
                        captureInProgress = false;
                        return;
                    }
                }
                //もしキャンセルリクエストが来ていた場合はここで終了
                if (cts.IsCancellationRequested)
                {
                    cts = new CancellationTokenSource();
                    return;
                }

                //特定結果の検証
                var pls = new PlayerLinearSearch();
                foreach(var i in intervals) pls.AddInterval((uint)i);

                var elapsed = (uint)intervals.Sum();
                (var _, var baseseed) = pls.Search(restored, elapsed + 1).FirstOrDefault();
                //もし検索範囲内に該当するsequenceがないなら特定失敗と見做す
                if (baseseed==default)
                {
                    cts.Cancel();
                    cts.Dispose();
                    cts = new CancellationTokenSource();
                    setCaptureControlButtonsText("Start");
                    setCaptureStatusLabels("Failure...", Color.OrangeRed);
                    captureInProgress = false;
                    return;
                }
                //GUIの更新
                currentAdvance.Value = 0;
                var fullhex = baseseed.ToU128String();
                var x0 = fullhex[0..16];
                var x1 = fullhex[16..32];

                this.seed0.Text = x0;
                this.seed1.Text = x1;

                setCaptureStatusLabels("Success!!", Color.OliveDrab);
                var nextPlayerBlinkTick = current + (long)(BLINKCONST * 10_000_000);
                SyncAdvance(baseseed, nextPlayerBlinkTick);
            }
        }

        private void identifyImageName_Click(object sender, EventArgs e)
        {
            loadImageNames();
        }
    }
}
