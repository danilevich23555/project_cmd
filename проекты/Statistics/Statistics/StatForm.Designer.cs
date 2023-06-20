namespace Statistics
{
    partial class StatForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatForm));
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.finishDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.weekStatTypeСomboBox = new System.Windows.Forms.ComboBox();
            this.calculatButton = new System.Windows.Forms.Button();
            this.statGridView = new System.Windows.Forms.DataGridView();
            this.summaryTypeСomboBox = new System.Windows.Forms.ComboBox();
            this.weekRadioButton = new System.Windows.Forms.RadioButton();
            this.summaryRadioButton = new System.Windows.Forms.RadioButton();
            this.saveReportFile = new System.Windows.Forms.SaveFileDialog();
            this.saveReportButton = new System.Windows.Forms.Button();
            this.forOtdRadioButton = new System.Windows.Forms.RadioButton();
            this.forOtdComboBox = new System.Windows.Forms.ComboBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.forNaprRadioButton = new System.Windows.Forms.RadioButton();
            this.forNaprComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.statGridView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDateTimePicker.Location = new System.Drawing.Point(164, 3);
            this.startDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(184, 26);
            this.startDateTimePicker.TabIndex = 0;
            // 
            // finishDateTimePicker
            // 
            this.finishDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishDateTimePicker.Location = new System.Drawing.Point(485, 3);
            this.finishDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.finishDateTimePicker.Name = "finishDateTimePicker";
            this.finishDateTimePicker.Size = new System.Drawing.Size(181, 26);
            this.finishDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Начало периода";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(369, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Конец периода";
            // 
            // weekStatTypeСomboBox
            // 
            this.weekStatTypeСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weekStatTypeСomboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weekStatTypeСomboBox.FormattingEnabled = true;
            this.weekStatTypeСomboBox.Items.AddRange(new object[] {
            "Исходящие документы",
            "Статистика по справкам",
            "Статистика по материалам",
            "Статистика по пробивкам"});
            this.weekStatTypeСomboBox.Location = new System.Drawing.Point(164, 33);
            this.weekStatTypeСomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.weekStatTypeСomboBox.Name = "weekStatTypeСomboBox";
            this.weekStatTypeСomboBox.Size = new System.Drawing.Size(1229, 27);
            this.weekStatTypeСomboBox.TabIndex = 4;
            this.weekStatTypeСomboBox.SelectedIndexChanged += new System.EventHandler(this.statTypeСomboBox_SelectedIndexChanged);
            // 
            // calculatButton
            // 
            this.calculatButton.Enabled = false;
            this.calculatButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculatButton.Location = new System.Drawing.Point(15, 157);
            this.calculatButton.Margin = new System.Windows.Forms.Padding(2);
            this.calculatButton.Name = "calculatButton";
            this.calculatButton.Size = new System.Drawing.Size(103, 26);
            this.calculatButton.TabIndex = 6;
            this.calculatButton.Text = "Подсчитать";
            this.calculatButton.UseVisualStyleBackColor = true;
            this.calculatButton.Click += new System.EventHandler(this.calculatBeutton_Click);
            // 
            // statGridView
            // 
            this.statGridView.AllowUserToAddRows = false;
            this.statGridView.AllowUserToDeleteRows = false;
            this.statGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statGridView.Location = new System.Drawing.Point(12, 187);
            this.statGridView.Margin = new System.Windows.Forms.Padding(2);
            this.statGridView.MultiSelect = false;
            this.statGridView.Name = "statGridView";
            this.statGridView.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.statGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.statGridView.ShowCellErrors = false;
            this.statGridView.ShowCellToolTips = false;
            this.statGridView.ShowEditingIcon = false;
            this.statGridView.ShowRowErrors = false;
            this.statGridView.Size = new System.Drawing.Size(1385, 373);
            this.statGridView.TabIndex = 7;
            this.statGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.statGridView_CellMouseDown);
            // 
            // summaryTypeСomboBox
            // 
            this.summaryTypeСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.summaryTypeСomboBox.Enabled = false;
            this.summaryTypeСomboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summaryTypeСomboBox.FormattingEnabled = true;
            this.summaryTypeСomboBox.Items.AddRange(new object[] {
            "Количество аналитических справок по биллингам по пунктам плана",
            "Количество аналитических справок по биллингам по сотрудникам",
            "Количество аналитических справок по биллингам по тематикам",
            "Количество аналитических справок по биллингам по Управлениям",
            "Количество информаций/материалов/справок из командировок",
            "Количество материалов/информаций по пунктам плана",
            "Количество материалов/информаций по Управлениям",
            "Количество пробивок номеров по Управлениям",
            "Количество номеров в пробивках по Управлениям",
            "Количество найденых номеров в пробивках по Управлениям",
            "Количество найденых номеров в пробивках по странам",
            "Количество пробивок и номеров по статьям УК РФ",
            "Материалы анализа эффективности проведенных мероприятий"});
            this.summaryTypeСomboBox.Location = new System.Drawing.Point(164, 64);
            this.summaryTypeСomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.summaryTypeСomboBox.Name = "summaryTypeСomboBox";
            this.summaryTypeСomboBox.Size = new System.Drawing.Size(1229, 27);
            this.summaryTypeСomboBox.TabIndex = 8;
            this.summaryTypeСomboBox.SelectedIndexChanged += new System.EventHandler(this.summaryTypeСomboBox_SelectedIndexChanged);
            // 
            // weekRadioButton
            // 
            this.weekRadioButton.AutoSize = true;
            this.weekRadioButton.Checked = true;
            this.weekRadioButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weekRadioButton.Location = new System.Drawing.Point(14, 34);
            this.weekRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.weekRadioButton.Name = "weekRadioButton";
            this.weekRadioButton.Size = new System.Drawing.Size(104, 23);
            this.weekRadioButton.TabIndex = 9;
            this.weekRadioButton.TabStop = true;
            this.weekRadioButton.Text = "Для сводки";
            this.weekRadioButton.UseVisualStyleBackColor = true;
            this.weekRadioButton.CheckedChanged += new System.EventHandler(this.weekRadioButton_CheckedChanged);
            // 
            // summaryRadioButton
            // 
            this.summaryRadioButton.AutoSize = true;
            this.summaryRadioButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summaryRadioButton.Location = new System.Drawing.Point(15, 65);
            this.summaryRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.summaryRadioButton.Name = "summaryRadioButton";
            this.summaryRadioButton.Size = new System.Drawing.Size(103, 23);
            this.summaryRadioButton.TabIndex = 10;
            this.summaryRadioButton.Text = "Для итогов";
            this.summaryRadioButton.UseVisualStyleBackColor = true;
            this.summaryRadioButton.CheckedChanged += new System.EventHandler(this.summaryRadioButton_CheckedChanged);
            // 
            // saveReportFile
            // 
            this.saveReportFile.Filter = "TXT (разделители - табуляция)  (*.txt)|*.txt";
            // 
            // saveReportButton
            // 
            this.saveReportButton.Enabled = false;
            this.saveReportButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveReportButton.Image = global::Statistics.Properties.Resources.reportexcel;
            this.saveReportButton.Location = new System.Drawing.Point(164, 157);
            this.saveReportButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveReportButton.Name = "saveReportButton";
            this.saveReportButton.Size = new System.Drawing.Size(35, 26);
            this.saveReportButton.TabIndex = 11;
            this.saveReportButton.UseVisualStyleBackColor = true;
            this.saveReportButton.Click += new System.EventHandler(this.saveReportButton_Click);
            // 
            // forOtdRadioButton
            // 
            this.forOtdRadioButton.AutoSize = true;
            this.forOtdRadioButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forOtdRadioButton.Location = new System.Drawing.Point(15, 96);
            this.forOtdRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.forOtdRadioButton.Name = "forOtdRadioButton";
            this.forOtdRadioButton.Size = new System.Drawing.Size(127, 23);
            this.forOtdRadioButton.TabIndex = 13;
            this.forOtdRadioButton.Text = "Для отделения";
            this.forOtdRadioButton.UseVisualStyleBackColor = true;
            this.forOtdRadioButton.CheckedChanged += new System.EventHandler(this.forOtdRadioButton_CheckedChanged);
            // 
            // forOtdComboBox
            // 
            this.forOtdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.forOtdComboBox.Enabled = false;
            this.forOtdComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forOtdComboBox.FormattingEnabled = true;
            this.forOtdComboBox.Items.AddRange(new object[] {
            "Количество выявленных первичек по базовым станциям",
            "Количество выявленных первичек по постам",
            "Количество выявленных первичек по сотрудникам",
            "Реализованные первички"});
            this.forOtdComboBox.Location = new System.Drawing.Point(164, 95);
            this.forOtdComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.forOtdComboBox.Name = "forOtdComboBox";
            this.forOtdComboBox.Size = new System.Drawing.Size(1229, 27);
            this.forOtdComboBox.TabIndex = 12;
            this.forOtdComboBox.SelectedIndexChanged += new System.EventHandler(this.forOtdComboBox_SelectedIndexChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenu});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(149, 26);
            // 
            // editMenu
            // 
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(148, 22);
            this.editMenu.Text = "Просмотреть";
            this.editMenu.Click += new System.EventHandler(this.editMenu_Click);
            // 
            // forNaprRadioButton
            // 
            this.forNaprRadioButton.AutoSize = true;
            this.forNaprRadioButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forNaprRadioButton.Location = new System.Drawing.Point(15, 127);
            this.forNaprRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.forNaprRadioButton.Name = "forNaprRadioButton";
            this.forNaprRadioButton.Size = new System.Drawing.Size(145, 23);
            this.forNaprRadioButton.TabIndex = 15;
            this.forNaprRadioButton.Text = "Для направления";
            this.forNaprRadioButton.UseVisualStyleBackColor = true;
            this.forNaprRadioButton.CheckedChanged += new System.EventHandler(this.forNaprRadioButton_CheckedChanged);
            // 
            // forNaprComboBox
            // 
            this.forNaprComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.forNaprComboBox.Enabled = false;
            this.forNaprComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forNaprComboBox.FormattingEnabled = true;
            this.forNaprComboBox.Items.AddRange(new object[] {
            "Количество обработанных документов и номеров"});
            this.forNaprComboBox.Location = new System.Drawing.Point(164, 126);
            this.forNaprComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.forNaprComboBox.Name = "forNaprComboBox";
            this.forNaprComboBox.Size = new System.Drawing.Size(1229, 27);
            this.forNaprComboBox.TabIndex = 14;
            this.forNaprComboBox.SelectedIndexChanged += new System.EventHandler(this.forNaprComboBox_SelectedIndexChanged);
            // 
            // StatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 569);
            this.Controls.Add(this.forNaprRadioButton);
            this.Controls.Add(this.forNaprComboBox);
            this.Controls.Add(this.forOtdRadioButton);
            this.Controls.Add(this.forOtdComboBox);
            this.Controls.Add(this.saveReportButton);
            this.Controls.Add(this.summaryRadioButton);
            this.Controls.Add(this.weekRadioButton);
            this.Controls.Add(this.summaryTypeСomboBox);
            this.Controls.Add(this.statGridView);
            this.Controls.Add(this.calculatButton);
            this.Controls.Add(this.weekStatTypeСomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finishDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StatForm";
            this.Text = "Данные для сводки";
            ((System.ComponentModel.ISupportInitialize)(this.statGridView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker finishDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox weekStatTypeСomboBox;
        private System.Windows.Forms.Button calculatButton;
        private System.Windows.Forms.DataGridView statGridView;
        private System.Windows.Forms.ComboBox summaryTypeСomboBox;
        private System.Windows.Forms.RadioButton weekRadioButton;
        private System.Windows.Forms.RadioButton summaryRadioButton;
        private System.Windows.Forms.SaveFileDialog saveReportFile;
        private System.Windows.Forms.Button saveReportButton;
        private System.Windows.Forms.RadioButton forOtdRadioButton;
        private System.Windows.Forms.ComboBox forOtdComboBox;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.RadioButton forNaprRadioButton;
        private System.Windows.Forms.ComboBox forNaprComboBox;
    }
}