namespace Statistics
{
    partial class InformationEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationEditForm));
            this.incomingDocumentsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addDepButton = new System.Windows.Forms.Button();
            this.addDirButton = new System.Windows.Forms.Button();
            this.depComboBox = new System.Windows.Forms.ComboBox();
            this.dirComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.themesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.commentaryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.emptyRadioButton = new System.Windows.Forms.RadioButton();
            this.existRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inRRadioButton = new System.Windows.Forms.RadioButton();
            this.initiatorRadioButton = new System.Windows.Forms.RadioButton();
            this.addIDButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.openFolder = new System.Windows.Forms.LinkLabel();
            this.informationFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.editLinkButton = new System.Windows.Forms.Button();
            this.wpComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.countriesComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.countNumbersUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countNumbersUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // incomingDocumentsCheckedListBox
            // 
            this.incomingDocumentsCheckedListBox.CheckOnClick = true;
            this.incomingDocumentsCheckedListBox.Enabled = false;
            this.incomingDocumentsCheckedListBox.FormattingEnabled = true;
            this.incomingDocumentsCheckedListBox.Location = new System.Drawing.Point(185, 75);
            this.incomingDocumentsCheckedListBox.Name = "incomingDocumentsCheckedListBox";
            this.incomingDocumentsCheckedListBox.Size = new System.Drawing.Size(831, 109);
            this.incomingDocumentsCheckedListBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(711, 730);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 35);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(175, 730);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(105, 35);
            this.OKButton.TabIndex = 33;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "Входящие документы";
            // 
            // addDepButton
            // 
            this.addDepButton.Enabled = false;
            this.addDepButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDepButton.Location = new System.Drawing.Point(1022, 42);
            this.addDepButton.Name = "addDepButton";
            this.addDepButton.Size = new System.Drawing.Size(75, 27);
            this.addDepButton.TabIndex = 41;
            this.addDepButton.Text = "Добавить";
            this.addDepButton.UseVisualStyleBackColor = true;
            this.addDepButton.Click += new System.EventHandler(this.addDepButton_Click);
            // 
            // addDirButton
            // 
            this.addDirButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDirButton.Location = new System.Drawing.Point(1022, 9);
            this.addDirButton.Name = "addDirButton";
            this.addDirButton.Size = new System.Drawing.Size(75, 27);
            this.addDirButton.TabIndex = 40;
            this.addDirButton.Text = "Добавить";
            this.addDirButton.UseVisualStyleBackColor = true;
            this.addDirButton.Click += new System.EventHandler(this.addDirButton_Click);
            // 
            // depComboBox
            // 
            this.depComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depComboBox.Enabled = false;
            this.depComboBox.FormattingEnabled = true;
            this.depComboBox.Location = new System.Drawing.Point(185, 42);
            this.depComboBox.Name = "depComboBox";
            this.depComboBox.Size = new System.Drawing.Size(831, 27);
            this.depComboBox.TabIndex = 39;
            this.depComboBox.SelectedIndexChanged += new System.EventHandler(this.depComboBox_SelectedIndexChanged);
            // 
            // dirComboBox
            // 
            this.dirComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dirComboBox.FormattingEnabled = true;
            this.dirComboBox.Location = new System.Drawing.Point(185, 9);
            this.dirComboBox.Name = "dirComboBox";
            this.dirComboBox.Size = new System.Drawing.Size(831, 27);
            this.dirComboBox.TabIndex = 38;
            this.dirComboBox.SelectedIndexChanged += new System.EventHandler(this.dirComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 37;
            this.label6.Text = "Управление";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "Служба";
            // 
            // themesComboBox
            // 
            this.themesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themesComboBox.FormattingEnabled = true;
            this.themesComboBox.Location = new System.Drawing.Point(185, 190);
            this.themesComboBox.Name = "themesComboBox";
            this.themesComboBox.Size = new System.Drawing.Size(831, 27);
            this.themesComboBox.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "Окраска";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(185, 289);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(831, 26);
            this.numberTextBox.TabIndex = 44;
            this.numberTextBox.Text = "12/Р/с2/3-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 45;
            this.label3.Text = "Подписной номер";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(185, 321);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 47;
            this.label4.Text = "Дата подписи";
            // 
            // commentaryRichTextBox
            // 
            this.commentaryRichTextBox.Location = new System.Drawing.Point(185, 353);
            this.commentaryRichTextBox.Name = "commentaryRichTextBox";
            this.commentaryRichTextBox.Size = new System.Drawing.Size(831, 124);
            this.commentaryRichTextBox.TabIndex = 48;
            this.commentaryRichTextBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 19);
            this.label7.TabIndex = 49;
            this.label7.Text = "Комментарий";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.emptyRadioButton);
            this.groupBox1.Controls.Add(this.existRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(185, 483);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 54);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результат";
            // 
            // emptyRadioButton
            // 
            this.emptyRadioButton.AutoSize = true;
            this.emptyRadioButton.Location = new System.Drawing.Point(225, 25);
            this.emptyRadioButton.Name = "emptyRadioButton";
            this.emptyRadioButton.Size = new System.Drawing.Size(196, 23);
            this.emptyRadioButton.TabIndex = 1;
            this.emptyRadioButton.TabStop = true;
            this.emptyRadioButton.Text = "Информация отсутствует";
            this.emptyRadioButton.UseVisualStyleBackColor = true;
            this.emptyRadioButton.CheckedChanged += new System.EventHandler(this.emptyRadioButton_CheckedChanged);
            // 
            // existRadioButton
            // 
            this.existRadioButton.AutoSize = true;
            this.existRadioButton.Location = new System.Drawing.Point(6, 25);
            this.existRadioButton.Name = "existRadioButton";
            this.existRadioButton.Size = new System.Drawing.Size(183, 23);
            this.existRadioButton.TabIndex = 0;
            this.existRadioButton.TabStop = true;
            this.existRadioButton.Text = "Выявлена информация";
            this.existRadioButton.UseVisualStyleBackColor = true;
            this.existRadioButton.CheckedChanged += new System.EventHandler(this.existRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inRRadioButton);
            this.groupBox2.Controls.Add(this.initiatorRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(185, 543);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 54);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ответ";
            // 
            // inRRadioButton
            // 
            this.inRRadioButton.AutoSize = true;
            this.inRRadioButton.Location = new System.Drawing.Point(225, 25);
            this.inRRadioButton.Name = "inRRadioButton";
            this.inRRadioButton.Size = new System.Drawing.Size(60, 23);
            this.inRRadioButton.TabIndex = 3;
            this.inRRadioButton.TabStop = true;
            this.inRRadioButton.Text = "В \"Р\"";
            this.inRRadioButton.UseVisualStyleBackColor = true;
            // 
            // initiatorRadioButton
            // 
            this.initiatorRadioButton.AutoSize = true;
            this.initiatorRadioButton.Location = new System.Drawing.Point(6, 25);
            this.initiatorRadioButton.Name = "initiatorRadioButton";
            this.initiatorRadioButton.Size = new System.Drawing.Size(111, 23);
            this.initiatorRadioButton.TabIndex = 2;
            this.initiatorRadioButton.TabStop = true;
            this.initiatorRadioButton.Text = "Инициатору";
            this.initiatorRadioButton.UseVisualStyleBackColor = true;
            // 
            // addIDButton
            // 
            this.addIDButton.Enabled = false;
            this.addIDButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addIDButton.Location = new System.Drawing.Point(1022, 75);
            this.addIDButton.Name = "addIDButton";
            this.addIDButton.Size = new System.Drawing.Size(75, 27);
            this.addIDButton.TabIndex = 52;
            this.addIDButton.Text = "Добавить";
            this.addIDButton.UseVisualStyleBackColor = true;
            this.addIDButton.Click += new System.EventHandler(this.addIDButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 647);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 19);
            this.label9.TabIndex = 54;
            this.label9.Text = "Папка с ответом";
            // 
            // openFolder
            // 
            this.openFolder.AutoSize = true;
            this.openFolder.Location = new System.Drawing.Point(12, 666);
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(0, 19);
            this.openFolder.TabIndex = 55;
            this.openFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openFolder_LinkClicked);
            // 
            // editLinkButton
            // 
            this.editLinkButton.Location = new System.Drawing.Point(16, 688);
            this.editLinkButton.Name = "editLinkButton";
            this.editLinkButton.Size = new System.Drawing.Size(149, 32);
            this.editLinkButton.TabIndex = 56;
            this.editLinkButton.Text = "Изменить ссылку";
            this.editLinkButton.UseVisualStyleBackColor = true;
            this.editLinkButton.Click += new System.EventHandler(this.editLinkButton_Click);
            // 
            // wpComboBox
            // 
            this.wpComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wpComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wpComboBox.FormattingEnabled = true;
            this.wpComboBox.Location = new System.Drawing.Point(185, 223);
            this.wpComboBox.Name = "wpComboBox";
            this.wpComboBox.Size = new System.Drawing.Size(831, 23);
            this.wpComboBox.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 19);
            this.label8.TabIndex = 57;
            this.label8.Text = "Пункт плана";
            // 
            // countriesComboBox
            // 
            this.countriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countriesComboBox.FormattingEnabled = true;
            this.countriesComboBox.Location = new System.Drawing.Point(185, 256);
            this.countriesComboBox.Name = "countriesComboBox";
            this.countriesComboBox.Size = new System.Drawing.Size(831, 27);
            this.countriesComboBox.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 19);
            this.label10.TabIndex = 59;
            this.label10.Text = "Страна";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 605);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 19);
            this.label11.TabIndex = 61;
            this.label11.Text = "Выявленных номеров";
            // 
            // countNumbersUpDown
            // 
            this.countNumbersUpDown.Location = new System.Drawing.Point(182, 603);
            this.countNumbersUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.countNumbersUpDown.Name = "countNumbersUpDown";
            this.countNumbersUpDown.Size = new System.Drawing.Size(120, 26);
            this.countNumbersUpDown.TabIndex = 62;
            this.countNumbersUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // InformationEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 786);
            this.Controls.Add(this.countNumbersUpDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.countriesComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.wpComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.editLinkButton);
            this.Controls.Add(this.openFolder);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.addIDButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.commentaryRichTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.themesComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addDepButton);
            this.Controls.Add(this.addDirButton);
            this.Controls.Add(this.depComboBox);
            this.Controls.Add(this.dirComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.incomingDocumentsCheckedListBox);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "InformationEditForm";
            this.Load += new System.EventHandler(this.InformationEditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countNumbersUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox incomingDocumentsCheckedListBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addDepButton;
        private System.Windows.Forms.Button addDirButton;
        private System.Windows.Forms.ComboBox depComboBox;
        private System.Windows.Forms.ComboBox dirComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox themesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox commentaryRichTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton emptyRadioButton;
        private System.Windows.Forms.RadioButton existRadioButton;
        private System.Windows.Forms.RadioButton inRRadioButton;
        private System.Windows.Forms.RadioButton initiatorRadioButton;
        private System.Windows.Forms.Button addIDButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel openFolder;
        private System.Windows.Forms.FolderBrowserDialog informationFolderBrowserDialog;
        private System.Windows.Forms.Button editLinkButton;
        private System.Windows.Forms.ComboBox wpComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox countriesComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown countNumbersUpDown;
    }
}