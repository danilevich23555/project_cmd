namespace Statistics
{
    partial class MaterialEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.mDateTime = new System.Windows.Forms.DateTimePicker();
            this.mDuration = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mMobileOperatorComboBox = new System.Windows.Forms.ComboBox();
            this.mBaseStationTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mIMSITextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mIMEITextBox = new System.Windows.Forms.TextBox();
            this.mEmployeeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mTlkNumTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mAbnNumTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mPostTextBox = new System.Windows.Forms.TextBox();
            this.mCallTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.mServiceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.mMaterialStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.cleadMatStatusButton = new System.Windows.Forms.Button();
            this.addEmpButton = new System.Windows.Forms.Button();
            this.editEmpButton = new System.Windows.Forms.Button();
            this.fistCheckBox = new System.Windows.Forms.CheckBox();
            this.commentaryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unicodeRadioButton = new System.Windows.Forms.RadioButton();
            this.win1251RadioButton = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата и время";
            // 
            // mDateTime
            // 
            this.mDateTime.CustomFormat = "dd.MM.yy HH:mm:ss";
            this.mDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mDateTime.Location = new System.Drawing.Point(190, 14);
            this.mDateTime.Name = "mDateTime";
            this.mDateTime.Size = new System.Drawing.Size(260, 26);
            this.mDateTime.TabIndex = 0;
            // 
            // mDuration
            // 
            this.mDuration.CustomFormat = "";
            this.mDuration.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.mDuration.Location = new System.Drawing.Point(190, 46);
            this.mDuration.Name = "mDuration";
            this.mDuration.ShowUpDown = true;
            this.mDuration.Size = new System.Drawing.Size(260, 26);
            this.mDuration.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Длительность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Моб.оператор";
            // 
            // mMobileOperatorComboBox
            // 
            this.mMobileOperatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mMobileOperatorComboBox.FormattingEnabled = true;
            this.mMobileOperatorComboBox.Location = new System.Drawing.Point(190, 144);
            this.mMobileOperatorComboBox.Name = "mMobileOperatorComboBox";
            this.mMobileOperatorComboBox.Size = new System.Drawing.Size(260, 27);
            this.mMobileOperatorComboBox.TabIndex = 4;
            // 
            // mBaseStationTextBox
            // 
            this.mBaseStationTextBox.Location = new System.Drawing.Point(190, 177);
            this.mBaseStationTextBox.MaxLength = 50;
            this.mBaseStationTextBox.Name = "mBaseStationTextBox";
            this.mBaseStationTextBox.Size = new System.Drawing.Size(260, 26);
            this.mBaseStationTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Базовая станция";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "IMSI";
            // 
            // mIMSITextBox
            // 
            this.mIMSITextBox.Location = new System.Drawing.Point(190, 209);
            this.mIMSITextBox.MaxLength = 15;
            this.mIMSITextBox.Name = "mIMSITextBox";
            this.mIMSITextBox.Size = new System.Drawing.Size(260, 26);
            this.mIMSITextBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "IMEI";
            // 
            // mIMEITextBox
            // 
            this.mIMEITextBox.Location = new System.Drawing.Point(190, 241);
            this.mIMEITextBox.MaxLength = 14;
            this.mIMEITextBox.Name = "mIMEITextBox";
            this.mIMEITextBox.Size = new System.Drawing.Size(260, 26);
            this.mIMEITextBox.TabIndex = 7;
            // 
            // mEmployeeComboBox
            // 
            this.mEmployeeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mEmployeeComboBox.FormattingEnabled = true;
            this.mEmployeeComboBox.ItemHeight = 19;
            this.mEmployeeComboBox.Location = new System.Drawing.Point(191, 337);
            this.mEmployeeComboBox.Name = "mEmployeeComboBox";
            this.mEmployeeComboBox.Size = new System.Drawing.Size(260, 27);
            this.mEmployeeComboBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Сотрудник";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Собеседник";
            // 
            // mTlkNumTextBox
            // 
            this.mTlkNumTextBox.Location = new System.Drawing.Point(191, 305);
            this.mTlkNumTextBox.MaxLength = 50;
            this.mTlkNumTextBox.Name = "mTlkNumTextBox";
            this.mTlkNumTextBox.Size = new System.Drawing.Size(260, 26);
            this.mTlkNumTextBox.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Абонент";
            // 
            // mAbnNumTextBox
            // 
            this.mAbnNumTextBox.Location = new System.Drawing.Point(191, 273);
            this.mAbnNumTextBox.MaxLength = 50;
            this.mAbnNumTextBox.Name = "mAbnNumTextBox";
            this.mAbnNumTextBox.Size = new System.Drawing.Size(260, 26);
            this.mAbnNumTextBox.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "Пост";
            // 
            // mPostTextBox
            // 
            this.mPostTextBox.Location = new System.Drawing.Point(191, 370);
            this.mPostTextBox.MaxLength = 40;
            this.mPostTextBox.Name = "mPostTextBox";
            this.mPostTextBox.Size = new System.Drawing.Size(260, 26);
            this.mPostTextBox.TabIndex = 12;
            // 
            // mCallTypeComboBox
            // 
            this.mCallTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mCallTypeComboBox.FormattingEnabled = true;
            this.mCallTypeComboBox.Location = new System.Drawing.Point(190, 111);
            this.mCallTypeComboBox.Name = "mCallTypeComboBox";
            this.mCallTypeComboBox.Size = new System.Drawing.Size(260, 27);
            this.mCallTypeComboBox.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 19);
            this.label11.TabIndex = 20;
            this.label11.Text = "Тип услуги";
            // 
            // mServiceTypeComboBox
            // 
            this.mServiceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mServiceTypeComboBox.FormattingEnabled = true;
            this.mServiceTypeComboBox.Location = new System.Drawing.Point(190, 78);
            this.mServiceTypeComboBox.Name = "mServiceTypeComboBox";
            this.mServiceTypeComboBox.Size = new System.Drawing.Size(260, 27);
            this.mServiceTypeComboBox.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 19);
            this.label12.TabIndex = 22;
            this.label12.Text = "Тип вызова";
            // 
            // mMaterialStatusComboBox
            // 
            this.mMaterialStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mMaterialStatusComboBox.FormattingEnabled = true;
            this.mMaterialStatusComboBox.Location = new System.Drawing.Point(191, 402);
            this.mMaterialStatusComboBox.Name = "mMaterialStatusComboBox";
            this.mMaterialStatusComboBox.Size = new System.Drawing.Size(260, 27);
            this.mMaterialStatusComboBox.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 405);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 19);
            this.label13.TabIndex = 24;
            this.label13.Text = "Статус информации";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(190, 649);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(87, 28);
            this.OKButton.TabIndex = 15;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(363, 649);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 28);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // cleadMatStatusButton
            // 
            this.cleadMatStatusButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cleadMatStatusButton.Location = new System.Drawing.Point(457, 403);
            this.cleadMatStatusButton.Name = "cleadMatStatusButton";
            this.cleadMatStatusButton.Size = new System.Drawing.Size(72, 23);
            this.cleadMatStatusButton.TabIndex = 14;
            this.cleadMatStatusButton.Text = "Очистить";
            this.cleadMatStatusButton.UseVisualStyleBackColor = true;
            this.cleadMatStatusButton.Click += new System.EventHandler(this.cleadMatStatusButton_Click);
            // 
            // addEmpButton
            // 
            this.addEmpButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addEmpButton.Location = new System.Drawing.Point(457, 339);
            this.addEmpButton.Name = "addEmpButton";
            this.addEmpButton.Size = new System.Drawing.Size(72, 23);
            this.addEmpButton.TabIndex = 11;
            this.addEmpButton.Text = "Добавить";
            this.addEmpButton.UseVisualStyleBackColor = true;
            this.addEmpButton.Click += new System.EventHandler(this.addEmpButton_Click);
            // 
            // editEmpButton
            // 
            this.editEmpButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editEmpButton.Location = new System.Drawing.Point(535, 339);
            this.editEmpButton.Name = "editEmpButton";
            this.editEmpButton.Size = new System.Drawing.Size(72, 23);
            this.editEmpButton.TabIndex = 25;
            this.editEmpButton.Text = "Изменить";
            this.editEmpButton.UseVisualStyleBackColor = true;
            this.editEmpButton.Click += new System.EventHandler(this.editEmpButton_Click);
            // 
            // fistCheckBox
            // 
            this.fistCheckBox.AutoSize = true;
            this.fistCheckBox.Location = new System.Drawing.Point(191, 435);
            this.fistCheckBox.Name = "fistCheckBox";
            this.fistCheckBox.Size = new System.Drawing.Size(181, 23);
            this.fistCheckBox.TabIndex = 26;
            this.fistCheckBox.Text = "Первичное выявление";
            this.fistCheckBox.UseVisualStyleBackColor = true;
            // 
            // commentaryRichTextBox
            // 
            this.commentaryRichTextBox.Location = new System.Drawing.Point(190, 464);
            this.commentaryRichTextBox.Name = "commentaryRichTextBox";
            this.commentaryRichTextBox.Size = new System.Drawing.Size(414, 123);
            this.commentaryRichTextBox.TabIndex = 27;
            this.commentaryRichTextBox.Text = "";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 467);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(103, 19);
            this.label.TabIndex = 28;
            this.label.Text = "Комментарий";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt";
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton.Location = new System.Drawing.Point(328, 18);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(81, 26);
            this.loadButton.TabIndex = 29;
            this.loadButton.Text = "Подгрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.win1251RadioButton);
            this.groupBox1.Controls.Add(this.loadButton);
            this.groupBox1.Controls.Add(this.unicodeRadioButton);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(190, 593);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 50);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заполнить поля из файла внешнего экспорта";
            // 
            // unicodeRadioButton
            // 
            this.unicodeRadioButton.AutoSize = true;
            this.unicodeRadioButton.Checked = true;
            this.unicodeRadioButton.Location = new System.Drawing.Point(136, 21);
            this.unicodeRadioButton.Name = "unicodeRadioButton";
            this.unicodeRadioButton.Size = new System.Drawing.Size(70, 19);
            this.unicodeRadioButton.TabIndex = 0;
            this.unicodeRadioButton.TabStop = true;
            this.unicodeRadioButton.Text = "Unicode";
            this.unicodeRadioButton.UseVisualStyleBackColor = true;
            // 
            // win1251RadioButton
            // 
            this.win1251RadioButton.AutoSize = true;
            this.win1251RadioButton.Location = new System.Drawing.Point(220, 21);
            this.win1251RadioButton.Name = "win1251RadioButton";
            this.win1251RadioButton.Size = new System.Drawing.Size(75, 19);
            this.win1251RadioButton.TabIndex = 1;
            this.win1251RadioButton.Text = "Win-1251";
            this.win1251RadioButton.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 15);
            this.label14.TabIndex = 31;
            this.label14.Text = "Кодировка файла";
            // 
            // MaterialEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 689);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.commentaryRichTextBox);
            this.Controls.Add(this.fistCheckBox);
            this.Controls.Add(this.editEmpButton);
            this.Controls.Add(this.addEmpButton);
            this.Controls.Add(this.cleadMatStatusButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.mMaterialStatusComboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.mServiceTypeComboBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.mCallTypeComboBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mPostTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mTlkNumTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mAbnNumTextBox);
            this.Controls.Add(this.mEmployeeComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mIMEITextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mIMSITextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mBaseStationTextBox);
            this.Controls.Add(this.mMobileOperatorComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mDateTime);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MaterialEditForm";
            this.Text = "Информация";
            this.Load += new System.EventHandler(this.MaterialEditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker mDateTime;
        private System.Windows.Forms.DateTimePicker mDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox mMobileOperatorComboBox;
        private System.Windows.Forms.TextBox mBaseStationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mIMSITextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mIMEITextBox;
        private System.Windows.Forms.ComboBox mEmployeeComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mTlkNumTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mAbnNumTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox mPostTextBox;
        private System.Windows.Forms.ComboBox mCallTypeComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox mServiceTypeComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox mMaterialStatusComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button cleadMatStatusButton;
        private System.Windows.Forms.Button addEmpButton;
        private System.Windows.Forms.Button editEmpButton;
        private System.Windows.Forms.CheckBox fistCheckBox;
        private System.Windows.Forms.RichTextBox commentaryRichTextBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton win1251RadioButton;
        private System.Windows.Forms.RadioButton unicodeRadioButton;
    }
}