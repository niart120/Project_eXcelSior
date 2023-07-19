using PokemonBDSPRNGLibrary.RestoreSeed;
using Project_eXcelSior.Misc;

namespace Project_eXcelSior.Forms
{
    public partial class MainWindow : Form
    {
        private enum BlinkObject
        {
            None,
            Single,
            Double,
            Pokemon,
        }
        private async void SyncAdvance((uint s0, uint s1, uint s2, uint s3) state, long nextPlayerBlinkTick, long nextPokemonBlinkTick = long.MaxValue)
        {
            //タイムラインを管理する優先度つきキューを準備する
            var timelineQueue = new PriorityQueue<BlinkObject, long>();
            timelineQueue.Enqueue(BlinkObject.None, nextPlayerBlinkTick);
            timelineQueue.Enqueue(BlinkObject.Pokemon, nextPokemonBlinkTick);

            var targetTick = 0L;
            var pt = OriginalTimer.PeridoricTimerAsync(cts.Token, FPS).GetAsyncEnumerator();
            while (await pt.MoveNextAsync())
            {
                var currentTick = pt.Current;
                //もし既にターゲット秒数を経過していた場合, 次の瞬き間隔を計算する
                if(currentTick>targetTick)
                {
                    //次のイベントタイミングを求める
                    timelineQueue.TryDequeue(out var blinkobj, out targetTick);
                    //消費タイプによって分岐
                    if (blinkobj == BlinkObject.Pokemon)
                    {
                        var nextTick = targetTick + (long)(state.BlinkPokemon() * 10_000_000);
                        timelineQueue.Enqueue(BlinkObject.Pokemon, nextTick);
                    }
                    else
                    {
                        BlinkObject bo = (BlinkObject)state.BlinkPlayer();
                        var nextTick = targetTick + (long)(BLINKCONST * 10_000_000);
                        timelineQueue.Enqueue(bo, nextTick);
                    }
                    
                    randEventType.Text = blinkobj.ToString();
                    //AdvanceとTarget Adv.のカウントダウンを更新する
                    currentAdvance.Value++;
                    targetAdvanceCountdown.Value = targetAdvance.Value - currentAdvance.Value;
                }
                //次の消費までのカウントダウンを更新
                intervalCountdown.Text = ((targetTick-currentTick)/10_000_000.0).ToString("F3");
            }
        }
    }
}
