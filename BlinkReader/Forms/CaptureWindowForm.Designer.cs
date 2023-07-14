namespace BlinkReader.Forms
{
    partial class CaptureWindowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Location = new Point(6, 8);
            pictureBox1.Margin = new Padding(6, 8, 6, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(43, 40);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // CaptureWindowForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(56, 56);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(6, 8, 6, 8);
            MaximizeBox = false;
            MaximumSize = new Size(951, 964);
            MinimizeBox = false;
            MinimumSize = new Size(82, 127);
            Name = "CaptureWindowForm";
            ShowIcon = false;
            Text = "キャプチャフレーム";
            TopMost = true;
            FormClosing += CaptureWindowForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}