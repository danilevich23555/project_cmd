namespace Statistics
{
    partial class DateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateForm));
            this.label1 = new System.Windows.Forms.Label();
            this.conclutionReturnDate = new System.Windows.Forms.DateTimePicker();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата возврата заключения";
            // 
            // conclutionReturnDate
            // 
            this.conclutionReturnDate.Location = new System.Drawing.Point(208, 16);
            this.conclutionReturnDate.Margin = new System.Windows.Forms.Padding(4);
            this.conclutionReturnDate.Name = "conclutionReturnDate";
            this.conclutionReturnDate.Size = new System.Drawing.Size(168, 26);
            this.conclutionReturnDate.TabIndex = 1;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(17, 59);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(78, 27);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(298, 59);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(78, 27);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 99);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.conclutionReturnDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DateForm";
            this.Load += new System.EventHandler(this.DateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker conclutionReturnDate;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
    }
}