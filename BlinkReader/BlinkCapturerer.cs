using BlinkReader.Forms;
using System.Runtime.CompilerServices;

namespace BlinkReader
{
    public class BlinkCapturerer
    {
        public static async IAsyncEnumerable<long> CaptureBlinkAsync([EnumeratorCancellation] CancellationToken token, IDetector detector, CaptureWindowForm windowForm, double fps = 60.0)
        {
            NativeMethods.Winmm.timeBeginPeriod(1);
            long TPF = (long)(10_000_000 / fps);//Ticks Per Frame
            var isBlinked = true;
            var nextFrame = DateTime.Now.Ticks;

            while (!token.IsCancellationRequested)
            {
                //最低1msはビジーウェイトさせるようにする
                await Task.Delay((int)(1000/fps) - 1);
                var currentTick = DateTime.Now.Ticks;
                while (currentTick < nextFrame) currentTick = DateTime.Now.Ticks;
                nextFrame += TPF;

                var bmp = windowForm.CaptureScreen();
                var isBlinking = !detector.Detect(bmp);
                if (isBlinking && !isBlinked)
                {
                    yield return currentTick;
                }
                isBlinked = isBlinking;
                bmp.Dispose();
            }
        }

        public static async IAsyncEnumerable<bool> CaptureBlinkTestAsync([EnumeratorCancellation] CancellationToken token, IDetector detector, CaptureWindowForm windowForm, double fps = 60.0)
        {
            NativeMethods.Winmm.timeBeginPeriod(1);
            long TPF = (long)(10_000_000 / fps);//Ticks Per Frame
            var nextFrame = DateTime.Now.Ticks;

            while (!token.IsCancellationRequested)
            {
                await Task.Delay((int)(1000 / fps));
                var currentTick = DateTime.Now.Ticks;
                while (currentTick < nextFrame) currentTick = DateTime.Now.Ticks;
                nextFrame += TPF;

                var bmp = windowForm.CaptureScreen();
                yield return detector.Detect(bmp);
                bmp.Dispose();
            }
        }
    }
    public interface IDetector
    {
        public bool Detect(Bitmap capturedPicture);
    }
}
