namespace SprutUpdate
{
    partial class SQLCommandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLCommandForm));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.finishPKTextBox = new System.Windows.Forms.TextBox();
            this.startPKTextBox = new System.Windows.Forms.TextBox();
            this.finishPKCheckBox = new System.Windows.Forms.CheckBox();
            this.startPKCheckBox = new System.Windows.Forms.CheckBox();
            this.ExecSQLButton = new System.Windows.Forms.Button();
            this.SQLCommandRichTextBox = new System.Windows.Forms.RichTextBox();
            this.infoAboutProcessRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.commandStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.serverLabel = new System.Windows.Forms.Label();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.schemaTextBox = new System.Windows.Forms.TextBox();
            this.schenaLabel = new System.Windows.Forms.Label();
            this.startInckeyButton = new System.Windows.Forms.Button();
            this.finishInckeyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Файл скрипта (*.sql)|*.sql";
            // 
            // finishPKTextBox
            // 
            this.finishPKTextBox.Location = new System.Drawing.Point(623, 406);
            this.finishPKTextBox.Name = "finishPKTextBox";
            this.finishPKTextBox.Size = new System.Drawing.Size(227, 29);
            this.finishPKTextBox.TabIndex = 16;
            this.finishPKTextBox.Text = "0";
            // 
            // startPKTextBox
            // 
            this.startPKTextBox.Location = new System.Drawing.Point(197, 406);
            this.startPKTextBox.Name = "startPKTextBox";
            this.startPKTextBox.Size = new System.Drawing.Size(227, 29);
            this.startPKTextBox.TabIndex = 15;
            this.startPKTextBox.Text = "0";
            // 
            // finishPKCheckBox
            // 
            this.finishPKCheckBox.AutoSize = true;
            this.finishPKCheckBox.Checked = true;
            this.finishPKCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.finishPKCheckBox.Location = new System.Drawing.Point(451, 408);
            this.finishPKCheckBox.Name = "finishPKCheckBox";
            this.finishPKCheckBox.Size = new System.Drawing.Size(166, 25);
            this.finishPKCheckBox.TabIndex = 14;
            this.finishPKCheckBox.Text = "Конец диапазона";
            this.finishPKCheckBox.UseVisualStyleBackColor = true;
            this.finishPKCheckBox.CheckedChanged += new System.EventHandler(this.finishPKCheckBox_CheckedChanged);
            // 
            // startPKCheckBox
            // 
            this.startPKCheckBox.AutoSize = true;
            this.startPKCheckBox.Checked = true;
            this.startPKCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startPKCheckBox.Location = new System.Drawing.Point(18, 408);
            this.startPKCheckBox.Name = "startPKCheckBox";
            this.startPKCheckBox.Size = new System.Drawing.Size(173, 25);
            this.startPKCheckBox.TabIndex = 13;
            this.startPKCheckBox.Text = "Начало диапазона";
            this.startPKCheckBox.UseVisualStyleBackColor = true;
            this.startPKCheckBox.CheckedChanged += new System.EventHandler(this.startPKCheckBox_CheckedChanged);
            // 
            // ExecSQLButton
            // 
            this.ExecSQLButton.Location = new System.Drawing.Point(11, 515);
            this.ExecSQLButton.Name = "ExecSQLButton";
            this.ExecSQLButton.Size = new System.Drawing.Size(836, 33);
            this.ExecSQLButton.TabIndex = 12;
            this.ExecSQLButton.Text = "Выполнить ";
            this.ExecSQLButton.UseVisualStyleBackColor = true;
            this.ExecSQLButton.Click += new System.EventHandler(this.ExecSQLButton_Click);
            // 
            // SQLCommandRichTextBox
            // 
            this.SQLCommandRichTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SQLCommandRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.SQLCommandRichTextBox.Name = "SQLCommandRichTextBox";
            this.SQLCommandRichTextBox.Size = new System.Drawing.Size(837, 203);
            this.SQLCommandRichTextBox.TabIndex = 17;
            this.SQLCommandRichTextBox.Text = "";
            // 
            // infoAboutProcessRichTextBox
            // 
            this.infoAboutProcessRichTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoAboutProcessRichTextBox.Location = new System.Drawing.Point(11, 221);
            this.infoAboutProcessRichTextBox.Name = "infoAboutProcessRichTextBox";
            this.infoAboutProcessRichTextBox.Size = new System.Drawing.Size(837, 111);
            this.infoAboutProcessRichTextBox.TabIndex = 18;
            this.infoAboutProcessRichTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 485);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 21);
            this.label5.TabIndex = 19;
            this.label5.Text = "Шаг выполнения запроса";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(237, 483);
            this.numericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown.TabIndex = 20;
            this.numericUpDown.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 548);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(860, 22);
            this.statusStrip.TabIndex = 21;
            this.statusStrip.Text = "statusStrip1";
            // 
            // commandStatusLabel
            // 
            this.commandStatusLabel.Name = "commandStatusLabel";
            this.commandStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // serverLabel
            // 
            this.serverLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(9, 341);
            this.serverLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(68, 21);
            this.serverLabel.TabIndex = 22;
            this.serverLabel.Text = "Сервер";
            this.serverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serverTextBox
            // 
            this.serverTextBox.Enabled = false;
            this.serverTextBox.Location = new System.Drawing.Point(85, 338);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(227, 29);
            this.serverTextBox.TabIndex = 23;
            // 
            // schemaTextBox
            // 
            this.schemaTextBox.Enabled = false;
            this.schemaTextBox.Location = new System.Drawing.Point(85, 373);
            this.schemaTextBox.Name = "schemaTextBox";
            this.schemaTextBox.Size = new System.Drawing.Size(227, 29);
            this.schemaTextBox.TabIndex = 25;
            // 
            // schenaLabel
            // 
            this.schenaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schenaLabel.AutoSize = true;
            this.schenaLabel.Location = new System.Drawing.Point(9, 380);
            this.schenaLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.schenaLabel.Name = "schenaLabel";
            this.schenaLabel.Size = new System.Drawing.Size(60, 21);
            this.schenaLabel.TabIndex = 24;
            this.schenaLabel.Text = "Схема";
            this.schenaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startInckeyButton
            // 
            this.startInckeyButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startInckeyButton.Location = new System.Drawing.Point(174, 439);
            this.startInckeyButton.Name = "startInckeyButton";
            this.startInckeyButton.Size = new System.Drawing.Size(250, 36);
            this.startInckeyButton.TabIndex = 26;
            this.startInckeyButton.Text = "Определить ключ первой записи";
            this.startInckeyButton.UseVisualStyleBackColor = true;
            this.startInckeyButton.Click += new System.EventHandler(this.startInckeyButton_Click);
            // 
            // finishInckeyButton
            // 
            this.finishInckeyButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishInckeyButton.Location = new System.Drawing.Point(580, 441);
            this.finishInckeyButton.Name = "finishInckeyButton";
            this.finishInckeyButton.Size = new System.Drawing.Size(270, 36);
            this.finishInckeyButton.TabIndex = 27;
            this.finishInckeyButton.Text = "Определить ключ последней записи";
            this.finishInckeyButton.UseVisualStyleBackColor = true;
            this.finishInckeyButton.Click += new System.EventHandler(this.finishInckeyButton_Click);
            // 
            // SQLCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 570);
            this.Controls.Add(this.finishInckeyButton);
            this.Controls.Add(this.startInckeyButton);
            this.Controls.Add(this.schemaTextBox);
            this.Controls.Add(this.schenaLabel);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.serverLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.infoAboutProcessRichTextBox);
            this.Controls.Add(this.SQLCommandRichTextBox);
            this.Controls.Add(this.finishPKTextBox);
            this.Controls.Add(this.startPKTextBox);
            this.Controls.Add(this.finishPKCheckBox);
            this.Controls.Add(this.startPKCheckBox);
            this.Controls.Add(this.ExecSQLButton);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SQLCommandForm";
            this.Text = "Выполнение SQL команды";
            this.Load += new System.EventHandler(this.SQLCommandForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox finishPKTextBox;
        private System.Windows.Forms.TextBox startPKTextBox;
        private System.Windows.Forms.CheckBox finishPKCheckBox;
        private System.Windows.Forms.CheckBox startPKCheckBox;
        private System.Windows.Forms.Button ExecSQLButton;
        private System.Windows.Forms.RichTextBox SQLCommandRichTextBox;
        private System.Windows.Forms.RichTextBox infoAboutProcessRichTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel commandStatusLabel;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.TextBox schemaTextBox;
        private System.Windows.Forms.Label schenaLabel;
        private System.Windows.Forms.Button startInckeyButton;
        private System.Windows.Forms.Button finishInckeyButton;
    }
}