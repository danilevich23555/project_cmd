namespace Statistics
{
    partial class MissionEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissionEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.missionTargetComboBox = new System.Windows.Forms.ComboBox();
            this.empComboBox = new System.Windows.Forms.ComboBox();
            this.startMissionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.countDaysNumeric = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.clearEmpButton = new System.Windows.Forms.Button();
            this.addEmpButton = new System.Windows.Forms.Button();
            this.only3NaprCheckBox = new System.Windows.Forms.CheckBox();
            this.addTargetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.countDaysNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Место командирования";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сотрудник";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата начала командирования";
            // 
            // missionTargetComboBox
            // 
            this.missionTargetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.missionTargetComboBox.FormattingEnabled = true;
            this.missionTargetComboBox.Location = new System.Drawing.Point(235, 6);
            this.missionTargetComboBox.Name = "missionTargetComboBox";
            this.missionTargetComboBox.Size = new System.Drawing.Size(331, 27);
            this.missionTargetComboBox.TabIndex = 3;
            // 
            // empComboBox
            // 
            this.empComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empComboBox.FormattingEnabled = true;
            this.empComboBox.Location = new System.Drawing.Point(235, 39);
            this.empComboBox.Name = "empComboBox";
            this.empComboBox.Size = new System.Drawing.Size(331, 27);
            this.empComboBox.TabIndex = 4;
            // 
            // startMissionDatePicker
            // 
            this.startMissionDatePicker.Location = new System.Drawing.Point(235, 72);
            this.startMissionDatePicker.Name = "startMissionDatePicker";
            this.startMissionDatePicker.Size = new System.Drawing.Size(200, 26);
            this.startMissionDatePicker.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Кол-во суток командирования";
            // 
            // countDaysNumeric
            // 
            this.countDaysNumeric.Location = new System.Drawing.Point(235, 104);
            this.countDaysNumeric.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.countDaysNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countDaysNumeric.Name = "countDaysNumeric";
            this.countDaysNumeric.Size = new System.Drawing.Size(71, 26);
            this.countDaysNumeric.TabIndex = 7;
            this.countDaysNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(461, 136);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 35);
            this.cancelButton.TabIndex = 36;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(235, 136);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(105, 35);
            this.OKButton.TabIndex = 35;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // clearEmpButton
            // 
            this.clearEmpButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearEmpButton.Location = new System.Drawing.Point(572, 39);
            this.clearEmpButton.Name = "clearEmpButton";
            this.clearEmpButton.Size = new System.Drawing.Size(75, 27);
            this.clearEmpButton.TabIndex = 37;
            this.clearEmpButton.Text = "Очистить";
            this.clearEmpButton.UseVisualStyleBackColor = true;
            this.clearEmpButton.Click += new System.EventHandler(this.clearEmpButton_Click);
            // 
            // addEmpButton
            // 
            this.addEmpButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addEmpButton.Location = new System.Drawing.Point(653, 39);
            this.addEmpButton.Name = "addEmpButton";
            this.addEmpButton.Size = new System.Drawing.Size(75, 27);
            this.addEmpButton.TabIndex = 38;
            this.addEmpButton.Text = "Добавить";
            this.addEmpButton.UseVisualStyleBackColor = true;
            this.addEmpButton.Click += new System.EventHandler(this.addEmpButton_Click);
            // 
            // only3NaprCheckBox
            // 
            this.only3NaprCheckBox.AutoSize = true;
            this.only3NaprCheckBox.Checked = true;
            this.only3NaprCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.only3NaprCheckBox.Location = new System.Drawing.Point(100, 42);
            this.only3NaprCheckBox.Name = "only3NaprCheckBox";
            this.only3NaprCheckBox.Size = new System.Drawing.Size(128, 23);
            this.only3NaprCheckBox.TabIndex = 39;
            this.only3NaprCheckBox.Text = "3 направление";
            this.only3NaprCheckBox.UseVisualStyleBackColor = true;
            this.only3NaprCheckBox.CheckedChanged += new System.EventHandler(this.only3NaprCheckBox_CheckedChanged);
            // 
            // addTargetButton
            // 
            this.addTargetButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTargetButton.Location = new System.Drawing.Point(572, 6);
            this.addTargetButton.Name = "addTargetButton";
            this.addTargetButton.Size = new System.Drawing.Size(75, 27);
            this.addTargetButton.TabIndex = 40;
            this.addTargetButton.Text = "Добавить";
            this.addTargetButton.UseVisualStyleBackColor = true;
            this.addTargetButton.Click += new System.EventHandler(this.addTargetButton_Click);
            // 
            // MissionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 191);
            this.Controls.Add(this.addTargetButton);
            this.Controls.Add(this.only3NaprCheckBox);
            this.Controls.Add(this.addEmpButton);
            this.Controls.Add(this.clearEmpButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.countDaysNumeric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startMissionDatePicker);
            this.Controls.Add(this.empComboBox);
            this.Controls.Add(this.missionTargetComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MissionEditForm";
            this.Text = "Командировка";
            this.Load += new System.EventHandler(this.MissionEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.countDaysNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox missionTargetComboBox;
        private System.Windows.Forms.ComboBox empComboBox;
        private System.Windows.Forms.DateTimePicker startMissionDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown countDaysNumeric;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button clearEmpButton;
        private System.Windows.Forms.Button addEmpButton;
        private System.Windows.Forms.CheckBox only3NaprCheckBox;
        private System.Windows.Forms.Button addTargetButton;

    }
}