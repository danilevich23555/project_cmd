namespace Statistics
{
    partial class IncomingDocumentsListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomingDocumentsListForm));
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.executeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.requeryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.prolongedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.delMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.filterTypeComboBox = new System.Windows.Forms.ComboBox();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(0, 41);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(1522, 437);
            this.dataGrid.TabIndex = 2;
            this.dataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_CellMouseDown);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenu,
            this.editMenu,
            this.executeMenu,
            this.requeryMenu,
            this.prolongedMenu,
            this.delMenu});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(144, 136);
            // 
            // addMenu
            // 
            this.addMenu.Name = "addMenu";
            this.addMenu.Size = new System.Drawing.Size(143, 22);
            this.addMenu.Text = "Добавить";
            this.addMenu.Click += new System.EventHandler(this.addMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(143, 22);
            this.editMenu.Text = "Изменить";
            this.editMenu.Click += new System.EventHandler(this.editMenu_Click);
            // 
            // executeMenu
            // 
            this.executeMenu.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executeMenu.Name = "executeMenu";
            this.executeMenu.Size = new System.Drawing.Size(143, 22);
            this.executeMenu.Text = "Исполнение";
            this.executeMenu.Click += new System.EventHandler(this.executeMenu_Click);
            // 
            // requeryMenu
            // 
            this.requeryMenu.Name = "requeryMenu";
            this.requeryMenu.Size = new System.Drawing.Size(143, 22);
            this.requeryMenu.Text = "Обновить";
            this.requeryMenu.Click += new System.EventHandler(this.requeryMenu_Click);
            // 
            // prolongedMenu
            // 
            this.prolongedMenu.Name = "prolongedMenu";
            this.prolongedMenu.Size = new System.Drawing.Size(143, 22);
            this.prolongedMenu.Text = "Продлить";
            this.prolongedMenu.Click += new System.EventHandler(this.prolongedMenu_Click);
            // 
            // delMenu
            // 
            this.delMenu.Name = "delMenu";
            this.delMenu.Size = new System.Drawing.Size(143, 22);
            this.delMenu.Text = "Удалить";
            this.delMenu.Click += new System.EventHandler(this.delMenu_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фильтр";
            // 
            // filterTypeComboBox
            // 
            this.filterTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterTypeComboBox.FormattingEnabled = true;
            this.filterTypeComboBox.Items.AddRange(new object[] {
            "По входящему номеру",
            "По ДОУ",
            "По исполнителю",
            "По комментарию",
            "По оперативнику",
            "По подписному номеру",
            "По стране",
            "По Управлению"});
            this.filterTypeComboBox.Location = new System.Drawing.Point(73, 3);
            this.filterTypeComboBox.Name = "filterTypeComboBox";
            this.filterTypeComboBox.Size = new System.Drawing.Size(411, 27);
            this.filterTypeComboBox.TabIndex = 5;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterTextBox.Location = new System.Drawing.Point(490, 3);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(828, 26);
            this.filterTextBox.TabIndex = 6;
            // 
            // filterButton
            // 
            this.filterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterButton.Location = new System.Drawing.Point(1324, 3);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(94, 27);
            this.filterButton.TabIndex = 7;
            this.filterButton.Text = "Применить";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(1424, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(95, 27);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel.Controls.Add(this.filterTypeComboBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.clearButton, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.filterTextBox, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.filterButton, 3, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1522, 33);
            this.tableLayoutPanel.TabIndex = 9;
            // 
            // IncomingDocumentsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 478);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.dataGrid);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IncomingDocumentsListForm";
            this.Text = "Входящие документы";
            this.Load += new System.EventHandler(this.IncomingDocumentsListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem addMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem requeryMenu;
        private System.Windows.Forms.ToolStripMenuItem delMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox filterTypeComboBox;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ToolStripMenuItem prolongedMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem executeMenu;
    }
}