namespace Statistics
{
    partial class DirectionsListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectionsListForm));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RequeryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMenu,
            this.EditMenu,
            this.RequeryMenu,
            this.DelMenu});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 114);
            // 
            // AddMenu
            // 
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(152, 22);
            this.AddMenu.Text = "Добавить";
            this.AddMenu.Click += new System.EventHandler(this.AddMenu_Click);
            // 
            // EditMenu
            // 
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(152, 22);
            this.EditMenu.Text = "Изменить";
            this.EditMenu.Click += new System.EventHandler(this.EditMenu_Click);
            // 
            // RequeryMenu
            // 
            this.RequeryMenu.Name = "RequeryMenu";
            this.RequeryMenu.Size = new System.Drawing.Size(152, 22);
            this.RequeryMenu.Text = "Обновить";
            this.RequeryMenu.Click += new System.EventHandler(this.RequeryMenu_Click);
            // 
            // DelMenu
            // 
            this.DelMenu.Name = "DelMenu";
            this.DelMenu.Size = new System.Drawing.Size(152, 22);
            this.DelMenu.Text = "Удалить";
            this.DelMenu.Click += new System.EventHandler(this.DelMenu_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.ContextMenuStrip = this.contextMenu;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(327, 338);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_CellMouseDown);
            // 
            // DirectionsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 338);
            this.Controls.Add(this.dataGrid);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DirectionsListForm";
            this.Text = "Службы";
            this.Load += new System.EventHandler(this.DirectionsListForm_Load);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddMenu;
        private System.Windows.Forms.ToolStripMenuItem EditMenu;
        private System.Windows.Forms.ToolStripMenuItem DelMenu;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ToolStripMenuItem RequeryMenu;
    }
}