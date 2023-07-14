using BlinkReader;
using Project_eXcelSior.Misc;

namespace Project_eXcelSior.Forms
{
    public partial class MainWindow : Form
    {
        private async void capturetestButton_Click(object sender, EventArgs e)
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
            if (capturetestImageName.Text == "")
            {
                return;
            }

            //そうでない場合はキャプチャテスト開始
            captureInProgress = true;
            setCaptureControlButtonsText("Cancel");
            setCaptureStatusLabels("InProgress", Color.SteelBlue);
            
            //キャンセルトークン生成
            cts = new CancellationTokenSource();

            var imagePath = GetEyeimageDirPath() + "/" + capturetestImageName.Text;
            using (detector = new BlinkDetector(imagePath, (double)detectorThreshold.Value))
            {
                var en = BlinkCapturerer.CaptureBlinkTestAsync(cts.Token, detector, captureWindowForm, FPS).GetAsyncEnumerator();
                while (await en.MoveNextAsync())
                {
                    //画像検知成功=>目が開いている
                    if (en.Current == true)
                    {
                        this.blinkIndicator.Text = "(´・ω・`)";
                    }
                    //画像検知失敗=>目が閉じている
                    else
                    {
                        this.blinkIndicator.Text = "(´-ω-`)";
                    }
                }
            }
        }
    }
}
