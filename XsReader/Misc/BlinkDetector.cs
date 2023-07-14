using OpenCvSharp;
using OpenCvSharp.Extensions;
using BlinkReader;

namespace Project_eXcelSior.Misc
{
    internal class BlinkDetector : IDisposable, IDetector
    {
        private readonly Mat eye;
        internal double thresh{ get;set;}

        public BlinkDetector(double thresh = 0.8)
        {
            eye = new Mat(64, 64, MatType.CV_8UC3);
            this.thresh = thresh;
        }
        public BlinkDetector(string srcFilePath, double thresh = 0.8)
        {
            eye = new Mat(srcFilePath);
            this.thresh = thresh;
        }

        public bool Detect(Bitmap capturedPicture)
        {
            using (var tmp = BitmapConverter.ToMat(capturedPicture))
            using (var mat = tmp.CvtColor(ColorConversionCodes.BGRA2BGR))
            using (var res = new Mat())
            {
                Cv2.MatchTemplate(mat, eye, res, TemplateMatchModes.CCoeffNormed);
                Cv2.MinMaxLoc(res, out _, out double maxval);

                return maxval >= thresh;
            }
        }

        public void Dispose() => eye.Dispose();
    }
}
