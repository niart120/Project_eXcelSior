using System.Runtime.InteropServices;

namespace BlinkReader
{
    static class NativeMethods
    {

        private const int SRCCOPY = 0xCC0020;
        private const int CAPTUREBLT = 1073741824;

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);
        internal class Winmm
        {
            [DllImport("Winmm.dll")]
             internal static extern uint timeBeginPeriod(uint uuPeriod);
        }

        public static Bitmap CaptureScreen(int x, int y, int height, int width)
        {
            var disDC = GetDC(IntPtr.Zero);
            var bmp = new Bitmap(width, height);
            var g = Graphics.FromImage(bmp);
            var hDC = g.GetHdc();

            //Bitmapに画像をコピーする
            BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, disDC, x, y, SRCCOPY);

            //解放
            g.ReleaseHdc(hDC);
            g.Dispose();
            ReleaseDC(IntPtr.Zero, disDC);

            return bmp;
        }
    }
}
