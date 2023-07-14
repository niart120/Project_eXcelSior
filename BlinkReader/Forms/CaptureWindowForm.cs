namespace BlinkReader.Forms
{
    public partial class CaptureWindowForm : Form
    {
        public CaptureWindowForm()
        {
            InitializeComponent();

            this.Text = "キャプチャフレーム";
            this.TransparencyKey = Color.Red;
            this.pictureBox1.BackColor = Color.Red;
            this.TopMost = true;
        }

        public static int DisplayScale { get; set; } = 100;

        public Bitmap CaptureScreen()
        {
            var point = this.PointToScreen(pictureBox1.Location);
            var left = point.X;
            var top = point.Y;

            var height = pictureBox1.Size.Height;
            var width = pictureBox1.Size.Width;

            var screenRate = DisplayScale;

            var w = width * screenRate / 100;
            var h = height * screenRate / 100;
            var x = left * screenRate / 100;
            var y = top * screenRate / 100;

            using (var bmp = NativeMethods.CaptureScreen(x, y, h, w))
            {
                return new Bitmap(bmp, new Size(width, height));
            }
        }

        // フォームの破棄をキャンセルする.
        private void CaptureWindowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //this.Visible = false;
        }
    }
}
