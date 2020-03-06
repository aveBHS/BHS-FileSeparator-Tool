namespace BHS_FileSeparator_Tool
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.helpBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.sizeOfPartType = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.outDirGroupBox = new System.Windows.Forms.GroupBox();
            this.browsreOutDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderToSeparationTextBox = new System.Windows.Forms.TextBox();
            this.ramEcoGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ramEcoLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ramEcoTrackBar = new System.Windows.Forms.TrackBar();
            this.sourceGroupBox = new System.Windows.Forms.GroupBox();
            this.browseFileUrl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileToSeparationUrlTextBox = new System.Windows.Forms.TextBox();
            this.separationSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.partNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.switchSizeInput = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeOfPart = new System.Windows.Forms.ComboBox();
            this.checkGroupBox = new System.Windows.Forms.GroupBox();
            this.enableMd5Check = new System.Windows.Forms.RadioButton();
            this.disableHash = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startSeparating = new System.Windows.Forms.Button();
            this.separationProgress = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.importFileBuilder = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.outDirGroupBox.SuspendLayout();
            this.ramEcoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramEcoTrackBar)).BeginInit();
            this.sourceGroupBox.SuspendLayout();
            this.separationSettingsGroupBox.SuspendLayout();
            this.checkGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 372);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(627, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // helpBar
            // 
            this.helpBar.Name = "helpBar";
            this.helpBar.Size = new System.Drawing.Size(0, 17);
            // 
            // sizeOfPartType
            // 
            this.sizeOfPartType.FormattingEnabled = true;
            this.sizeOfPartType.Items.AddRange(new object[] {
            "БАЙТ",
            "КБ",
            "МБ",
            "ГБ"});
            this.sizeOfPartType.Location = new System.Drawing.Point(156, 41);
            this.sizeOfPartType.Name = "sizeOfPartType";
            this.helpProvider1.SetShowHelp(this.sizeOfPartType, false);
            this.sizeOfPartType.Size = new System.Drawing.Size(62, 21);
            this.sizeOfPartType.TabIndex = 3;
            this.sizeOfPartType.SelectedIndexChanged += new System.EventHandler(this.sizeOfPartType_SelectedIndexChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(619, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Сборка файлов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.outDirGroupBox);
            this.tabPage1.Controls.Add(this.ramEcoGroupBox);
            this.tabPage1.Controls.Add(this.sourceGroupBox);
            this.tabPage1.Controls.Add(this.separationSettingsGroupBox);
            this.tabPage1.Controls.Add(this.checkGroupBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(619, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Разборка файлов";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // outDirGroupBox
            // 
            this.outDirGroupBox.Controls.Add(this.browsreOutDir);
            this.outDirGroupBox.Controls.Add(this.label3);
            this.outDirGroupBox.Controls.Add(this.folderToSeparationTextBox);
            this.outDirGroupBox.Location = new System.Drawing.Point(3, 83);
            this.outDirGroupBox.Name = "outDirGroupBox";
            this.outDirGroupBox.Size = new System.Drawing.Size(378, 82);
            this.outDirGroupBox.TabIndex = 1003;
            this.outDirGroupBox.TabStop = false;
            this.outDirGroupBox.Text = "Выходная папка";
            // 
            // browsreOutDir
            // 
            this.browsreOutDir.Location = new System.Drawing.Point(294, 35);
            this.browsreOutDir.Name = "browsreOutDir";
            this.browsreOutDir.Size = new System.Drawing.Size(75, 23);
            this.browsreOutDir.TabIndex = 1002;
            this.browsreOutDir.Text = "Обзор";
            this.browsreOutDir.UseVisualStyleBackColor = true;
            this.browsreOutDir.Click += new System.EventHandler(this.BrowsreOutDir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 1001;
            this.label3.Text = "Путь к папке";
            // 
            // folderToSeparationTextBox
            // 
            this.folderToSeparationTextBox.Location = new System.Drawing.Point(6, 38);
            this.folderToSeparationTextBox.Name = "folderToSeparationTextBox";
            this.folderToSeparationTextBox.ReadOnly = true;
            this.folderToSeparationTextBox.Size = new System.Drawing.Size(282, 20);
            this.folderToSeparationTextBox.TabIndex = 0;
            // 
            // ramEcoGroupBox
            // 
            this.ramEcoGroupBox.Controls.Add(this.label6);
            this.ramEcoGroupBox.Controls.Add(this.ramEcoLabel);
            this.ramEcoGroupBox.Controls.Add(this.label5);
            this.ramEcoGroupBox.Controls.Add(this.ramEcoTrackBar);
            this.ramEcoGroupBox.Location = new System.Drawing.Point(6, 171);
            this.ramEcoGroupBox.Name = "ramEcoGroupBox";
            this.ramEcoGroupBox.Size = new System.Drawing.Size(375, 120);
            this.ramEcoGroupBox.TabIndex = 4;
            this.ramEcoGroupBox.TabStop = false;
            this.ramEcoGroupBox.Text = "Экономия ОЗУ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 13);
            this.label6.TabIndex = 1003;
            this.label6.Text = "Ограничение использования ОЗУ. Стандартно - 32 МБ";
            // 
            // ramEcoLabel
            // 
            this.ramEcoLabel.AutoSize = true;
            this.ramEcoLabel.Enabled = false;
            this.ramEcoLabel.Location = new System.Drawing.Point(316, 46);
            this.ramEcoLabel.Name = "ramEcoLabel";
            this.ramEcoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ramEcoLabel.Size = new System.Drawing.Size(38, 13);
            this.ramEcoLabel.TabIndex = 1004;
            this.ramEcoLabel.Text = "32 МБ";
            this.ramEcoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ramEcoLabel.Click += new System.EventHandler(this.RamEcoLabel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 13);
            this.label5.TabIndex = 1003;
            this.label5.Text = "Максимальный размер части файла загружаемого в ОЗУ";
            // 
            // ramEcoTrackBar
            // 
            this.ramEcoTrackBar.BackColor = System.Drawing.Color.White;
            this.ramEcoTrackBar.LargeChange = 1;
            this.ramEcoTrackBar.Location = new System.Drawing.Point(6, 68);
            this.ramEcoTrackBar.Maximum = 5;
            this.ramEcoTrackBar.Name = "ramEcoTrackBar";
            this.ramEcoTrackBar.Size = new System.Drawing.Size(360, 45);
            this.ramEcoTrackBar.TabIndex = 0;
            this.ramEcoTrackBar.Scroll += new System.EventHandler(this.RamEcoTrackBar_Scroll);
            // 
            // sourceGroupBox
            // 
            this.sourceGroupBox.Controls.Add(this.browseFileUrl);
            this.sourceGroupBox.Controls.Add(this.label2);
            this.sourceGroupBox.Controls.Add(this.fileToSeparationUrlTextBox);
            this.sourceGroupBox.Location = new System.Drawing.Point(3, 6);
            this.sourceGroupBox.Name = "sourceGroupBox";
            this.sourceGroupBox.Size = new System.Drawing.Size(378, 71);
            this.sourceGroupBox.TabIndex = 3;
            this.sourceGroupBox.TabStop = false;
            this.sourceGroupBox.Text = "Источник";
            // 
            // browseFileUrl
            // 
            this.browseFileUrl.Location = new System.Drawing.Point(294, 34);
            this.browseFileUrl.Name = "browseFileUrl";
            this.browseFileUrl.Size = new System.Drawing.Size(75, 23);
            this.browseFileUrl.TabIndex = 1002;
            this.browseFileUrl.Text = "Обзор";
            this.browseFileUrl.UseVisualStyleBackColor = true;
            this.browseFileUrl.Click += new System.EventHandler(this.BrowseFileUrl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1001;
            this.label2.Text = "Путь к файлу";
            // 
            // fileToSeparationUrlTextBox
            // 
            this.fileToSeparationUrlTextBox.Location = new System.Drawing.Point(6, 37);
            this.fileToSeparationUrlTextBox.Name = "fileToSeparationUrlTextBox";
            this.fileToSeparationUrlTextBox.ReadOnly = true;
            this.fileToSeparationUrlTextBox.Size = new System.Drawing.Size(282, 20);
            this.fileToSeparationUrlTextBox.TabIndex = 0;
            // 
            // separationSettingsGroupBox
            // 
            this.separationSettingsGroupBox.Controls.Add(this.partNameBox);
            this.separationSettingsGroupBox.Controls.Add(this.label4);
            this.separationSettingsGroupBox.Controls.Add(this.switchSizeInput);
            this.separationSettingsGroupBox.Controls.Add(this.label1);
            this.separationSettingsGroupBox.Controls.Add(this.sizeOfPartType);
            this.separationSettingsGroupBox.Controls.Add(this.sizeOfPart);
            this.separationSettingsGroupBox.Location = new System.Drawing.Point(387, 83);
            this.separationSettingsGroupBox.Name = "separationSettingsGroupBox";
            this.separationSettingsGroupBox.Size = new System.Drawing.Size(225, 147);
            this.separationSettingsGroupBox.TabIndex = 2;
            this.separationSettingsGroupBox.TabStop = false;
            this.separationSettingsGroupBox.Text = "Настройки разделения";
            // 
            // partNameBox
            // 
            this.partNameBox.Location = new System.Drawing.Point(8, 113);
            this.partNameBox.Name = "partNameBox";
            this.partNameBox.Size = new System.Drawing.Size(210, 20);
            this.partNameBox.TabIndex = 1002;
            this.partNameBox.Text = "part#.bin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 1001;
            this.label4.Text = "Название частей (обязательно #)";
            // 
            // switchSizeInput
            // 
            this.switchSizeInput.AutoSize = true;
            this.switchSizeInput.Location = new System.Drawing.Point(5, 68);
            this.switchSizeInput.Name = "switchSizeInput";
            this.switchSizeInput.Size = new System.Drawing.Size(196, 13);
            this.switchSizeInput.TabIndex = 1000;
            this.switchSizeInput.TabStop = true;
            this.switchSizeInput.Text = "Ручная установка размера (в байтах)";
            this.switchSizeInput.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 999;
            this.label1.Text = "Размер части файла";
            // 
            // sizeOfPart
            // 
            this.sizeOfPart.FormattingEnabled = true;
            this.sizeOfPart.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096"});
            this.sizeOfPart.Location = new System.Drawing.Point(6, 41);
            this.sizeOfPart.Name = "sizeOfPart";
            this.sizeOfPart.Size = new System.Drawing.Size(143, 21);
            this.sizeOfPart.TabIndex = 2;
            // 
            // checkGroupBox
            // 
            this.checkGroupBox.Controls.Add(this.enableMd5Check);
            this.checkGroupBox.Controls.Add(this.disableHash);
            this.checkGroupBox.Location = new System.Drawing.Point(387, 6);
            this.checkGroupBox.Name = "checkGroupBox";
            this.checkGroupBox.Size = new System.Drawing.Size(226, 71);
            this.checkGroupBox.TabIndex = 1;
            this.checkGroupBox.TabStop = false;
            this.checkGroupBox.Text = "Проверка целостности";
            // 
            // enableMd5Check
            // 
            this.enableMd5Check.AutoSize = true;
            this.enableMd5Check.Location = new System.Drawing.Point(6, 42);
            this.enableMd5Check.Name = "enableMd5Check";
            this.enableMd5Check.Size = new System.Drawing.Size(101, 17);
            this.enableMd5Check.TabIndex = 1;
            this.enableMd5Check.Text = "MD5 Checksum";
            this.enableMd5Check.UseVisualStyleBackColor = true;
            // 
            // disableHash
            // 
            this.disableHash.AutoSize = true;
            this.disableHash.Checked = true;
            this.disableHash.Location = new System.Drawing.Point(6, 19);
            this.disableHash.Name = "disableHash";
            this.disableHash.Size = new System.Drawing.Size(44, 17);
            this.disableHash.TabIndex = 0;
            this.disableHash.TabStop = true;
            this.disableHash.Text = "Нет";
            this.disableHash.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startSeparating);
            this.groupBox1.Controls.Add(this.separationProgress);
            this.groupBox1.Location = new System.Drawing.Point(3, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Прогресс";
            // 
            // startSeparating
            // 
            this.startSeparating.Location = new System.Drawing.Point(495, 17);
            this.startSeparating.Name = "startSeparating";
            this.startSeparating.Size = new System.Drawing.Size(112, 23);
            this.startSeparating.TabIndex = 0;
            this.startSeparating.Text = "Запуск";
            this.startSeparating.UseVisualStyleBackColor = true;
            this.startSeparating.Click += new System.EventHandler(this.StartSeparating_Click);
            // 
            // separationProgress
            // 
            this.separationProgress.Location = new System.Drawing.Point(6, 17);
            this.separationProgress.Name = "separationProgress";
            this.separationProgress.Size = new System.Drawing.Size(483, 23);
            this.separationProgress.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 372);
            this.tabControl1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.importFileBuilder);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(387, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сборщик файла (Soon...)";
            // 
            // importFileBuilder
            // 
            this.importFileBuilder.AutoSize = true;
            this.importFileBuilder.Location = new System.Drawing.Point(8, 24);
            this.importFileBuilder.Name = "importFileBuilder";
            this.importFileBuilder.Size = new System.Drawing.Size(200, 17);
            this.importFileBuilder.TabIndex = 2;
            this.importFileBuilder.Text = "Добавить в папку сборщик файла";
            this.importFileBuilder.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 394);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(643, 433);
            this.MinimumSize = new System.Drawing.Size(643, 433);
            this.Name = "Form1";
            this.Text = "BHS FileSeparator Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.outDirGroupBox.ResumeLayout(false);
            this.outDirGroupBox.PerformLayout();
            this.ramEcoGroupBox.ResumeLayout(false);
            this.ramEcoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramEcoTrackBar)).EndInit();
            this.sourceGroupBox.ResumeLayout(false);
            this.sourceGroupBox.PerformLayout();
            this.separationSettingsGroupBox.ResumeLayout(false);
            this.separationSettingsGroupBox.PerformLayout();
            this.checkGroupBox.ResumeLayout(false);
            this.checkGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel helpBar;
        public System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox separationSettingsGroupBox;
        private System.Windows.Forms.LinkLabel switchSizeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sizeOfPartType;
        private System.Windows.Forms.ComboBox sizeOfPart;
        private System.Windows.Forms.GroupBox checkGroupBox;
        private System.Windows.Forms.RadioButton enableMd5Check;
        private System.Windows.Forms.RadioButton disableHash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button startSeparating;
        private System.Windows.Forms.ProgressBar separationProgress;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox outDirGroupBox;
        private System.Windows.Forms.Button browsreOutDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox folderToSeparationTextBox;
        private System.Windows.Forms.GroupBox ramEcoGroupBox;
        private System.Windows.Forms.Label ramEcoLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar ramEcoTrackBar;
        private System.Windows.Forms.GroupBox sourceGroupBox;
        private System.Windows.Forms.Button browseFileUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fileToSeparationUrlTextBox;
        private System.Windows.Forms.TextBox partNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox importFileBuilder;
    }
}

