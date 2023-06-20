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
            this.btn_change = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnanalitic = new System.Windows.Forms.Button();
            this.btntwinscontact = new System.Windows.Forms.Button();
            this.btnwheretable = new System.Windows.Forms.Button();
            this.btn_IDobject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(6, 7);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(220, 445);
            this.txtsearch.TabIndex = 0;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged_1);
            // 
            // btnsearch
            // 
            this.btnsearch.Enabled = false;
            this.btnsearch.Location = new System.Drawing.Point(887, 8);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(181, 32);
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
            this.dataGridView1.Location = new System.Drawing.Point(230, 8);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(633, 444);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnexport
            // 
            this.btnexport.Enabled = false;
            this.btnexport.Location = new System.Drawing.Point(887, 128);
            this.btnexport.Margin = new System.Windows.Forms.Padding(2);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(181, 36);
            this.btnexport.TabIndex = 3;
            this.btnexport.Text = "экспортировать данные в excel";
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
            // btn_change
            // 
            this.btn_change.Enabled = false;
            this.btn_change.Location = new System.Drawing.Point(887, 63);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(181, 36);
            this.btn_change.TabIndex = 4;
            this.btn_change.Text = "СМЕНА НОМЕРОВ\r\n";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Enabled = false;
            this.btnupdate.Location = new System.Drawing.Point(887, 192);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(181, 31);
            this.btnupdate.TabIndex = 5;
            this.btnupdate.Text = "ВНЕСТИ ИЗМЕНЕНИЯ В БД";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnanalitic
            // 
            this.btnanalitic.Enabled = false;
            this.btnanalitic.Location = new System.Drawing.Point(887, 247);
            this.btnanalitic.Name = "btnanalitic";
            this.btnanalitic.Size = new System.Drawing.Size(181, 44);
            this.btnanalitic.TabIndex = 6;
            this.btnanalitic.Text = "интенсивность по номерам из примечаний";
            this.btnanalitic.UseVisualStyleBackColor = true;
            this.btnanalitic.Click += new System.EventHandler(this.btnanalitic_Click);
            // 
            // btntwinscontact
            // 
            this.btntwinscontact.Enabled = false;
            this.btntwinscontact.Location = new System.Drawing.Point(887, 314);
            this.btntwinscontact.Name = "btntwinscontact";
            this.btntwinscontact.Size = new System.Drawing.Size(181, 31);
            this.btntwinscontact.TabIndex = 7;
            this.btntwinscontact.Text = "найти общие связи";
            this.btntwinscontact.UseVisualStyleBackColor = true;
            this.btntwinscontact.Click += new System.EventHandler(this.btntwinscontact_Click);
            // 
            // btnwheretable
            // 
            this.btnwheretable.Enabled = false;
            this.btnwheretable.Location = new System.Drawing.Point(887, 372);
            this.btnwheretable.Name = "btnwheretable";
            this.btnwheretable.Size = new System.Drawing.Size(181, 28);
            this.btnwheretable.TabIndex = 8;
            this.btnwheretable.Text = "поиск по таблицам + пояснения";
            this.btnwheretable.UseVisualStyleBackColor = true;
            this.btnwheretable.Click += new System.EventHandler(this.btnwheretable_Click);
            // 
            // btn_IDobject
            // 
            this.btn_IDobject.Enabled = false;
            this.btn_IDobject.Location = new System.Drawing.Point(887, 419);
            this.btn_IDobject.Name = "btn_IDobject";
            this.btn_IDobject.Size = new System.Drawing.Size(181, 32);
            this.btn_IDobject.TabIndex = 9;
            this.btn_IDobject.Text = "поиск по ID";
            this.btn_IDobject.UseVisualStyleBackColor = true;
            this.btn_IDobject.Click += new System.EventHandler(this.btn_IDobject_Click);
            // 
            // serch_sar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 463);
            this.Controls.Add(this.btn_IDobject);
            this.Controls.Add(this.btnwheretable);
            this.Controls.Add(this.btntwinscontact);
            this.Controls.Add(this.btnanalitic);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.btnexport);
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
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnanalitic;
        private System.Windows.Forms.Button btntwinscontact;
        private System.Windows.Forms.Button btnwheretable;
        private System.Windows.Forms.Button btn_IDobject;
    }
}

