namespace Statistics
{
    partial class UKRFEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UKRFEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ukNumberTextBox = new System.Windows.Forms.TextBox();
            this.ukCaptionTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер статьи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Заголовок";
            // 
            // ukNumberTextBox
            // 
            this.ukNumberTextBox.Location = new System.Drawing.Point(167, 6);
            this.ukNumberTextBox.Name = "ukNumberTextBox";
            this.ukNumberTextBox.Size = new System.Drawing.Size(554, 26);
            this.ukNumberTextBox.TabIndex = 2;
            // 
            // ukCaptionTextBox
            // 
            this.ukCaptionTextBox.Location = new System.Drawing.Point(167, 38);
            this.ukCaptionTextBox.Multiline = true;
            this.ukCaptionTextBox.Name = "ukCaptionTextBox";
            this.ukCaptionTextBox.Size = new System.Drawing.Size(554, 146);
            this.ukCaptionTextBox.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(616, 190);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 35);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(167, 190);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(105, 35);
            this.OKButton.TabIndex = 16;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // UKRFEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 236);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ukCaptionTextBox);
            this.Controls.Add(this.ukNumberTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "UKRFEditForm";
            this.Load += new System.EventHandler(this.UKRFEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ukNumberTextBox;
        private System.Windows.Forms.TextBox ukCaptionTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}