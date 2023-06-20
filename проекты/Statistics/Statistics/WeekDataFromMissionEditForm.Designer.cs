namespace Statistics
{
    partial class WeekDataFromMissionEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeekDataFromMissionEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.missionsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.informNumeric = new System.Windows.Forms.NumericUpDown();
            this.matNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.sprNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.addMissionButton = new System.Windows.Forms.Button();
            this.bearingNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.freqNumeric = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.voiceNumeric = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.informNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bearingNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(166, 12);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(174, 26);
            this.datePicker.TabIndex = 1;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Командировка";
            // 
            // missionsComboBox
            // 
            this.missionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.missionsComboBox.FormattingEnabled = true;
            this.missionsComboBox.Location = new System.Drawing.Point(166, 44);
            this.missionsComboBox.Name = "missionsComboBox";
            this.missionsComboBox.Size = new System.Drawing.Size(332, 27);
            this.missionsComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кол-во информаций";
            // 
            // informNumeric
            // 
            this.informNumeric.Location = new System.Drawing.Point(166, 77);
            this.informNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.informNumeric.Name = "informNumeric";
            this.informNumeric.Size = new System.Drawing.Size(120, 26);
            this.informNumeric.TabIndex = 7;
            // 
            // matNumeric
            // 
            this.matNumeric.Location = new System.Drawing.Point(166, 109);
            this.matNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.matNumeric.Name = "matNumeric";
            this.matNumeric.Size = new System.Drawing.Size(120, 26);
            this.matNumeric.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Кол-во материалов";
            // 
            // sprNumeric
            // 
            this.sprNumeric.Location = new System.Drawing.Point(166, 141);
            this.sprNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sprNumeric.Name = "sprNumeric";
            this.sprNumeric.Size = new System.Drawing.Size(120, 26);
            this.sprNumeric.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Кол-во справок";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(474, 267);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 35);
            this.cancelButton.TabIndex = 38;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(166, 267);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(105, 35);
            this.OKButton.TabIndex = 37;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // addMissionButton
            // 
            this.addMissionButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addMissionButton.Location = new System.Drawing.Point(504, 44);
            this.addMissionButton.Name = "addMissionButton";
            this.addMissionButton.Size = new System.Drawing.Size(75, 27);
            this.addMissionButton.TabIndex = 41;
            this.addMissionButton.Text = "Добавить";
            this.addMissionButton.UseVisualStyleBackColor = true;
            this.addMissionButton.Click += new System.EventHandler(this.addMissionButton_Click);
            // 
            // bearingNumeric
            // 
            this.bearingNumeric.Location = new System.Drawing.Point(166, 235);
            this.bearingNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bearingNumeric.Name = "bearingNumeric";
            this.bearingNumeric.Size = new System.Drawing.Size(120, 26);
            this.bearingNumeric.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 19);
            this.label6.TabIndex = 46;
            this.label6.Text = "Кол-во пеленгов";
            // 
            // freqNumeric
            // 
            this.freqNumeric.Location = new System.Drawing.Point(166, 203);
            this.freqNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freqNumeric.Name = "freqNumeric";
            this.freqNumeric.Size = new System.Drawing.Size(120, 26);
            this.freqNumeric.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 19);
            this.label7.TabIndex = 44;
            this.label7.Text = "Кол-во частот";
            // 
            // voiceNumeric
            // 
            this.voiceNumeric.Location = new System.Drawing.Point(166, 171);
            this.voiceNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.voiceNumeric.Name = "voiceNumeric";
            this.voiceNumeric.Size = new System.Drawing.Size(120, 26);
            this.voiceNumeric.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 19);
            this.label8.TabIndex = 42;
            this.label8.Text = "Кол-во источников";
            // 
            // WeekDataFromMissionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 315);
            this.Controls.Add(this.bearingNumeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.freqNumeric);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.voiceNumeric);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addMissionButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.sprNumeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.matNumeric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.informNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.missionsComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "WeekDataFromMissionEditForm";
            this.Load += new System.EventHandler(this.WeekDataFromMissionEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.informNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bearingNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox missionsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown informNumeric;
        private System.Windows.Forms.NumericUpDown matNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown sprNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button addMissionButton;
        private System.Windows.Forms.NumericUpDown bearingNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown freqNumeric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown voiceNumeric;
        private System.Windows.Forms.Label label8;
    }
}