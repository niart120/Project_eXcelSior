using BlinkReader.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Project_eXcelSior.Misc;
using System.Runtime.Intrinsics.Arm;

namespace Project_eXcelSior.Forms
{
    public partial class MainWindow : Form
    {
        private double FPS = 60.0;
        private const double BLINKCONST = 61.0 / 60.0;
        private const string IMGDIRNAME = "/eyeimage";

        CaptureWindowForm captureWindowForm = new CaptureWindowForm();
        CancellationTokenSource cts = new CancellationTokenSource();
        BlinkDetector detector;
        private bool captureInProgress = false;

        public MainWindow()
        {
            InitializeComponent();
            //�u���摜�p�f�B���N�g���쐬
            DirectoryUtils.SafeCreateDirectory(GetEyeimageDirPath());

            //�u���摜�̊i�[�f�B���N�g���ǂݍ���
            loadImageNames();
            identifyImageName.SelectedIndex = 0;
            reidentifyImageName.SelectedIndex = 0;
            capturetestImageName.SelectedIndex = 0;

            //�ݒ�ǂݍ���
            LoadFromSetting();

            detector = new BlinkDetector();
            captureWindowForm.Visible = true;
            captureWindowForm.TopMost = true;
        }

        private string GetEyeimageDirPath()
        {
            var appFilePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            return appFilePath + IMGDIRNAME;
        }

        private void loadImageNames()
        {
            var filenames = DirectoryUtils.GetFileNames(GetEyeimageDirPath(), new[] { ".png", ".jpeg", ".jpg", ".gif", ".bmp" });
            identifyImageName.Items.Clear();
            identifyImageName.Items.AddRange(filenames);
            reidentifyImageName.Items.Clear();
            reidentifyImageName.Items.AddRange(filenames);
            capturetestImageName.Items.Clear();
            capturetestImageName.Items.AddRange(filenames);
        }

        private void setCaptureControlButtonsText(string text)
        {
            this.identifyButton.Text = text;
            this.reidentifyButton.Text = text;
            this.capturetestButton.Text = text;
            return;
        }

        private void setCaptureStatusLabels(string text, Color color)
        {
            this.identifyStatus.Text = text;
            this.reidentifyStatus.Text = text;

            this.identifyStatus.ForeColor = color;
            this.reidentifyStatus.ForeColor = color;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //�L���v�`���E�B���h�E�������Ă���ꍇ�͔�\���ɂ���
            if (captureWindowForm.Visible)
            {
                captureWindowForm.Visible = false;
                this.toolStripMenuItem1.Text = "�L���v�`���g�\��";
            }
            //��\���̏ꍇ�͍ĕ\��
            else
            {
                captureWindowForm.Visible = true;
                this.toolStripMenuItem1.Text = "�L���v�`���g��\��";
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //���݂̃L���v�`���g���̉摜���B�e
            using (var rawimg = captureWindowForm.CaptureScreen())
            using (var img = BitmapConverter.ToMat(rawimg).CvtColor(ColorConversionCodes.BGRA2BGR))
            {
                var imgname = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                var imgpath = GetEyeimageDirPath() + "/" + imgname;
                Cv2.ImWrite(imgpath, img);
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            loadImageNames();
        }

        private void detectorThreshold_ValueChanged(object sender, EventArgs e)
        {
            detector.thresh = (double)detectorThreshold.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.FPS = (double)numericUpDown1.Value;
        }
        private Setting GetSetting()
        {
            var cfg = new Setting(this.seed0.Text, this.seed1.Text, this.targetAdvance.Value, this.numericUpDown1.Value);
            return cfg;
        }

        private void SaveToSetting()
        {
            Setting.WriteConfig(GetSetting());
        }

        private void LoadFromSetting()
        {
            var cfg = Setting.ReadConfig();
            if (cfg == null)
            {
                return;
            }

            this.seed0.Text = cfg.seed0;
            this.seed1.Text = cfg.seed1;
            this.targetAdvance.Value = cfg.targetAdvance;
            this.numericUpDown1.Value = cfg.fps;

        }

        private void MainWindow_FormClosing(object? sender, FormClosingEventArgs e)
        {
            SaveToSetting();
        }
    }
}