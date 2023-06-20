namespace SprutUpdate
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.oracleSchemaLabel = new System.Windows.Forms.Label();
            this.oracleRadioButton = new System.Windows.Forms.RadioButton();
            this.interbaseRadioButton = new System.Windows.Forms.RadioButton();
            this.interbaseServerLabel = new System.Windows.Forms.Label();
            this.oracleServerLabel = new System.Windows.Forms.Label();
            this.oracleServerTextBox = new System.Windows.Forms.TextBox();
            this.interbaseServerTextBox = new System.Windows.Forms.TextBox();
            this.interbasePathLabel = new System.Windows.Forms.Label();
            this.oracleSchemaTextBox = new System.Windows.Forms.TextBox();
            this.interbasePathTextBox = new System.Windows.Forms.TextBox();
            this.interbaseChangeFileButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.sourcePathTextBox = new System.Windows.Forms.TextBox();
            this.sourcePathLabel = new System.Windows.Forms.Label();
            this.sourceServerTextBox = new System.Windows.Forms.TextBox();
            this.sourceChangeFileButton = new System.Windows.Forms.Button();
            this.sourceServerLabel = new System.Windows.Forms.Label();
            this.sourceCheckBox = new System.Windows.Forms.CheckBox();
            this.interbaseOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sourceOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.taskProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.taskStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.updateButton = new System.Windows.Forms.ToolStripButton();
            this.startAutoUpdateButton = new System.Windows.Forms.ToolStripButton();
            this.stopAutoUpdateButton = new System.Windows.Forms.ToolStripButton();
            this.saveSettingsButton = new System.Windows.Forms.ToolStripButton();
            this.commandButton = new System.Windows.Forms.ToolStripButton();
            this.correctButton = new System.Windows.Forms.ToolStripButton();
            this.clearInterbaseButton = new System.Windows.Forms.ToolStripButton();
            this.lastInckeyCheckBox = new System.Windows.Forms.CheckBox();
            this.lastInckeySetupDownLabel = new System.Windows.Forms.Label();
            this.lastInckeySourceLabel = new System.Windows.Forms.Label();
            this.lastInckeySetupDownTextBox = new System.Windows.Forms.TextBox();
            this.lastInckeySourceTextBox = new System.Windows.Forms.TextBox();
            this.updateNumbersCheckBox = new System.Windows.Forms.CheckBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.NextUpdateTimeLabel = new System.Windows.Forms.Label();
            this.freqLabel = new System.Windows.Forms.Label();
            this.freqComboBox = new System.Windows.Forms.ComboBox();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.clearInterbaseOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.clearInterbaseButton2 = new System.Windows.Forms.Button();
            this.correctButton2 = new System.Windows.Forms.Button();
            this.commandButton2 = new System.Windows.Forms.Button();
            this.stopAutoUpdateButton2 = new System.Windows.Forms.Button();
            this.startAutoUpdateButton2 = new System.Windows.Forms.Button();
            this.updateButton2 = new System.Windows.Forms.Button();
            this.saveSettingsButton2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.145248F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.973501F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.92429F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.16139F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.81072F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.984858F));
            this.tableLayoutPanel.Controls.Add(this.oracleSchemaLabel, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.oracleRadioButton, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.interbaseRadioButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.interbaseServerLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.oracleServerLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.oracleServerTextBox, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.interbaseServerTextBox, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.interbasePathLabel, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.oracleSchemaTextBox, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.interbasePathTextBox, 4, 1);
            this.tableLayoutPanel.Controls.Add(this.interbaseChangeFileButton, 5, 1);
            this.tableLayoutPanel.Controls.Add(this.passwordTextBox, 4, 4);
            this.tableLayoutPanel.Controls.Add(this.userTextBox, 4, 3);
            this.tableLayoutPanel.Controls.Add(this.passwordLabel, 3, 4);
            this.tableLayoutPanel.Controls.Add(this.userLabel, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.sourcePathTextBox, 4, 2);
            this.tableLayoutPanel.Controls.Add(this.sourcePathLabel, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.sourceServerTextBox, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.sourceChangeFileButton, 5, 2);
            this.tableLayoutPanel.Controls.Add(this.sourceServerLabel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.sourceCheckBox, 0, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(15, 27);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1240, 147);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // oracleSchemaLabel
            // 
            this.oracleSchemaLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.oracleSchemaLabel.AutoSize = true;
            this.oracleSchemaLabel.Location = new System.Drawing.Point(450, 5);
            this.oracleSchemaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oracleSchemaLabel.Name = "oracleSchemaLabel";
            this.oracleSchemaLabel.Size = new System.Drawing.Size(56, 18);
            this.oracleSchemaLabel.TabIndex = 6;
            this.oracleSchemaLabel.Text = "Схема";
            // 
            // oracleRadioButton
            // 
            this.oracleRadioButton.AutoSize = true;
            this.oracleRadioButton.Checked = true;
            this.oracleRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.oracleRadioButton.Location = new System.Drawing.Point(4, 4);
            this.oracleRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.oracleRadioButton.Name = "oracleRadioButton";
            this.oracleRadioButton.Size = new System.Drawing.Size(72, 21);
            this.oracleRadioButton.TabIndex = 0;
            this.oracleRadioButton.TabStop = true;
            this.oracleRadioButton.Text = "Oracle";
            this.oracleRadioButton.UseVisualStyleBackColor = true;
            this.oracleRadioButton.CheckedChanged += new System.EventHandler(this.oracleRadioButton_CheckedChanged);
            // 
            // interbaseRadioButton
            // 
            this.interbaseRadioButton.AutoSize = true;
            this.interbaseRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.interbaseRadioButton.Location = new System.Drawing.Point(4, 33);
            this.interbaseRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.interbaseRadioButton.Name = "interbaseRadioButton";
            this.interbaseRadioButton.Size = new System.Drawing.Size(90, 21);
            this.interbaseRadioButton.TabIndex = 3;
            this.interbaseRadioButton.Text = "Interbase";
            this.interbaseRadioButton.UseVisualStyleBackColor = true;
            this.interbaseRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // interbaseServerLabel
            // 
            this.interbaseServerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.interbaseServerLabel.AutoSize = true;
            this.interbaseServerLabel.Enabled = false;
            this.interbaseServerLabel.Location = new System.Drawing.Point(117, 34);
            this.interbaseServerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.interbaseServerLabel.Name = "interbaseServerLabel";
            this.interbaseServerLabel.Size = new System.Drawing.Size(65, 18);
            this.interbaseServerLabel.TabIndex = 3;
            this.interbaseServerLabel.Text = "Сервер";
            // 
            // oracleServerLabel
            // 
            this.oracleServerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.oracleServerLabel.AutoSize = true;
            this.oracleServerLabel.Location = new System.Drawing.Point(117, 5);
            this.oracleServerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oracleServerLabel.Name = "oracleServerLabel";
            this.oracleServerLabel.Size = new System.Drawing.Size(65, 18);
            this.oracleServerLabel.TabIndex = 2;
            this.oracleServerLabel.Text = "Сервер";
            // 
            // oracleServerTextBox
            // 
            this.oracleServerTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.oracleServerTextBox.Location = new System.Drawing.Point(202, 3);
            this.oracleServerTextBox.Name = "oracleServerTextBox";
            this.oracleServerTextBox.Size = new System.Drawing.Size(241, 26);
            this.oracleServerTextBox.TabIndex = 1;
            // 
            // interbaseServerTextBox
            // 
            this.interbaseServerTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.interbaseServerTextBox.Enabled = false;
            this.interbaseServerTextBox.Location = new System.Drawing.Point(202, 32);
            this.interbaseServerTextBox.Name = "interbaseServerTextBox";
            this.interbaseServerTextBox.Size = new System.Drawing.Size(241, 26);
            this.interbaseServerTextBox.TabIndex = 4;
            // 
            // interbasePathLabel
            // 
            this.interbasePathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.interbasePathLabel.AutoSize = true;
            this.interbasePathLabel.Enabled = false;
            this.interbasePathLabel.Location = new System.Drawing.Point(450, 34);
            this.interbasePathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.interbasePathLabel.Name = "interbasePathLabel";
            this.interbasePathLabel.Size = new System.Drawing.Size(102, 18);
            this.interbasePathLabel.TabIndex = 7;
            this.interbasePathLabel.Text = "Путь к файлу";
            // 
            // oracleSchemaTextBox
            // 
            this.oracleSchemaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oracleSchemaTextBox.Location = new System.Drawing.Point(575, 3);
            this.oracleSchemaTextBox.Name = "oracleSchemaTextBox";
            this.oracleSchemaTextBox.Size = new System.Drawing.Size(611, 26);
            this.oracleSchemaTextBox.TabIndex = 2;
            // 
            // interbasePathTextBox
            // 
            this.interbasePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interbasePathTextBox.Enabled = false;
            this.interbasePathTextBox.Location = new System.Drawing.Point(575, 32);
            this.interbasePathTextBox.Name = "interbasePathTextBox";
            this.interbasePathTextBox.Size = new System.Drawing.Size(611, 26);
            this.interbasePathTextBox.TabIndex = 5;
            // 
            // interbaseChangeFileButton
            // 
            this.interbaseChangeFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interbaseChangeFileButton.Enabled = false;
            this.interbaseChangeFileButton.Location = new System.Drawing.Point(1192, 32);
            this.interbaseChangeFileButton.Name = "interbaseChangeFileButton";
            this.interbaseChangeFileButton.Size = new System.Drawing.Size(45, 23);
            this.interbaseChangeFileButton.TabIndex = 6;
            this.interbaseChangeFileButton.Text = "...";
            this.interbaseChangeFileButton.UseVisualStyleBackColor = true;
            this.interbaseChangeFileButton.Click += new System.EventHandler(this.interbaseChangeFileButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(575, 119);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(611, 26);
            this.passwordTextBox.TabIndex = 12;
            this.passwordTextBox.Text = "masterkey";
            // 
            // userTextBox
            // 
            this.userTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userTextBox.Location = new System.Drawing.Point(575, 90);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(611, 26);
            this.userTextBox.TabIndex = 11;
            this.userTextBox.Text = "SYSDBA";
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(449, 122);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(63, 18);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Пароль";
            // 
            // userLabel
            // 
            this.userLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(449, 92);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(111, 18);
            this.userLabel.TabIndex = 8;
            this.userLabel.Text = "Пользователь";
            // 
            // sourcePathTextBox
            // 
            this.sourcePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePathTextBox.Enabled = false;
            this.sourcePathTextBox.Location = new System.Drawing.Point(575, 61);
            this.sourcePathTextBox.Name = "sourcePathTextBox";
            this.sourcePathTextBox.Size = new System.Drawing.Size(611, 26);
            this.sourcePathTextBox.TabIndex = 9;
            // 
            // sourcePathLabel
            // 
            this.sourcePathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sourcePathLabel.AutoSize = true;
            this.sourcePathLabel.Enabled = false;
            this.sourcePathLabel.Location = new System.Drawing.Point(450, 63);
            this.sourcePathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sourcePathLabel.Name = "sourcePathLabel";
            this.sourcePathLabel.Size = new System.Drawing.Size(102, 18);
            this.sourcePathLabel.TabIndex = 8;
            this.sourcePathLabel.Text = "Путь к файлу";
            // 
            // sourceServerTextBox
            // 
            this.sourceServerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceServerTextBox.Enabled = false;
            this.sourceServerTextBox.Location = new System.Drawing.Point(202, 61);
            this.sourceServerTextBox.Name = "sourceServerTextBox";
            this.sourceServerTextBox.Size = new System.Drawing.Size(241, 26);
            this.sourceServerTextBox.TabIndex = 8;
            // 
            // sourceChangeFileButton
            // 
            this.sourceChangeFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceChangeFileButton.Enabled = false;
            this.sourceChangeFileButton.Location = new System.Drawing.Point(1192, 61);
            this.sourceChangeFileButton.Name = "sourceChangeFileButton";
            this.sourceChangeFileButton.Size = new System.Drawing.Size(45, 23);
            this.sourceChangeFileButton.TabIndex = 10;
            this.sourceChangeFileButton.Text = "...";
            this.sourceChangeFileButton.UseVisualStyleBackColor = true;
            this.sourceChangeFileButton.Click += new System.EventHandler(this.sourceChangeFileButton_Click);
            // 
            // sourceServerLabel
            // 
            this.sourceServerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sourceServerLabel.AutoSize = true;
            this.sourceServerLabel.Enabled = false;
            this.sourceServerLabel.Location = new System.Drawing.Point(117, 63);
            this.sourceServerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sourceServerLabel.Name = "sourceServerLabel";
            this.sourceServerLabel.Size = new System.Drawing.Size(65, 18);
            this.sourceServerLabel.TabIndex = 4;
            this.sourceServerLabel.Text = "Сервер";
            // 
            // sourceCheckBox
            // 
            this.sourceCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sourceCheckBox.AutoSize = true;
            this.sourceCheckBox.Location = new System.Drawing.Point(3, 61);
            this.sourceCheckBox.Name = "sourceCheckBox";
            this.sourceCheckBox.Size = new System.Drawing.Size(102, 22);
            this.sourceCheckBox.TabIndex = 7;
            this.sourceCheckBox.Text = "Источники";
            this.sourceCheckBox.UseVisualStyleBackColor = true;
            this.sourceCheckBox.CheckedChanged += new System.EventHandler(this.sourceCheckBox_CheckedChanged);
            // 
            // interbaseOpenFileDialog
            // 
            this.interbaseOpenFileDialog.Filter = "База данных Спрут (*.ibs)|*.ibs";
            // 
            // sourceOpenFileDialog
            // 
            this.sourceOpenFileDialog.Filter = "База данных Источников Source (*.ibs)|*.ibs";
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskProgressBar,
            this.taskStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 414);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1269, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // taskProgressBar
            // 
            this.taskProgressBar.Name = "taskProgressBar";
            this.taskProgressBar.Size = new System.Drawing.Size(112, 16);
            // 
            // taskStatusLabel
            // 
            this.taskStatusLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskStatusLabel.Name = "taskStatusLabel";
            this.taskStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateButton,
            this.startAutoUpdateButton,
            this.stopAutoUpdateButton,
            this.saveSettingsButton,
            this.commandButton,
            this.correctButton,
            this.clearInterbaseButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1269, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // updateButton
            // 
            this.updateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateButton.Image = ((System.Drawing.Image)(resources.GetObject("updateButton.Image")));
            this.updateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(23, 22);
            this.updateButton.Text = "Обработать всю базу";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // startAutoUpdateButton
            // 
            this.startAutoUpdateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startAutoUpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("startAutoUpdateButton.Image")));
            this.startAutoUpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startAutoUpdateButton.Name = "startAutoUpdateButton";
            this.startAutoUpdateButton.Size = new System.Drawing.Size(23, 22);
            this.startAutoUpdateButton.Text = "Запустить автоматическую обработку базы";
            this.startAutoUpdateButton.Click += new System.EventHandler(this.startAutoUpdateButton_Click);
            // 
            // stopAutoUpdateButton
            // 
            this.stopAutoUpdateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopAutoUpdateButton.Enabled = false;
            this.stopAutoUpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("stopAutoUpdateButton.Image")));
            this.stopAutoUpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopAutoUpdateButton.Name = "stopAutoUpdateButton";
            this.stopAutoUpdateButton.Size = new System.Drawing.Size(23, 22);
            this.stopAutoUpdateButton.Text = "Остановить автоматическую обработку базы";
            this.stopAutoUpdateButton.Click += new System.EventHandler(this.stopAutoUpdateButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveSettingsButton.Image = global::SprutUpdate.Properties.Resources.Save;
            this.saveSettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(23, 22);
            this.saveSettingsButton.Text = "Сохранить настройки";
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // commandButton
            // 
            this.commandButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.commandButton.Image = global::SprutUpdate.Properties.Resources.Settings;
            this.commandButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.commandButton.Name = "commandButton";
            this.commandButton.Size = new System.Drawing.Size(23, 22);
            this.commandButton.Text = "Выполнение SQL";
            this.commandButton.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // correctButton
            // 
            this.correctButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.correctButton.Image = global::SprutUpdate.Properties.Resources.burn;
            this.correctButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.correctButton.Name = "correctButton";
            this.correctButton.Size = new System.Drawing.Size(23, 22);
            this.correctButton.Text = "Исправление номеров";
            this.correctButton.Click += new System.EventHandler(this.correctButton_Click);
            // 
            // clearInterbaseButton
            // 
            this.clearInterbaseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearInterbaseButton.Image = global::SprutUpdate.Properties.Resources.trashful1;
            this.clearInterbaseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearInterbaseButton.Name = "clearInterbaseButton";
            this.clearInterbaseButton.Size = new System.Drawing.Size(23, 22);
            this.clearInterbaseButton.Text = "Очистить базу спрут";
            this.clearInterbaseButton.Click += new System.EventHandler(this.clearInterbaseButton_Click);
            // 
            // lastInckeyCheckBox
            // 
            this.lastInckeyCheckBox.AutoSize = true;
            this.lastInckeyCheckBox.Location = new System.Drawing.Point(19, 208);
            this.lastInckeyCheckBox.Name = "lastInckeyCheckBox";
            this.lastInckeyCheckBox.Size = new System.Drawing.Size(347, 22);
            this.lastInckeyCheckBox.TabIndex = 2;
            this.lastInckeyCheckBox.Text = "Начинать с последней обработанной записи";
            this.lastInckeyCheckBox.UseVisualStyleBackColor = true;
            this.lastInckeyCheckBox.CheckedChanged += new System.EventHandler(this.lastInckeyCheckBox_CheckedChanged);
            // 
            // lastInckeySetupDownLabel
            // 
            this.lastInckeySetupDownLabel.AutoSize = true;
            this.lastInckeySetupDownLabel.Enabled = false;
            this.lastInckeySetupDownLabel.Location = new System.Drawing.Point(15, 232);
            this.lastInckeySetupDownLabel.Name = "lastInckeySetupDownLabel";
            this.lastInckeySetupDownLabel.Size = new System.Drawing.Size(93, 18);
            this.lastInckeySetupDownLabel.TabIndex = 9;
            this.lastInckeySetupDownLabel.Text = "Setup Down";
            // 
            // lastInckeySourceLabel
            // 
            this.lastInckeySourceLabel.AutoSize = true;
            this.lastInckeySourceLabel.Enabled = false;
            this.lastInckeySourceLabel.Location = new System.Drawing.Point(15, 261);
            this.lastInckeySourceLabel.Name = "lastInckeySourceLabel";
            this.lastInckeySourceLabel.Size = new System.Drawing.Size(95, 18);
            this.lastInckeySourceLabel.TabIndex = 10;
            this.lastInckeySourceLabel.Text = "SourceBase";
            // 
            // lastInckeySetupDownTextBox
            // 
            this.lastInckeySetupDownTextBox.Enabled = false;
            this.lastInckeySetupDownTextBox.Location = new System.Drawing.Point(135, 229);
            this.lastInckeySetupDownTextBox.Name = "lastInckeySetupDownTextBox";
            this.lastInckeySetupDownTextBox.Size = new System.Drawing.Size(314, 26);
            this.lastInckeySetupDownTextBox.TabIndex = 3;
            this.lastInckeySetupDownTextBox.DoubleClick += new System.EventHandler(this.lastInckey_DoubleClick);
            // 
            // lastInckeySourceTextBox
            // 
            this.lastInckeySourceTextBox.Enabled = false;
            this.lastInckeySourceTextBox.Location = new System.Drawing.Point(135, 258);
            this.lastInckeySourceTextBox.Name = "lastInckeySourceTextBox";
            this.lastInckeySourceTextBox.Size = new System.Drawing.Size(314, 26);
            this.lastInckeySourceTextBox.TabIndex = 4;
            this.lastInckeySourceTextBox.DoubleClick += new System.EventHandler(this.lastInckey_DoubleClick);
            // 
            // updateNumbersCheckBox
            // 
            this.updateNumbersCheckBox.AutoSize = true;
            this.updateNumbersCheckBox.Location = new System.Drawing.Point(19, 181);
            this.updateNumbersCheckBox.Name = "updateNumbersCheckBox";
            this.updateNumbersCheckBox.Size = new System.Drawing.Size(310, 22);
            this.updateNumbersCheckBox.TabIndex = 1;
            this.updateNumbersCheckBox.Text = "Исправлять пользовательские номера";
            this.updateNumbersCheckBox.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "HD.ico");
            this.imageList.Images.SetKeyName(1, "Play.ico");
            this.imageList.Images.SetKeyName(2, "Play2.ico");
            this.imageList.Images.SetKeyName(3, "Player-Eject.ico");
            this.imageList.Images.SetKeyName(4, "Player-Next.ico");
            this.imageList.Images.SetKeyName(5, "Player-Pause.ico");
            this.imageList.Images.SetKeyName(6, "Player-Play.ico");
            this.imageList.Images.SetKeyName(7, "Player-Preview.ico");
            this.imageList.Images.SetKeyName(8, "Player-Stop.ico");
            // 
            // NextUpdateTimeLabel
            // 
            this.NextUpdateTimeLabel.AutoSize = true;
            this.NextUpdateTimeLabel.Location = new System.Drawing.Point(15, 387);
            this.NextUpdateTimeLabel.Name = "NextUpdateTimeLabel";
            this.NextUpdateTimeLabel.Size = new System.Drawing.Size(0, 18);
            this.NextUpdateTimeLabel.TabIndex = 11;
            // 
            // freqLabel
            // 
            this.freqLabel.AutoSize = true;
            this.freqLabel.Location = new System.Drawing.Point(583, 184);
            this.freqLabel.Name = "freqLabel";
            this.freqLabel.Size = new System.Drawing.Size(308, 18);
            this.freqLabel.TabIndex = 13;
            this.freqLabel.Text = "Частота автоматического обновления (ч)";
            // 
            // freqComboBox
            // 
            this.freqComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.freqComboBox.FormattingEnabled = true;
            this.freqComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "6",
            "12"});
            this.freqComboBox.Location = new System.Drawing.Point(897, 179);
            this.freqComboBox.Name = "freqComboBox";
            this.freqComboBox.Size = new System.Drawing.Size(101, 26);
            this.freqComboBox.TabIndex = 14;
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(685, 209);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(206, 18);
            this.intervalLabel.TabIndex = 15;
            this.intervalLabel.Text = "Проверка обновления (сут)";
            // 
            // intervalNumericUpDown
            // 
            this.intervalNumericUpDown.Location = new System.Drawing.Point(897, 207);
            this.intervalNumericUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.intervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intervalNumericUpDown.Name = "intervalNumericUpDown";
            this.intervalNumericUpDown.Size = new System.Drawing.Size(101, 26);
            this.intervalNumericUpDown.TabIndex = 16;
            this.intervalNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // clearInterbaseOpenFileDialog
            // 
            this.clearInterbaseOpenFileDialog.Filter = "База данных Спрут (*.ibs)|*.ibs";
            // 
            // clearInterbaseButton2
            // 
            this.clearInterbaseButton2.Image = global::SprutUpdate.Properties.Resources.trashful1;
            this.clearInterbaseButton2.Location = new System.Drawing.Point(393, 301);
            this.clearInterbaseButton2.Name = "clearInterbaseButton2";
            this.clearInterbaseButton2.Size = new System.Drawing.Size(56, 45);
            this.clearInterbaseButton2.TabIndex = 19;
            this.clearInterbaseButton2.UseVisualStyleBackColor = true;
            this.clearInterbaseButton2.Click += new System.EventHandler(this.clearInterbaseButton_Click);
            // 
            // correctButton2
            // 
            this.correctButton2.Image = global::SprutUpdate.Properties.Resources.burn;
            this.correctButton2.Location = new System.Drawing.Point(330, 301);
            this.correctButton2.Name = "correctButton2";
            this.correctButton2.Size = new System.Drawing.Size(56, 45);
            this.correctButton2.TabIndex = 18;
            this.correctButton2.UseVisualStyleBackColor = true;
            this.correctButton2.Click += new System.EventHandler(this.correctButton_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Image = global::SprutUpdate.Properties.Resources.Settings;
            this.commandButton2.Location = new System.Drawing.Point(267, 301);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(56, 45);
            this.commandButton2.TabIndex = 12;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // stopAutoUpdateButton2
            // 
            this.stopAutoUpdateButton2.Enabled = false;
            this.stopAutoUpdateButton2.Image = global::SprutUpdate.Properties.Resources.Player_Stop;
            this.stopAutoUpdateButton2.Location = new System.Drawing.Point(141, 301);
            this.stopAutoUpdateButton2.Name = "stopAutoUpdateButton2";
            this.stopAutoUpdateButton2.Size = new System.Drawing.Size(56, 45);
            this.stopAutoUpdateButton2.TabIndex = 7;
            this.stopAutoUpdateButton2.UseVisualStyleBackColor = true;
            this.stopAutoUpdateButton2.Click += new System.EventHandler(this.stopAutoUpdateButton_Click);
            // 
            // startAutoUpdateButton2
            // 
            this.startAutoUpdateButton2.Image = global::SprutUpdate.Properties.Resources.Play;
            this.startAutoUpdateButton2.Location = new System.Drawing.Point(78, 301);
            this.startAutoUpdateButton2.Name = "startAutoUpdateButton2";
            this.startAutoUpdateButton2.Size = new System.Drawing.Size(56, 45);
            this.startAutoUpdateButton2.TabIndex = 6;
            this.startAutoUpdateButton2.UseVisualStyleBackColor = true;
            this.startAutoUpdateButton2.Click += new System.EventHandler(this.startAutoUpdateButton_Click);
            // 
            // updateButton2
            // 
            this.updateButton2.Image = global::SprutUpdate.Properties.Resources.Player_Next;
            this.updateButton2.Location = new System.Drawing.Point(15, 301);
            this.updateButton2.Name = "updateButton2";
            this.updateButton2.Size = new System.Drawing.Size(56, 45);
            this.updateButton2.TabIndex = 5;
            this.updateButton2.UseVisualStyleBackColor = true;
            this.updateButton2.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // saveSettingsButton2
            // 
            this.saveSettingsButton2.Image = global::SprutUpdate.Properties.Resources.Save;
            this.saveSettingsButton2.Location = new System.Drawing.Point(204, 301);
            this.saveSettingsButton2.Name = "saveSettingsButton2";
            this.saveSettingsButton2.Size = new System.Drawing.Size(56, 45);
            this.saveSettingsButton2.TabIndex = 8;
            this.saveSettingsButton2.UseVisualStyleBackColor = true;
            this.saveSettingsButton2.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 436);
            this.Controls.Add(this.clearInterbaseButton2);
            this.Controls.Add(this.correctButton2);
            this.Controls.Add(this.intervalNumericUpDown);
            this.Controls.Add(this.intervalLabel);
            this.Controls.Add(this.freqComboBox);
            this.Controls.Add(this.freqLabel);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.NextUpdateTimeLabel);
            this.Controls.Add(this.stopAutoUpdateButton2);
            this.Controls.Add(this.startAutoUpdateButton2);
            this.Controls.Add(this.updateButton2);
            this.Controls.Add(this.updateNumbersCheckBox);
            this.Controls.Add(this.lastInckeySourceTextBox);
            this.Controls.Add(this.lastInckeySetupDownTextBox);
            this.Controls.Add(this.lastInckeySourceLabel);
            this.Controls.Add(this.lastInckeySetupDownLabel);
            this.Controls.Add(this.lastInckeyCheckBox);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.saveSettingsButton2);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "SprutUpdater 03.07.2021";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseDoubleClick);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label oracleSchemaLabel;
        private System.Windows.Forms.RadioButton oracleRadioButton;
        private System.Windows.Forms.RadioButton interbaseRadioButton;
        private System.Windows.Forms.Label interbaseServerLabel;
        private System.Windows.Forms.Label oracleServerLabel;
        private System.Windows.Forms.TextBox oracleServerTextBox;
        private System.Windows.Forms.TextBox interbaseServerTextBox;
        private System.Windows.Forms.Label interbasePathLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox oracleSchemaTextBox;
        private System.Windows.Forms.TextBox interbasePathTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button interbaseChangeFileButton;
        private System.Windows.Forms.OpenFileDialog interbaseOpenFileDialog;
        private System.Windows.Forms.Label sourcePathLabel;
        private System.Windows.Forms.Label sourceServerLabel;
        private System.Windows.Forms.CheckBox sourceCheckBox;
        private System.Windows.Forms.TextBox sourceServerTextBox;
        private System.Windows.Forms.TextBox sourcePathTextBox;
        private System.Windows.Forms.Button sourceChangeFileButton;
        private System.Windows.Forms.OpenFileDialog sourceOpenFileDialog;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel taskStatusLabel;
        private System.Windows.Forms.Button saveSettingsButton2;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton updateButton;
        private System.Windows.Forms.ToolStripButton startAutoUpdateButton;
        private System.Windows.Forms.ToolStripButton stopAutoUpdateButton;
        private System.Windows.Forms.ToolStripProgressBar taskProgressBar;
        private System.Windows.Forms.CheckBox lastInckeyCheckBox;
        private System.Windows.Forms.Label lastInckeySetupDownLabel;
        private System.Windows.Forms.Label lastInckeySourceLabel;
        private System.Windows.Forms.TextBox lastInckeySetupDownTextBox;
        private System.Windows.Forms.TextBox lastInckeySourceTextBox;
        private System.Windows.Forms.CheckBox updateNumbersCheckBox;
        private System.Windows.Forms.Button updateButton2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button startAutoUpdateButton2;
        private System.Windows.Forms.Button stopAutoUpdateButton2;
        private System.Windows.Forms.ToolStripButton saveSettingsButton;
        private System.Windows.Forms.Label NextUpdateTimeLabel;
        private System.Windows.Forms.ToolStripButton commandButton;
        private System.Windows.Forms.Button commandButton2;
        private System.Windows.Forms.Label freqLabel;
        private System.Windows.Forms.ComboBox freqComboBox;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.ToolStripButton correctButton;
        private System.Windows.Forms.Button correctButton2;
        private System.Windows.Forms.ToolStripButton clearInterbaseButton;
        private System.Windows.Forms.Button clearInterbaseButton2;
        private System.Windows.Forms.OpenFileDialog clearInterbaseOpenFileDialog;
    }
}

