namespace Statistics
{
    partial class CheckForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForm));
            this.label1 = new System.Windows.Forms.Label();
            this.checkNumbersRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openDocumentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.executeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.queryButton = new System.Windows.Forms.Button();
            this.resultGrid2 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номера для проверки";
            // 
            // checkNumbersRichTextBox
            // 
            this.checkNumbersRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkNumbersRichTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkNumbersRichTextBox.Location = new System.Drawing.Point(3, 33);
            this.checkNumbersRichTextBox.Name = "checkNumbersRichTextBox";
            this.tableLayoutPanel1.SetRowSpan(this.checkNumbersRichTextBox, 2);
            this.checkNumbersRichTextBox.Size = new System.Drawing.Size(213, 456);
            this.checkNumbersRichTextBox.TabIndex = 1;
            this.checkNumbersRichTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(222, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1240, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Результат";
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.AllowUserToOrderColumns = true;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGrid.Location = new System.Drawing.Point(222, 33);
            this.resultGrid.MultiSelect = false;
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.resultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGrid.Size = new System.Drawing.Size(1240, 225);
            this.resultGrid.TabIndex = 3;
            this.resultGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.resultGrid_CellMouseDown);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDocumentMenu,
            this.executeMenu});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(204, 48);
            // 
            // openDocumentMenu
            // 
            this.openDocumentMenu.Name = "openDocumentMenu";
            this.openDocumentMenu.Size = new System.Drawing.Size(203, 22);
            this.openDocumentMenu.Text = "Просмотреть документ";
            this.openDocumentMenu.Click += new System.EventHandler(this.openDocumentMenu_Click);
            // 
            // executeMenu
            // 
            this.executeMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executeMenu.Name = "executeMenu";
            this.executeMenu.Size = new System.Drawing.Size(203, 22);
            this.executeMenu.Text = "Исполнение";
            this.executeMenu.Click += new System.EventHandler(this.executeMenu_Click);
            // 
            // queryButton
            // 
            this.queryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queryButton.Location = new System.Drawing.Point(3, 495);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(213, 35);
            this.queryButton.TabIndex = 4;
            this.queryButton.Text = "Проверить";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // resultGrid2
            // 
            this.resultGrid2.AllowUserToAddRows = false;
            this.resultGrid2.AllowUserToDeleteRows = false;
            this.resultGrid2.AllowUserToOrderColumns = true;
            this.resultGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGrid2.Location = new System.Drawing.Point(222, 264);
            this.resultGrid2.MultiSelect = false;
            this.resultGrid2.Name = "resultGrid2";
            this.resultGrid2.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultGrid2.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.resultGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGrid2.Size = new System.Drawing.Size(1240, 225);
            this.resultGrid2.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.queryButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.resultGrid2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkNumbersRichTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.resultGrid, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1465, 533);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CheckForm";
            this.Text = "Проверка";
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox checkNumbersRichTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem openDocumentMenu;
        private System.Windows.Forms.DataGridView resultGrid2;
        private System.Windows.Forms.ToolStripMenuItem executeMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}