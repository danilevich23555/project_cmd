namespace search_sar
{
    partial class Form2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnupdate1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(342, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "введите ID объекта, данные которого необходимо изменить";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 52);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(342, 59);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "введите данные для измениния";
            // 
            // btnupdate1
            // 
            this.btnupdate1.Location = new System.Drawing.Point(382, 12);
            this.btnupdate1.Name = "btnupdate1";
            this.btnupdate1.Size = new System.Drawing.Size(139, 32);
            this.btnupdate1.TabIndex = 2;
            this.btnupdate1.Text = "внести изменения в БД";
            this.btnupdate1.UseVisualStyleBackColor = true;
            this.btnupdate1.Click += new System.EventHandler(this.btnupdate1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 123);
            this.Controls.Add(this.btnupdate1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnupdate1;

    }
}