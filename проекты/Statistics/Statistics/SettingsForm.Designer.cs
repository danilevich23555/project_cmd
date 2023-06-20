namespace Statistics
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.databaseTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.sinceCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.autoConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(170, 12);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(414, 26);
            this.serverTextBox.TabIndex = 0;
            // 
            // databaseTextBox
            // 
            this.databaseTextBox.Location = new System.Drawing.Point(170, 44);
            this.databaseTextBox.Name = "databaseTextBox";
            this.databaseTextBox.Size = new System.Drawing.Size(414, 26);
            this.databaseTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сервер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "База данных";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(191, 76);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выводить данные с";
            // 
            // sinceCheckBox
            // 
            this.sinceCheckBox.AutoSize = true;
            this.sinceCheckBox.Location = new System.Drawing.Point(170, 85);
            this.sinceCheckBox.Name = "sinceCheckBox";
            this.sinceCheckBox.Size = new System.Drawing.Size(15, 14);
            this.sinceCheckBox.TabIndex = 6;
            this.sinceCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(170, 137);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 28);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(489, 137);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 28);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // autoConnectCheckBox
            // 
            this.autoConnectCheckBox.AutoSize = true;
            this.autoConnectCheckBox.Checked = true;
            this.autoConnectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoConnectCheckBox.Location = new System.Drawing.Point(170, 108);
            this.autoConnectCheckBox.Name = "autoConnectCheckBox";
            this.autoConnectCheckBox.Size = new System.Drawing.Size(331, 23);
            this.autoConnectCheckBox.TabIndex = 9;
            this.autoConnectCheckBox.Text = "Автоматическое подключение к базе данных";
            this.autoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 174);
            this.Controls.Add(this.autoConnectCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.sinceCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.databaseTextBox);
            this.Controls.Add(this.serverTextBox);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.TextBox databaseTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox sinceCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox autoConnectCheckBox;
    }
}