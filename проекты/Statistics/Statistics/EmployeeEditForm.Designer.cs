namespace Statistics
{
    partial class EmployeeEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.patronymicTextBox = new System.Windows.Forms.TextBox();
            this.sectionComboBox = new System.Windows.Forms.ComboBox();
            this.subsectionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отдел";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Подразделение отдела";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(180, 72);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(346, 26);
            this.surnameTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(180, 104);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(346, 26);
            this.nameTextBox.TabIndex = 3;
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.Location = new System.Drawing.Point(180, 135);
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.Size = new System.Drawing.Size(346, 26);
            this.patronymicTextBox.TabIndex = 4;
            // 
            // sectionComboBox
            // 
            this.sectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionComboBox.FormattingEnabled = true;
            this.sectionComboBox.Location = new System.Drawing.Point(180, 6);
            this.sectionComboBox.Name = "sectionComboBox";
            this.sectionComboBox.Size = new System.Drawing.Size(346, 27);
            this.sectionComboBox.TabIndex = 0;
            this.sectionComboBox.SelectedIndexChanged += new System.EventHandler(this.sectionComboBox_SelectedIndexChanged);
            // 
            // subsectionComboBox
            // 
            this.subsectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subsectionComboBox.Enabled = false;
            this.subsectionComboBox.FormattingEnabled = true;
            this.subsectionComboBox.Location = new System.Drawing.Point(180, 39);
            this.subsectionComboBox.Name = "subsectionComboBox";
            this.subsectionComboBox.Size = new System.Drawing.Size(346, 27);
            this.subsectionComboBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Имя";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Отчество";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(421, 167);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 35);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(178, 167);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(105, 35);
            this.OKButton.TabIndex = 8;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // EmployeeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 218);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subsectionComboBox);
            this.Controls.Add(this.sectionComboBox);
            this.Controls.Add(this.patronymicTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "EmployeeEditForm";
            this.Load += new System.EventHandler(this.EmployeeEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.ComboBox sectionComboBox;
        private System.Windows.Forms.ComboBox subsectionComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}