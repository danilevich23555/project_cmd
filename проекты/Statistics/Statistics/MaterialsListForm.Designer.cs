namespace Statistics
{
    partial class MaterialsListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialsListForm));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.requeryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.delMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.clearButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.themesComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenu,
            this.editMenu,
            this.informationToolMenu,
            this.requeryMenu,
            this.delMenu});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(149, 114);
            // 
            // addMenu
            // 
            this.addMenu.Name = "addMenu";
            this.addMenu.Size = new System.Drawing.Size(148, 22);
            this.addMenu.Text = "Добавить";
            this.addMenu.Click += new System.EventHandler(this.addMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(148, 22);
            this.editMenu.Text = "Изменить";
            this.editMenu.Click += new System.EventHandler(this.editMenu_Click);
            // 
            // informationToolMenu
            // 
            this.informationToolMenu.Name = "informationToolMenu";
            this.informationToolMenu.Size = new System.Drawing.Size(148, 22);
            this.informationToolMenu.Text = "Информация";
            this.informationToolMenu.Click += new System.EventHandler(this.informationToolMenu_Click);
            // 
            // requeryMenu
            // 
            this.requeryMenu.Name = "requeryMenu";
            this.requeryMenu.Size = new System.Drawing.Size(148, 22);
            this.requeryMenu.Text = "Обновить";
            this.requeryMenu.Click += new System.EventHandler(this.requeryMenu_Click);
            // 
            // delMenu
            // 
            this.delMenu.Name = "delMenu";
            this.delMenu.Size = new System.Drawing.Size(148, 22);
            this.delMenu.Text = "Удалить";
            this.delMenu.Click += new System.EventHandler(this.delMenu_Click);
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
            this.dataGrid.ContextMenuStrip = this.contextMenu;
            this.dataGrid.Location = new System.Drawing.Point(0, 74);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(1309, 378);
            this.dataGrid.TabIndex = 3;
            this.dataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_CellMouseDown);
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(1221, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(85, 24);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterButton.Location = new System.Drawing.Point(1123, 3);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(92, 24);
            this.filterButton.TabIndex = 12;
            this.filterButton.Text = "Применить";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterTextBox.Location = new System.Drawing.Point(415, 3);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(702, 22);
            this.filterTextBox.TabIndex = 11;
            // 
            // filterTypeComboBox
            // 
            this.filterTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterTypeComboBox.FormattingEnabled = true;
            this.filterTypeComboBox.Items.AddRange(new object[] {
            "По IMEI",
            "По IMSI",
            "По абоненту",
            "По базовой станции",
            "По посту",
            "По собеседнику",
            "По сотруднику"});
            this.filterTypeComboBox.Location = new System.Drawing.Point(61, 3);
            this.filterTypeComboBox.Name = "filterTypeComboBox";
            this.filterTypeComboBox.Size = new System.Drawing.Size(348, 23);
            this.filterTypeComboBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Фильтр";
            // 
            // themesComboBox
            // 
            this.themesComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.themesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themesComboBox.Enabled = false;
            this.themesComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.themesComboBox.FormattingEnabled = true;
            this.themesComboBox.Items.AddRange(new object[] {
            "По номеру",
            "По оценке",
            "По результату",
            "По содержанию",
            "По Управлению"});
            this.themesComboBox.Location = new System.Drawing.Point(415, 33);
            this.themesComboBox.Name = "themesComboBox";
            this.themesComboBox.Size = new System.Drawing.Size(702, 23);
            this.themesComboBox.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.Controls.Add(this.filterTypeComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.filterTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.clearButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.filterButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.themesComboBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1309, 61);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // MaterialsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 452);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGrid);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaterialsListForm";
            this.Text = "Информации";
            this.Load += new System.EventHandler(this.MaterialsListForm_Load);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem addMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem requeryMenu;
        private System.Windows.Forms.ToolStripMenuItem delMenu;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ToolStripMenuItem informationToolMenu;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ComboBox filterTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox themesComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}