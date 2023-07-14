namespace Project_eXcelSior.Forms
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            seed1 = new TextBox();
            label2 = new Label();
            seed0 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            IndexColumn = new DataGridViewTextBoxColumn();
            IntervalColumn = new DataGridViewTextBoxColumn();
            BlinkTypeColumn = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            pictureBox3 = new PictureBox();
            identifyStatus = new Label();
            identifyEntropy = new NumericUpDown();
            label23 = new Label();
            identifyImageName = new ComboBox();
            label22 = new Label();
            identifyButton = new Button();
            tabPage2 = new TabPage();
            pictureBox2 = new PictureBox();
            reidentifyStatus = new Label();
            reidentifyImageName = new ComboBox();
            label21 = new Label();
            isInNoisy = new CheckBox();
            minBlinkCount = new NumericUpDown();
            label14 = new Label();
            label13 = new Label();
            searchMax = new NumericUpDown();
            searchMin = new NumericUpDown();
            label12 = new Label();
            reidentifyButton = new Button();
            tabPage3 = new TabPage();
            numericUpDown1 = new NumericUpDown();
            groupBox4 = new GroupBox();
            pictureBox1 = new PictureBox();
            capturetestImageName = new ComboBox();
            label15 = new Label();
            blinkIndicator = new Label();
            label19 = new Label();
            capturetestButton = new Button();
            detectorThreshold = new NumericUpDown();
            label17 = new Label();
            label16 = new Label();
            groupBox2 = new GroupBox();
            targetAdvanceCountdown = new NumericUpDown();
            currentAdvance = new NumericUpDown();
            label8 = new Label();
            label10 = new Label();
            randEventType = new Label();
            label6 = new Label();
            intervalCountdown = new Label();
            label3 = new Label();
            groupBox3 = new GroupBox();
            targetAdvance = new NumericUpDown();
            label11 = new Label();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)identifyEntropy).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minBlinkCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchMin).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detectorThreshold).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)targetAdvanceCountdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currentAdvance).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)targetAdvance).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.MenuBar;
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(974, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.ForeColor = SystemColors.ActiveCaptionText;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(214, 36);
            toolStripMenuItem1.Text = "キャプチャ枠非表示";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(130, 36);
            toolStripMenuItem2.Text = "画像撮影";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(100, 36);
            toolStripMenuItem3.Text = "リロード";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(seed1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(seed0);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(677, 84);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "BaseSeed";
            // 
            // seed1
            // 
            seed1.BackColor = SystemColors.ControlLightLight;
            seed1.CharacterCasing = CharacterCasing.Upper;
            seed1.Location = new Point(410, 34);
            seed1.Name = "seed1";
            seed1.ReadOnly = true;
            seed1.Size = new Size(236, 39);
            seed1.TabIndex = 3;
            seed1.TabStop = false;
            seed1.Text = "0";
            seed1.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, 37);
            label2.Name = "label2";
            label2.Size = new Size(77, 32);
            label2.TabIndex = 2;
            label2.Text = "seed1";
            // 
            // seed0
            // 
            seed0.BackColor = SystemColors.ControlLightLight;
            seed0.CharacterCasing = CharacterCasing.Upper;
            seed0.Location = new Point(84, 34);
            seed0.Name = "seed0";
            seed0.ReadOnly = true;
            seed0.Size = new Size(236, 39);
            seed0.TabIndex = 1;
            seed0.TabStop = false;
            seed0.Text = "0";
            seed0.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 37);
            label1.Name = "label1";
            label1.Size = new Size(77, 32);
            label1.TabIndex = 0;
            label1.Text = "seed0";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IndexColumn, IntervalColumn, BlinkTypeColumn });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(12, 153);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 52;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(316, 464);
            dataGridView1.TabIndex = 2;
            dataGridView1.TabStop = false;
            // 
            // IndexColumn
            // 
            IndexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            IndexColumn.HeaderText = "#";
            IndexColumn.MinimumWidth = 10;
            IndexColumn.Name = "IndexColumn";
            IndexColumn.ReadOnly = true;
            IndexColumn.Width = 40;
            // 
            // IntervalColumn
            // 
            IntervalColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            IntervalColumn.HeaderText = "Interval";
            IntervalColumn.MinimumWidth = 10;
            IntervalColumn.Name = "IntervalColumn";
            IntervalColumn.ReadOnly = true;
            IntervalColumn.Width = 120;
            // 
            // BlinkTypeColumn
            // 
            BlinkTypeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            BlinkTypeColumn.HeaderText = "BlinkType";
            BlinkTypeColumn.MinimumWidth = 10;
            BlinkTypeColumn.Name = "BlinkTypeColumn";
            BlinkTypeColumn.ReadOnly = true;
            BlinkTypeColumn.Width = 120;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(326, 153);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(371, 464);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pictureBox3);
            tabPage1.Controls.Add(identifyStatus);
            tabPage1.Controls.Add(identifyEntropy);
            tabPage1.Controls.Add(label23);
            tabPage1.Controls.Add(identifyImageName);
            tabPage1.Controls.Add(label22);
            tabPage1.Controls.Add(identifyButton);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(355, 410);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Seed特定";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(166, 141);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(64, 64);
            pictureBox3.TabIndex = 36;
            pictureBox3.TabStop = false;
            // 
            // identifyStatus
            // 
            identifyStatus.AutoSize = true;
            identifyStatus.ForeColor = Color.Gray;
            identifyStatus.Location = new Point(25, 352);
            identifyStatus.Name = "identifyStatus";
            identifyStatus.Size = new Size(101, 32);
            identifyStatus.TabIndex = 35;
            identifyStatus.Text = "Standby";
            // 
            // identifyEntropy
            // 
            identifyEntropy.Location = new Point(11, 58);
            identifyEntropy.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            identifyEntropy.Name = "identifyEntropy";
            identifyEntropy.ReadOnly = true;
            identifyEntropy.Size = new Size(135, 39);
            identifyEntropy.TabIndex = 34;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(6, 19);
            label23.Name = "label23";
            label23.Size = new Size(116, 32);
            label23.TabIndex = 33;
            label23.Text = "エントロピー";
            // 
            // identifyImageName
            // 
            identifyImageName.DropDownStyle = ComboBoxStyle.DropDownList;
            identifyImageName.FormattingEnabled = true;
            identifyImageName.Location = new Point(11, 211);
            identifyImageName.Name = "identifyImageName";
            identifyImageName.Size = new Size(295, 40);
            identifyImageName.TabIndex = 31;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(6, 171);
            label22.Name = "label22";
            label22.Size = new Size(104, 32);
            label22.TabIndex = 30;
            label22.Text = "瞬き画像";
            // 
            // identifyButton
            // 
            identifyButton.Location = new Point(188, 343);
            identifyButton.Name = "identifyButton";
            identifyButton.Size = new Size(150, 46);
            identifyButton.TabIndex = 0;
            identifyButton.Text = "Start";
            identifyButton.UseVisualStyleBackColor = true;
            identifyButton.Click += identifyButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pictureBox2);
            tabPage2.Controls.Add(reidentifyStatus);
            tabPage2.Controls.Add(reidentifyImageName);
            tabPage2.Controls.Add(label21);
            tabPage2.Controls.Add(isInNoisy);
            tabPage2.Controls.Add(minBlinkCount);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(searchMax);
            tabPage2.Controls.Add(searchMin);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(reidentifyButton);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(355, 410);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Adv.再特定";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(166, 227);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.TabIndex = 37;
            pictureBox2.TabStop = false;
            // 
            // reidentifyStatus
            // 
            reidentifyStatus.AutoSize = true;
            reidentifyStatus.ForeColor = Color.Gray;
            reidentifyStatus.Location = new Point(25, 352);
            reidentifyStatus.Name = "reidentifyStatus";
            reidentifyStatus.Size = new Size(101, 32);
            reidentifyStatus.TabIndex = 36;
            reidentifyStatus.Text = "Standby";
            // 
            // reidentifyImageName
            // 
            reidentifyImageName.DropDownStyle = ComboBoxStyle.DropDownList;
            reidentifyImageName.FormattingEnabled = true;
            reidentifyImageName.Location = new Point(11, 297);
            reidentifyImageName.Name = "reidentifyImageName";
            reidentifyImageName.Size = new Size(295, 40);
            reidentifyImageName.TabIndex = 28;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(6, 250);
            label21.Name = "label21";
            label21.Size = new Size(104, 32);
            label21.TabIndex = 27;
            label21.Text = "瞬き画像";
            // 
            // isInNoisy
            // 
            isInNoisy.AutoSize = true;
            isInNoisy.Location = new Point(188, 166);
            isInNoisy.Name = "isInNoisy";
            isInNoisy.Size = new Size(126, 36);
            isInNoisy.TabIndex = 11;
            isInNoisy.Text = "InNoisy";
            isInNoisy.UseVisualStyleBackColor = true;
            // 
            // minBlinkCount
            // 
            minBlinkCount.Location = new Point(11, 163);
            minBlinkCount.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            minBlinkCount.Name = "minBlinkCount";
            minBlinkCount.Size = new Size(135, 39);
            minBlinkCount.TabIndex = 7;
            minBlinkCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 123);
            label14.Name = "label14";
            label14.Size = new Size(158, 32);
            label14.TabIndex = 6;
            label14.Text = "最低観測回数";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(148, 62);
            label13.Name = "label13";
            label13.Size = new Size(38, 32);
            label13.TabIndex = 5;
            label13.Text = "～";
            // 
            // searchMax
            // 
            searchMax.Location = new Point(188, 58);
            searchMax.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            searchMax.Name = "searchMax";
            searchMax.Size = new Size(135, 39);
            searchMax.TabIndex = 4;
            searchMax.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // searchMin
            // 
            searchMin.Location = new Point(11, 58);
            searchMin.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            searchMin.Name = "searchMin";
            searchMin.Size = new Size(135, 39);
            searchMin.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 19);
            label12.Name = "label12";
            label12.Size = new Size(110, 32);
            label12.TabIndex = 2;
            label12.Text = "検索範囲";
            // 
            // reidentifyButton
            // 
            reidentifyButton.Location = new Point(188, 343);
            reidentifyButton.Name = "reidentifyButton";
            reidentifyButton.Size = new Size(150, 46);
            reidentifyButton.TabIndex = 1;
            reidentifyButton.Text = "Start";
            reidentifyButton.UseVisualStyleBackColor = true;
            reidentifyButton.Click += reidentifyButton_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(numericUpDown1);
            tabPage3.Controls.Add(groupBox4);
            tabPage3.Controls.Add(detectorThreshold);
            tabPage3.Controls.Add(label17);
            tabPage3.Controls.Add(label16);
            tabPage3.Location = new Point(8, 46);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(355, 410);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "設定";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Increment = new decimal(new int[] { 30, 0, 0, 0 });
            numericUpDown1.Location = new Point(11, 58);
            numericUpDown1.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 30, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(99, 39);
            numericUpDown1.TabIndex = 20;
            numericUpDown1.Value = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pictureBox1);
            groupBox4.Controls.Add(capturetestImageName);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(blinkIndicator);
            groupBox4.Controls.Add(label19);
            groupBox4.Controls.Add(capturetestButton);
            groupBox4.Location = new Point(6, 115);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(345, 292);
            groupBox4.TabIndex = 19;
            groupBox4.TabStop = false;
            groupBox4.Text = "キャプチャテスト";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(160, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // capturetestImageName
            // 
            capturetestImageName.DropDownStyle = ComboBoxStyle.DropDownList;
            capturetestImageName.FormattingEnabled = true;
            capturetestImageName.Location = new Point(5, 96);
            capturetestImageName.Name = "capturetestImageName";
            capturetestImageName.Size = new Size(295, 40);
            capturetestImageName.TabIndex = 25;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(0, 56);
            label15.Name = "label15";
            label15.Size = new Size(104, 32);
            label15.TabIndex = 24;
            label15.Text = "瞬き画像";
            // 
            // blinkIndicator
            // 
            blinkIndicator.AutoSize = true;
            blinkIndicator.BackColor = Color.White;
            blinkIndicator.BorderStyle = BorderStyle.FixedSingle;
            blinkIndicator.Font = new Font("Arial Narrow", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            blinkIndicator.Location = new Point(20, 191);
            blinkIndicator.Name = "blinkIndicator";
            blinkIndicator.Size = new Size(89, 33);
            blinkIndicator.TabIndex = 23;
            blinkIndicator.Text = "(´・ω・`)";
            blinkIndicator.TextAlign = ContentAlignment.TopCenter;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(1, 152);
            label19.Name = "label19";
            label19.Size = new Size(56, 32);
            label19.TabIndex = 22;
            label19.Text = "瞬き";
            // 
            // capturetestButton
            // 
            capturetestButton.Location = new Point(182, 228);
            capturetestButton.Name = "capturetestButton";
            capturetestButton.Size = new Size(150, 46);
            capturetestButton.TabIndex = 19;
            capturetestButton.Text = "Start";
            capturetestButton.UseVisualStyleBackColor = true;
            capturetestButton.Click += capturetestButton_Click;
            // 
            // detectorThreshold
            // 
            detectorThreshold.DecimalPlaces = 3;
            detectorThreshold.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            detectorThreshold.Location = new Point(207, 58);
            detectorThreshold.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            detectorThreshold.Name = "detectorThreshold";
            detectorThreshold.Size = new Size(135, 39);
            detectorThreshold.TabIndex = 17;
            detectorThreshold.Value = new decimal(new int[] { 700, 0, 0, 196608 });
            detectorThreshold.ValueChanged += detectorThreshold_ValueChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(202, 19);
            label17.Name = "label17";
            label17.Size = new Size(104, 32);
            label17.TabIndex = 16;
            label17.Text = "瞬き閾値";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 19);
            label16.Name = "label16";
            label16.Size = new Size(52, 32);
            label16.TabIndex = 14;
            label16.Text = "FPS";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(targetAdvanceCountdown);
            groupBox2.Controls.Add(currentAdvance);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(randEventType);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(intervalCountdown);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(695, 153);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(267, 464);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "同期";
            // 
            // targetAdvanceCountdown
            // 
            targetAdvanceCountdown.BorderStyle = BorderStyle.None;
            targetAdvanceCountdown.Font = new Font("メイリオ", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            targetAdvanceCountdown.Location = new Point(23, 158);
            targetAdvanceCountdown.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            targetAdvanceCountdown.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            targetAdvanceCountdown.Name = "targetAdvanceCountdown";
            targetAdvanceCountdown.ReadOnly = true;
            targetAdvanceCountdown.Size = new Size(240, 59);
            targetAdvanceCountdown.TabIndex = 10;
            targetAdvanceCountdown.TextAlign = HorizontalAlignment.Right;
            // 
            // currentAdvance
            // 
            currentAdvance.BorderStyle = BorderStyle.None;
            currentAdvance.Font = new Font("メイリオ", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            currentAdvance.Location = new Point(23, 69);
            currentAdvance.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            currentAdvance.Name = "currentAdvance";
            currentAdvance.ReadOnly = true;
            currentAdvance.Size = new Size(240, 59);
            currentAdvance.TabIndex = 9;
            currentAdvance.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 127);
            label8.Name = "label8";
            label8.Size = new Size(175, 32);
            label8.TabIndex = 8;
            label8.Text = "Target Adv. まで";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(17, 35);
            label10.Name = "label10";
            label10.Size = new Size(105, 32);
            label10.TabIndex = 6;
            label10.Text = "Advance";
            // 
            // randEventType
            // 
            randEventType.AutoSize = true;
            randEventType.Font = new Font("メイリオ", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            randEventType.Location = new Point(56, 347);
            randEventType.MaximumSize = new Size(189, 55);
            randEventType.MinimumSize = new Size(189, 55);
            randEventType.Name = "randEventType";
            randEventType.Size = new Size(189, 55);
            randEventType.TabIndex = 3;
            randEventType.Text = "None";
            randEventType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 315);
            label6.Name = "label6";
            label6.Size = new Size(115, 32);
            label6.TabIndex = 2;
            label6.Text = "消費タイプ";
            // 
            // intervalCountdown
            // 
            intervalCountdown.AutoSize = true;
            intervalCountdown.Font = new Font("メイリオ", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            intervalCountdown.Location = new Point(116, 248);
            intervalCountdown.Name = "intervalCountdown";
            intervalCountdown.Size = new Size(129, 55);
            intervalCountdown.TabIndex = 1;
            intervalCountdown.Text = "0.000";
            intervalCountdown.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 219);
            label3.Name = "label3";
            label3.Size = new Size(143, 32);
            label3.TabIndex = 0;
            label3.Text = "次の消費まで";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(targetAdvance);
            groupBox3.Controls.Add(label11);
            groupBox3.Location = new Point(695, 53);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(267, 84);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Target Adv.";
            // 
            // targetAdvance
            // 
            targetAdvance.Location = new Point(68, 34);
            targetAdvance.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            targetAdvance.Name = "targetAdvance";
            targetAdvance.Size = new Size(193, 39);
            targetAdvance.TabIndex = 3;
            targetAdvance.TextAlign = HorizontalAlignment.Right;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 36);
            label11.Name = "label11";
            label11.Size = new Size(59, 32);
            label11.TabIndex = 2;
            label11.Text = "Adv.";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 629);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(tabControl1);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "XsReader";
            FormClosing += MainWindow_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)identifyEntropy).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)minBlinkCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchMin).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)detectorThreshold).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)targetAdvanceCountdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)currentAdvance).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)targetAdvance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private GroupBox groupBox1;
        private TextBox seed1;
        private Label label2;
        private TextBox seed0;
        private Label label1;
        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox groupBox2;
        private Label label10;
        private Label randEventType;
        private Label label6;
        private Label intervalCountdown;
        private Label label3;
        private GroupBox groupBox3;
        private NumericUpDown targetAdvance;
        private Label label11;
        private Label label8;
        private Button identifyButton;
        private NumericUpDown minBlinkCount;
        private Label label14;
        private Label label13;
        private NumericUpDown searchMax;
        private NumericUpDown searchMin;
        private Label label12;
        private Button reidentifyButton;
        private CheckBox isInNoisy;
        private NumericUpDown detectorThreshold;
        private Label label17;
        private Label label16;
        private GroupBox groupBox4;
        private Label blinkIndicator;
        private Label label19;
        private Button capturetestButton;
        private ComboBox capturetestImageName;
        private Label label15;
        private NumericUpDown identifyEntropy;
        private Label label23;
        private ComboBox identifyImageName;
        private Label label22;
        private ComboBox reidentifyImageName;
        private Label label21;
        private Label identifyStatus;
        private Label reidentifyStatus;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private ToolStripMenuItem toolStripMenuItem3;
        private DataGridViewTextBoxColumn IndexColumn;
        private DataGridViewTextBoxColumn IntervalColumn;
        private DataGridViewTextBoxColumn BlinkTypeColumn;
        private NumericUpDown targetAdvanceCountdown;
        private NumericUpDown currentAdvance;
        private NumericUpDown numericUpDown1;
    }
}