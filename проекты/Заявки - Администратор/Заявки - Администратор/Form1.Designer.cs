namespace Заявки___Администратор
{
    partial class Form1
    {

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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btPrev1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filing_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbOt1 = new System.Windows.Forms.TextBox();
            this.tbIm1 = new System.Windows.Forms.TextBox();
            this.tbFam1 = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.заявкиDataSet = new Заявки___Администратор.ЗаявкиDataSet();
            this.tableTestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableTestTableAdapter = new Заявки___Администратор.ЗаявкиDataSetTableAdapters.tableTestTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.заявкиDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTestBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1817, 651);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lb4);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.radioButton4);
            this.tabPage1.Controls.Add(this.radioButton3);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1809, 622);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Location = new System.Drawing.Point(1203, 16);
            this.lb4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(0, 17);
            this.lb4.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.btPrev1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.tbOt1);
            this.panel1.Controls.Add(this.tbIm1);
            this.panel1.Controls.Add(this.tbFam1);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Location = new System.Drawing.Point(8, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1791, 549);
            this.panel1.TabIndex = 4;
            // 
            // btPrev1
            // 
            this.btPrev1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btPrev1.Location = new System.Drawing.Point(1643, 39);
            this.btPrev1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btPrev1.Name = "btPrev1";
            this.btPrev1.Size = new System.Drawing.Size(144, 36);
            this.btPrev1.TabIndex = 4;
            this.btPrev1.Text = "Просмотр";
            this.btPrev1.UseVisualStyleBackColor = true;
            this.btPrev1.Click += new System.EventHandler(this.btPrev1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(904, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(547, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(144, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фамилия";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.surname,
            this.name,
            this.patronymic,
            this.departament,
            this.content,
            this.filing_date,
            this.result,
            this.result_date});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(5, 84);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1781, 462);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // surname
            // 
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // patronymic
            // 
            this.patronymic.HeaderText = "Patronymic";
            this.patronymic.Name = "patronymic";
            this.patronymic.ReadOnly = true;
            // 
            // departament
            // 
            this.departament.HeaderText = "Departament";
            this.departament.Name = "departament";
            this.departament.ReadOnly = true;
            // 
            // content
            // 
            this.content.HeaderText = "Content";
            this.content.Name = "content";
            this.content.ReadOnly = true;
            // 
            // filing_date
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.filing_date.DefaultCellStyle = dataGridViewCellStyle2;
            this.filing_date.HeaderText = "Filing_date";
            this.filing_date.Name = "filing_date";
            this.filing_date.ReadOnly = true;
            // 
            // result
            // 
            this.result.HeaderText = "Result";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            // 
            // result_date
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.result_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.result_date.HeaderText = "Result_Date";
            this.result_date.Name = "result_date";
            this.result_date.ReadOnly = true;
            // 
            // tbOt1
            // 
            this.tbOt1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOt1.Location = new System.Drawing.Point(741, 41);
            this.tbOt1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOt1.Name = "tbOt1";
            this.tbOt1.Size = new System.Drawing.Size(448, 35);
            this.tbOt1.TabIndex = 1;
            // 
            // tbIm1
            // 
            this.tbIm1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbIm1.Location = new System.Drawing.Point(413, 41);
            this.tbIm1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbIm1.Name = "tbIm1";
            this.tbIm1.Size = new System.Drawing.Size(319, 35);
            this.tbIm1.TabIndex = 1;
            // 
            // tbFam1
            // 
            this.tbFam1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFam1.Location = new System.Drawing.Point(5, 41);
            this.tbFam1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFam1.Name = "tbFam1";
            this.tbFam1.Size = new System.Drawing.Size(399, 35);
            this.tbFam1.TabIndex = 1;
            this.tbFam1.TextChanged += new System.EventHandler(this.tbFam1_TextChanged);
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSearch.Location = new System.Drawing.Point(1199, 41);
            this.btSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(132, 36);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Найти";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton4.Location = new System.Drawing.Point(512, 7);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(164, 31);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Показать все";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(384, 7);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(111, 31);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "По дате";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(185, 7);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(180, 31);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "По отделению";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(8, 7);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(161, 31);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "По фамилии";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1809, 622);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // заявкиDataSet
            // 
            this.заявкиDataSet.DataSetName = "ЗаявкиDataSet";
            this.заявкиDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableTestBindingSource
            // 
            this.tableTestBindingSource.DataMember = "tableTest";
            this.tableTestBindingSource.DataSource = this.заявкиDataSet;
            // 
            // tableTestTableAdapter
            // 
            this.tableTestTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1849, 681);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.заявкиDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTestBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.RadioButton radioButton4;
        public System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox tbOt1;
        public System.Windows.Forms.TextBox tbIm1;
        public System.Windows.Forms.TextBox tbFam1;
        public System.Windows.Forms.Button btSearch;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public ЗаявкиDataSet заявкиDataSet;
        public System.Windows.Forms.BindingSource tableTestBindingSource;
        public ЗаявкиDataSetTableAdapters.tableTestTableAdapter tableTestTableAdapter;
        public System.Windows.Forms.Button btPrev1;
        public System.Windows.Forms.Label lb4;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn departament;
        private System.Windows.Forms.DataGridViewTextBoxColumn content;
        private System.Windows.Forms.DataGridViewTextBoxColumn filing_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn result_date;
    }
}

