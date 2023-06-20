namespace forD
{
    partial class DeleteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteForm));
            this.smsCheckBox = new System.Windows.Forms.CheckBox();
            this.billingCheckBox = new System.Windows.Forms.CheckBox();
            this.IMEICheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.schemaLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.postLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.makeDeleteScriptButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // smsCheckBox
            // 
            this.smsCheckBox.AutoSize = true;
            this.smsCheckBox.Location = new System.Drawing.Point(345, 73);
            this.smsCheckBox.Name = "smsCheckBox";
            this.smsCheckBox.Size = new System.Drawing.Size(67, 25);
            this.smsCheckBox.TabIndex = 1;
            this.smsCheckBox.Text = "SMS";
            this.smsCheckBox.UseVisualStyleBackColor = true;
            // 
            // billingCheckBox
            // 
            this.billingCheckBox.AutoSize = true;
            this.billingCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billingCheckBox.Location = new System.Drawing.Point(3, 73);
            this.billingCheckBox.Name = "billingCheckBox";
            this.billingCheckBox.Size = new System.Drawing.Size(165, 29);
            this.billingCheckBox.TabIndex = 2;
            this.billingCheckBox.Text = "Billing";
            this.billingCheckBox.UseVisualStyleBackColor = true;
            // 
            // IMEICheckBox
            // 
            this.IMEICheckBox.AutoSize = true;
            this.IMEICheckBox.Location = new System.Drawing.Point(174, 73);
            this.IMEICheckBox.Name = "IMEICheckBox";
            this.IMEICheckBox.Size = new System.Drawing.Size(68, 25);
            this.IMEICheckBox.TabIndex = 3;
            this.IMEICheckBox.Text = "IMEI";
            this.IMEICheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.Controls.Add(this.schemaLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.smsCheckBox, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.IMEICheckBox, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.serverLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.billingCheckBox, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.postLabel, 2, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(514, 104);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // schemaLabel
            // 
            this.schemaLabel.AutoSize = true;
            this.schemaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schemaLabel.Location = new System.Drawing.Point(174, 35);
            this.schemaLabel.Name = "schemaLabel";
            this.schemaLabel.Size = new System.Drawing.Size(165, 35);
            this.schemaLabel.TabIndex = 4;
            this.schemaLabel.Text = "label5";
            this.schemaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverLabel.Location = new System.Drawing.Point(3, 35);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(165, 35);
            this.serverLabel.TabIndex = 3;
            this.serverLabel.Text = "label4";
            this.serverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(345, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пост";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(174, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Схема";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сервер";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // postLabel
            // 
            this.postLabel.AutoSize = true;
            this.postLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postLabel.Location = new System.Drawing.Point(345, 35);
            this.postLabel.Name = "postLabel";
            this.postLabel.Size = new System.Drawing.Size(166, 35);
            this.postLabel.TabIndex = 5;
            this.postLabel.Text = "label6";
            this.postLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(0, 110);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(514, 30);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // makeDeleteScriptButton
            // 
            this.makeDeleteScriptButton.Location = new System.Drawing.Point(0, 146);
            this.makeDeleteScriptButton.Name = "makeDeleteScriptButton";
            this.makeDeleteScriptButton.Size = new System.Drawing.Size(514, 30);
            this.makeDeleteScriptButton.TabIndex = 6;
            this.makeDeleteScriptButton.Text = "Сгенерировать скрипт";
            this.makeDeleteScriptButton.UseVisualStyleBackColor = true;
            this.makeDeleteScriptButton.Click += new System.EventHandler(this.makeDeleteScriptButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Файл скрипта (*.sql)|*.sql";
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 184);
            this.Controls.Add(this.makeDeleteScriptButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DeleteForm";
            this.Text = "Удаление данных";
            this.Load += new System.EventHandler(this.DeleteForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox smsCheckBox;
        private System.Windows.Forms.CheckBox billingCheckBox;
        private System.Windows.Forms.CheckBox IMEICheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label schemaLabel;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label postLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button makeDeleteScriptButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}