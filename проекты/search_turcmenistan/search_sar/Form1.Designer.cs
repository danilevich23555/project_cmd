namespace search_sar
{
    partial class serch_sar
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serch_sar));
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnexport = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.файлToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.connectMenu = new System.Windows.Forms.MenuItem();
            this.dbOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button_tag_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(6, 7);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(220, 490);
            this.txtsearch.TabIndex = 0;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged_1);
            // 
            // btnsearch
            // 
            this.btnsearch.Enabled = false;
            this.btnsearch.Location = new System.Drawing.Point(5, 501);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(220, 36);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.Text = "НАЙТИ";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(227, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(633, 196);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnexport
            // 
            this.btnexport.Enabled = false;
            this.btnexport.Location = new System.Drawing.Point(5, 541);
            this.btnexport.Margin = new System.Windows.Forms.Padding(2);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(220, 36);
            this.btnexport.TabIndex = 3;
            this.btnexport.Text = "ЭКСПОРТИРОВАТЬ ДАННЫЕ В EXCEL";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.файлToolStripMenuItem});
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Index = 0;
            this.файлToolStripMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.connectMenu});
            this.файлToolStripMenuItem.Text = "ФАЙЛ";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // connectMenu
            // 
            this.connectMenu.Index = 0;
            this.connectMenu.Text = "подключиться к БД";
            this.connectMenu.Click += new System.EventHandler(this.connectMenu_Click);
            // 
            // dbOpenFileDialog
            // 
            this.dbOpenFileDialog.FileName = "openFileDialog1";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(230, 233);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(633, 192);
            this.dataGridView2.TabIndex = 2;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(230, 443);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(633, 175);
            this.dataGridView3.TabIndex = 2;
            // 
            // button_tag_search
            // 
            this.button_tag_search.Enabled = false;
            this.button_tag_search.Location = new System.Drawing.Point(5, 582);
            this.button_tag_search.Name = "button_tag_search";
            this.button_tag_search.Size = new System.Drawing.Size(220, 36);
            this.button_tag_search.TabIndex = 4;
            this.button_tag_search.Text = "ПОСМОТРЕТЬ ТЕГИ ПО НОМЕРАМ";
            this.button_tag_search.UseVisualStyleBackColor = true;
            this.button_tag_search.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // serch_sar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 626);
            this.Controls.Add(this.button_tag_search);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "serch_sar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serch_SAR";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem файлToolStripMenuItem;
        private System.Windows.Forms.MenuItem connectMenu;
        private System.Windows.Forms.OpenFileDialog dbOpenFileDialog;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button_tag_search;
    }
}

