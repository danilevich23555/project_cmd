namespace Statistics
{
    partial class DepartmentEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.directionСomboBox = new System.Windows.Forms.ComboBox();
            this.departmentsTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Служба";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Управление";
            // 
            // directionСomboBox
            // 
            this.directionСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionСomboBox.FormattingEnabled = true;
            this.directionСomboBox.Location = new System.Drawing.Point(116, 12);
            this.directionСomboBox.Name = "directionСomboBox";
            this.directionСomboBox.Size = new System.Drawing.Size(534, 27);
            this.directionСomboBox.TabIndex = 2;
            this.directionСomboBox.SelectedIndexChanged += new System.EventHandler(this.directionСomboBox_SelectedIndexChanged);
            // 
            // departmentsTextBox
            // 
            this.departmentsTextBox.Enabled = false;
            this.departmentsTextBox.Location = new System.Drawing.Point(116, 45);
            this.departmentsTextBox.Name = "departmentsTextBox";
            this.departmentsTextBox.Size = new System.Drawing.Size(534, 26);
            this.departmentsTextBox.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(545, 77);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 35);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(116, 77);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(105, 35);
            this.OKButton.TabIndex = 4;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DepartmentsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 125);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.departmentsTextBox);
            this.Controls.Add(this.directionСomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "DepartmentsEditForm";
            this.Load += new System.EventHandler(this.DepartmentsEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox directionСomboBox;
        private System.Windows.Forms.TextBox departmentsTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}