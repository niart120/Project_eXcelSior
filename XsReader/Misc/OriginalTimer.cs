using System.Runtime.CompilerServices;

namespace Project_eXcelSior.Misc
{
    internal class OriginalTimer
    {
        public static async IAsyncEnumerable<long> PeridoricTimerAsync([EnumeratorCancellation] CancellationToken token, double fps = 60.0)
        {
            long TPF = (long)(10_000_000 / fps);//Ticks Per Frame
            var nextFrame = DateTime.Now.Ticks;

            while (!token.IsCancellationRequested)
            {
                //最低1msはビジーウェイトさせるようにする
                await Task.Delay((int)(1000 / fps) - 1);
                var currentTick = DateTime.Now.Ticks;
                while (currentTick < nextFrame) currentTick = DateTime.Now.Ticks;
                nextFrame += TPF;
                yield return currentTick;
            }
        }
    }
}
