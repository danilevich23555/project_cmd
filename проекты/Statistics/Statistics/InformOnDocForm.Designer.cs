namespace Statistics
{
    partial class InformOnDocForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformOnDocForm));
            this.docsDataGrid = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openDocumentMenu = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.docsDataGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // docsDataGrid
            // 
            this.docsDataGrid.AllowUserToAddRows = false;
            this.docsDataGrid.AllowUserToDeleteRows = false;
            this.docsDataGrid.AllowUserToOrderColumns = true;
            this.docsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.docsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.docsDataGrid.ContextMenuStrip = this.contextMenu;
            this.docsDataGrid.Location = new System.Drawing.Point(11, 11);
            this.docsDataGrid.MultiSelect = false;
            this.docsDataGrid.Name = "docsDataGrid";
            this.docsDataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docsDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.docsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.docsDataGrid.ShowCellErrors = false;
            this.docsDataGrid.ShowCellToolTips = false;
            this.docsDataGrid.ShowEditingIcon = false;
            this.docsDataGrid.ShowRowErrors = false;
            this.docsDataGrid.Size = new System.Drawing.Size(1255, 569);
            this.docsDataGrid.TabIndex = 0;
            this.docsDataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.docsDataGrid_CellMouseDown);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDocumentMenu});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(177, 26);
            // 
            // openDocumentMenu
            // 
            this.openDocumentMenu.Name = "openDocumentMenu";
            this.openDocumentMenu.Size = new System.Drawing.Size(176, 22);
            this.openDocumentMenu.Text = "Открыть документ";
            this.openDocumentMenu.Click += new System.EventHandler(this.openDocumentMenu_Click);
            // 
            // InformOnDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 592);
            this.Controls.Add(this.docsDataGrid);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InformOnDocForm";
            this.Load += new System.EventHandler(this.InformOnDocForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.docsDataGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView docsDataGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem openDocumentMenu;
    }
}