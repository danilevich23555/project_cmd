namespace Statistics
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.присоединитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.directionsButton = new System.Windows.Forms.Button();
            this.departmentsButton = new System.Windows.Forms.Button();
            this.operativesButton = new System.Windows.Forms.Button();
            this.UKRFbutton = new System.Windows.Forms.Button();
            this.employeesButton = new System.Windows.Forms.Button();
            this.incomingDocumentsButton = new System.Windows.Forms.Button();
            this.informationsButton = new System.Windows.Forms.Button();
            this.materialsButton = new System.Windows.Forms.Button();
            this.lettersButton = new System.Windows.Forms.Button();
            this.conclutionsButton = new System.Windows.Forms.Button();
            this.docExpiredButton = new System.Windows.Forms.Button();
            this.docInWorkButton = new System.Windows.Forms.Button();
            this.statButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.wdfmButton = new System.Windows.Forms.Button();
            this.missionsButton = new System.Windows.Forms.Button();
            this.phoneDatasButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.присоединитьсяToolStripMenuItem,
            this.settingsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(967, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // присоединитьсяToolStripMenuItem
            // 
            this.присоединитьсяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectMenu,
            this.disconnectMenu,
            this.exitMenu});
            this.присоединитьсяToolStripMenuItem.Name = "присоединитьсяToolStripMenuItem";
            this.присоединитьсяToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.присоединитьсяToolStripMenuItem.Text = "Файл";
            // 
            // connectMenu
            // 
            this.connectMenu.Name = "connectMenu";
            this.connectMenu.Size = new System.Drawing.Size(166, 22);
            this.connectMenu.Text = "Присоединиться";
            this.connectMenu.Click += new System.EventHandler(this.connectMenu_Click);
            // 
            // disconnectMenu
            // 
            this.disconnectMenu.Enabled = false;
            this.disconnectMenu.Name = "disconnectMenu";
            this.disconnectMenu.Size = new System.Drawing.Size(166, 22);
            this.disconnectMenu.Text = "Отсоединиться";
            this.disconnectMenu.Click += new System.EventHandler(this.disconnectMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(166, 22);
            this.exitMenu.Text = "Выход";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // settingsMenu
            // 
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(79, 20);
            this.settingsMenu.Text = "Настройки";
            this.settingsMenu.Click += new System.EventHandler(this.settingsMenu_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.Controls.Add(this.directionsButton, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.departmentsButton, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.operativesButton, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.UKRFbutton, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.employeesButton, 4, 3);
            this.tableLayoutPanel.Controls.Add(this.incomingDocumentsButton, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.informationsButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.materialsButton, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.lettersButton, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.conclutionsButton, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.docExpiredButton, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.docInWorkButton, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.statButton, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.checkButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.wdfmButton, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.missionsButton, 5, 3);
            this.tableLayoutPanel.Controls.Add(this.phoneDatasButton, 5, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(967, 290);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // directionsButton
            // 
            this.directionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directionsButton.Enabled = false;
            this.directionsButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directionsButton.Location = new System.Drawing.Point(4, 219);
            this.directionsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.directionsButton.Name = "directionsButton";
            this.directionsButton.Size = new System.Drawing.Size(153, 68);
            this.directionsButton.TabIndex = 0;
            this.directionsButton.Text = "Службы";
            this.directionsButton.UseVisualStyleBackColor = true;
            this.directionsButton.Click += new System.EventHandler(this.directionsButton_Click);
            // 
            // departmentsButton
            // 
            this.departmentsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentsButton.Enabled = false;
            this.departmentsButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departmentsButton.Location = new System.Drawing.Point(165, 219);
            this.departmentsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.departmentsButton.Name = "departmentsButton";
            this.departmentsButton.Size = new System.Drawing.Size(153, 68);
            this.departmentsButton.TabIndex = 2;
            this.departmentsButton.Text = "Управления";
            this.departmentsButton.UseVisualStyleBackColor = true;
            this.departmentsButton.Click += new System.EventHandler(this.departmentsButton_Click);
            // 
            // operativesButton
            // 
            this.operativesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operativesButton.Enabled = false;
            this.operativesButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operativesButton.Location = new System.Drawing.Point(326, 219);
            this.operativesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.operativesButton.Name = "operativesButton";
            this.operativesButton.Size = new System.Drawing.Size(153, 68);
            this.operativesButton.TabIndex = 3;
            this.operativesButton.Text = "Оперативники";
            this.operativesButton.UseVisualStyleBackColor = true;
            this.operativesButton.Click += new System.EventHandler(this.operativesButton_Click);
            // 
            // UKRFbutton
            // 
            this.UKRFbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UKRFbutton.Enabled = false;
            this.UKRFbutton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UKRFbutton.Location = new System.Drawing.Point(487, 219);
            this.UKRFbutton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UKRFbutton.Name = "UKRFbutton";
            this.UKRFbutton.Size = new System.Drawing.Size(153, 68);
            this.UKRFbutton.TabIndex = 4;
            this.UKRFbutton.Text = "Статьи УК РФ";
            this.UKRFbutton.UseVisualStyleBackColor = true;
            this.UKRFbutton.Click += new System.EventHandler(this.UKRFbutton_Click);
            // 
            // employeesButton
            // 
            this.employeesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesButton.Enabled = false;
            this.employeesButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeesButton.Location = new System.Drawing.Point(648, 219);
            this.employeesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.employeesButton.Name = "employeesButton";
            this.employeesButton.Size = new System.Drawing.Size(153, 68);
            this.employeesButton.TabIndex = 5;
            this.employeesButton.Text = "Сотрудники \r\n3 отдела";
            this.employeesButton.UseVisualStyleBackColor = true;
            this.employeesButton.Click += new System.EventHandler(this.employeesButton_Click);
            // 
            // incomingDocumentsButton
            // 
            this.incomingDocumentsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.incomingDocumentsButton.Enabled = false;
            this.incomingDocumentsButton.Location = new System.Drawing.Point(3, 3);
            this.incomingDocumentsButton.Name = "incomingDocumentsButton";
            this.incomingDocumentsButton.Size = new System.Drawing.Size(155, 66);
            this.incomingDocumentsButton.TabIndex = 6;
            this.incomingDocumentsButton.Text = "Входящие документы";
            this.incomingDocumentsButton.UseVisualStyleBackColor = true;
            this.incomingDocumentsButton.Click += new System.EventHandler(this.incomingDocumentsButton_Click);
            // 
            // informationsButton
            // 
            this.informationsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.informationsButton.Enabled = false;
            this.informationsButton.Location = new System.Drawing.Point(164, 3);
            this.informationsButton.Name = "informationsButton";
            this.informationsButton.Size = new System.Drawing.Size(155, 66);
            this.informationsButton.TabIndex = 7;
            this.informationsButton.Text = "Ответы на запросы";
            this.informationsButton.UseVisualStyleBackColor = true;
            this.informationsButton.Click += new System.EventHandler(this.informationsButton_Click);
            // 
            // materialsButton
            // 
            this.materialsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsButton.Enabled = false;
            this.materialsButton.Location = new System.Drawing.Point(647, 3);
            this.materialsButton.Name = "materialsButton";
            this.materialsButton.Size = new System.Drawing.Size(155, 66);
            this.materialsButton.TabIndex = 8;
            this.materialsButton.Text = "Информации";
            this.materialsButton.UseVisualStyleBackColor = true;
            this.materialsButton.Click += new System.EventHandler(this.materialsButton_Click);
            // 
            // lettersButton
            // 
            this.lettersButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lettersButton.Enabled = false;
            this.lettersButton.Location = new System.Drawing.Point(486, 3);
            this.lettersButton.Name = "lettersButton";
            this.lettersButton.Size = new System.Drawing.Size(155, 66);
            this.lettersButton.TabIndex = 9;
            this.lettersButton.Text = "Материалы";
            this.lettersButton.UseVisualStyleBackColor = true;
            this.lettersButton.Click += new System.EventHandler(this.lettersButton_Click);
            // 
            // conclutionsButton
            // 
            this.conclutionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conclutionsButton.Enabled = false;
            this.conclutionsButton.Location = new System.Drawing.Point(325, 3);
            this.conclutionsButton.Name = "conclutionsButton";
            this.conclutionsButton.Size = new System.Drawing.Size(155, 66);
            this.conclutionsButton.TabIndex = 10;
            this.conclutionsButton.Text = "Экземпляры писем";
            this.conclutionsButton.UseVisualStyleBackColor = true;
            this.conclutionsButton.Click += new System.EventHandler(this.conclutionsButton_Click);
            // 
            // docExpiredButton
            // 
            this.docExpiredButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docExpiredButton.Enabled = false;
            this.docExpiredButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docExpiredButton.Location = new System.Drawing.Point(164, 147);
            this.docExpiredButton.Name = "docExpiredButton";
            this.docExpiredButton.Size = new System.Drawing.Size(155, 66);
            this.docExpiredButton.TabIndex = 11;
            this.docExpiredButton.Text = "Просроченные документы";
            this.docExpiredButton.UseVisualStyleBackColor = true;
            this.docExpiredButton.Click += new System.EventHandler(this.docExpiredButton_Click);
            // 
            // docInWorkButton
            // 
            this.docInWorkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docInWorkButton.Enabled = false;
            this.docInWorkButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docInWorkButton.Location = new System.Drawing.Point(3, 147);
            this.docInWorkButton.Name = "docInWorkButton";
            this.docInWorkButton.Size = new System.Drawing.Size(155, 66);
            this.docInWorkButton.TabIndex = 12;
            this.docInWorkButton.Text = "Документы в работе";
            this.docInWorkButton.UseVisualStyleBackColor = true;
            this.docInWorkButton.Click += new System.EventHandler(this.docInWorkButton_Click);
            // 
            // statButton
            // 
            this.statButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statButton.Enabled = false;
            this.statButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statButton.Location = new System.Drawing.Point(325, 75);
            this.statButton.Name = "statButton";
            this.statButton.Size = new System.Drawing.Size(155, 66);
            this.statButton.TabIndex = 13;
            this.statButton.Text = "Статистика";
            this.statButton.UseVisualStyleBackColor = true;
            this.statButton.Click += new System.EventHandler(this.statButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkButton.Enabled = false;
            this.checkButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkButton.Location = new System.Drawing.Point(3, 75);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(155, 66);
            this.checkButton.TabIndex = 14;
            this.checkButton.Text = "Проверка номеров";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // wdfmButton
            // 
            this.wdfmButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wdfmButton.Enabled = false;
            this.wdfmButton.Location = new System.Drawing.Point(808, 3);
            this.wdfmButton.Name = "wdfmButton";
            this.wdfmButton.Size = new System.Drawing.Size(156, 66);
            this.wdfmButton.TabIndex = 15;
            this.wdfmButton.Text = "Данные из командировок";
            this.wdfmButton.UseVisualStyleBackColor = true;
            this.wdfmButton.Click += new System.EventHandler(this.wdfmButton_Click);
            // 
            // missionsButton
            // 
            this.missionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.missionsButton.Enabled = false;
            this.missionsButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.missionsButton.Location = new System.Drawing.Point(808, 219);
            this.missionsButton.Name = "missionsButton";
            this.missionsButton.Size = new System.Drawing.Size(156, 68);
            this.missionsButton.TabIndex = 16;
            this.missionsButton.Text = "Командировки";
            this.missionsButton.UseVisualStyleBackColor = true;
            this.missionsButton.Click += new System.EventHandler(this.missionsButton_Click);
            // 
            // phoneDatasButton
            // 
            this.phoneDatasButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phoneDatasButton.Enabled = false;
            this.phoneDatasButton.Location = new System.Drawing.Point(808, 75);
            this.phoneDatasButton.Name = "phoneDatasButton";
            this.phoneDatasButton.Size = new System.Drawing.Size(156, 66);
            this.phoneDatasButton.TabIndex = 17;
            this.phoneDatasButton.Text = "Установки";
            this.phoneDatasButton.UseVisualStyleBackColor = true;
            this.phoneDatasButton.Click += new System.EventHandler(this.phoneDatasButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 314);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem присоединитьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectMenu;
        private System.Windows.Forms.ToolStripMenuItem disconnectMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button directionsButton;
        private System.Windows.Forms.Button departmentsButton;
        private System.Windows.Forms.Button operativesButton;
        private System.Windows.Forms.Button UKRFbutton;
        private System.Windows.Forms.Button employeesButton;
        private System.Windows.Forms.Button incomingDocumentsButton;
        private System.Windows.Forms.Button informationsButton;
        private System.Windows.Forms.Button materialsButton;
        private System.Windows.Forms.Button lettersButton;
        private System.Windows.Forms.Button conclutionsButton;
        private System.Windows.Forms.Button docExpiredButton;
        private System.Windows.Forms.Button docInWorkButton;
        private System.Windows.Forms.Button statButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.Button wdfmButton;
        private System.Windows.Forms.Button missionsButton;
        private System.Windows.Forms.Button phoneDatasButton;
    }
}

