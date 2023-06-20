namespace forD
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.schemaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inckeyTextBox = new System.Windows.Forms.TextBox();
            this.calcNumButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.postTextBox = new System.Windows.Forms.TextBox();
            this.forgetButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.infoAboutProcessRichTextBox = new System.Windows.Forms.RichTextBox();
            this.makeScriptButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.makeScriptFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.updateSMSButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.startPKCheckBox = new System.Windows.Forms.CheckBox();
            this.finishPKCheckBox = new System.Windows.Forms.CheckBox();
            this.startPKTextBox = new System.Windows.Forms.TextBox();
            this.finishPKTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.serverTextBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.schemaTextBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.inckeyTextBox, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.calcNumButton, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.postTextBox, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.forgetButton, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.passwordTextBox, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(849, 176);
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 35);
            this.label5.TabIndex = 6;
            this.label5.Text = "Пароль";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сервер";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Схема";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serverTextBox
            // 
            this.serverTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverTextBox.Location = new System.Drawing.Point(323, 3);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(223, 29);
            this.serverTextBox.TabIndex = 2;
            this.serverTextBox.Text = "sprutora7";
            // 
            // schemaTextBox
            // 
            this.schemaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schemaTextBox.Location = new System.Drawing.Point(323, 38);
            this.schemaTextBox.Name = "schemaTextBox";
            this.schemaTextBox.Size = new System.Drawing.Size(223, 29);
            this.schemaTextBox.TabIndex = 3;
            this.schemaTextBox.Text = "darray19";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 35);
            this.label4.TabIndex = 5;
            this.label4.Text = "Определить ключ последней записи";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inckeyTextBox
            // 
            this.inckeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inckeyTextBox.Enabled = false;
            this.inckeyTextBox.Location = new System.Drawing.Point(323, 108);
            this.inckeyTextBox.Name = "inckeyTextBox";
            this.inckeyTextBox.Size = new System.Drawing.Size(223, 29);
            this.inckeyTextBox.TabIndex = 6;
            this.inckeyTextBox.Text = "0";
            this.inckeyTextBox.DoubleClick += new System.EventHandler(this.inckeyTextBox_DoubleClick);
            // 
            // calcNumButton
            // 
            this.calcNumButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcNumButton.Location = new System.Drawing.Point(552, 108);
            this.calcNumButton.Name = "calcNumButton";
            this.calcNumButton.Size = new System.Drawing.Size(144, 29);
            this.calcNumButton.TabIndex = 7;
            this.calcNumButton.Text = "Определить";
            this.calcNumButton.UseVisualStyleBackColor = true;
            this.calcNumButton.Click += new System.EventHandler(this.calcNumButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 36);
            this.label3.TabIndex = 8;
            this.label3.Text = "Пост";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // postTextBox
            // 
            this.postTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postTextBox.Location = new System.Drawing.Point(323, 143);
            this.postTextBox.Name = "postTextBox";
            this.postTextBox.Size = new System.Drawing.Size(223, 29);
            this.postTextBox.TabIndex = 9;
            // 
            // forgetButton
            // 
            this.forgetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forgetButton.Location = new System.Drawing.Point(702, 108);
            this.forgetButton.Name = "forgetButton";
            this.forgetButton.Size = new System.Drawing.Size(144, 29);
            this.forgetButton.TabIndex = 10;
            this.forgetButton.Text = "Если забыл...";
            this.forgetButton.UseVisualStyleBackColor = true;
            this.forgetButton.Click += new System.EventHandler(this.forgetButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(323, 73);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(223, 29);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.Text = "masterkey";
            // 
            // infoAboutProcessRichTextBox
            // 
            this.infoAboutProcessRichTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoAboutProcessRichTextBox.Location = new System.Drawing.Point(7, 184);
            this.infoAboutProcessRichTextBox.Name = "infoAboutProcessRichTextBox";
            this.infoAboutProcessRichTextBox.Size = new System.Drawing.Size(689, 154);
            this.infoAboutProcessRichTextBox.TabIndex = 1;
            this.infoAboutProcessRichTextBox.Text = "";
            // 
            // makeScriptButton
            // 
            this.makeScriptButton.Location = new System.Drawing.Point(702, 184);
            this.makeScriptButton.Name = "makeScriptButton";
            this.makeScriptButton.Size = new System.Drawing.Size(142, 56);
            this.makeScriptButton.TabIndex = 2;
            this.makeScriptButton.Text = "Обработать";
            this.makeScriptButton.UseVisualStyleBackColor = true;
            this.makeScriptButton.Click += new System.EventHandler(this.makeScriptButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(7, 469);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(837, 33);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Удаление неправильно внесенных данных";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // makeScriptFileButton
            // 
            this.makeScriptFileButton.Location = new System.Drawing.Point(9, 344);
            this.makeScriptFileButton.Name = "makeScriptFileButton";
            this.makeScriptFileButton.Size = new System.Drawing.Size(835, 31);
            this.makeScriptFileButton.TabIndex = 4;
            this.makeScriptFileButton.Text = "Сгенерировать скрипт";
            this.makeScriptFileButton.UseVisualStyleBackColor = true;
            this.makeScriptFileButton.Click += new System.EventHandler(this.makeScriptFileButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Файл скрипта (*.sql)|*.sql";
            // 
            // updateSMSButton
            // 
            this.updateSMSButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateSMSButton.Location = new System.Drawing.Point(702, 246);
            this.updateSMSButton.Name = "updateSMSButton";
            this.updateSMSButton.Size = new System.Drawing.Size(142, 92);
            this.updateSMSButton.TabIndex = 5;
            this.updateSMSButton.Text = "Исправление собеседников из SMS";
            this.updateSMSButton.UseVisualStyleBackColor = true;
            this.updateSMSButton.Click += new System.EventHandler(this.updateSMSButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 396);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Удаление записей";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startPKCheckBox
            // 
            this.startPKCheckBox.AutoSize = true;
            this.startPKCheckBox.Checked = true;
            this.startPKCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startPKCheckBox.Location = new System.Drawing.Point(12, 429);
            this.startPKCheckBox.Name = "startPKCheckBox";
            this.startPKCheckBox.Size = new System.Drawing.Size(173, 25);
            this.startPKCheckBox.TabIndex = 8;
            this.startPKCheckBox.Text = "Начало диапазона";
            this.startPKCheckBox.UseVisualStyleBackColor = true;
            this.startPKCheckBox.CheckedChanged += new System.EventHandler(this.startPKCheckBox_CheckedChanged);
            // 
            // finishPKCheckBox
            // 
            this.finishPKCheckBox.AutoSize = true;
            this.finishPKCheckBox.Checked = true;
            this.finishPKCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.finishPKCheckBox.Location = new System.Drawing.Point(445, 429);
            this.finishPKCheckBox.Name = "finishPKCheckBox";
            this.finishPKCheckBox.Size = new System.Drawing.Size(166, 25);
            this.finishPKCheckBox.TabIndex = 9;
            this.finishPKCheckBox.Text = "Конец диапазона";
            this.finishPKCheckBox.UseVisualStyleBackColor = true;
            this.finishPKCheckBox.CheckedChanged += new System.EventHandler(this.finishPKCheckBox_CheckedChanged);
            // 
            // startPKTextBox
            // 
            this.startPKTextBox.Location = new System.Drawing.Point(191, 427);
            this.startPKTextBox.Name = "startPKTextBox";
            this.startPKTextBox.Size = new System.Drawing.Size(227, 29);
            this.startPKTextBox.TabIndex = 10;
            this.startPKTextBox.Text = "0";
            // 
            // finishPKTextBox
            // 
            this.finishPKTextBox.Location = new System.Drawing.Point(617, 427);
            this.finishPKTextBox.Name = "finishPKTextBox";
            this.finishPKTextBox.Size = new System.Drawing.Size(227, 29);
            this.finishPKTextBox.TabIndex = 11;
            this.finishPKTextBox.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 508);
            this.Controls.Add(this.finishPKTextBox);
            this.Controls.Add(this.startPKTextBox);
            this.Controls.Add(this.finishPKCheckBox);
            this.Controls.Add(this.startPKCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.updateSMSButton);
            this.Controls.Add(this.makeScriptFileButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.makeScriptButton);
            this.Controls.Add(this.infoAboutProcessRichTextBox);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Постобработка billing (v 2.0)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.TextBox schemaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inckeyTextBox;
        private System.Windows.Forms.Button calcNumButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox postTextBox;
        private System.Windows.Forms.RichTextBox infoAboutProcessRichTextBox;
        private System.Windows.Forms.Button makeScriptButton;
        private System.Windows.Forms.Button forgetButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button makeScriptFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button updateSMSButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox startPKCheckBox;
        private System.Windows.Forms.CheckBox finishPKCheckBox;
        private System.Windows.Forms.TextBox startPKTextBox;
        private System.Windows.Forms.TextBox finishPKTextBox;
    }
}

