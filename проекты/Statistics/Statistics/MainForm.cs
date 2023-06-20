using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class MainForm : Form
    {
        private const int Version = 33;
        private string server;
        private string database;
        private DateTime whereDate;
        private bool isOnOption;
        private bool isAutoConnectoin;
        private SqlConnection connection;
        private bool connected = false;
        
        private int GetSettings()
        {
            string path = Directory.GetCurrentDirectory() + "\\statistics.ini";
            StreamReader file = new StreamReader(path);
            try
            {

                server = file.ReadLine();
                database = file.ReadLine();
                whereDate = Convert.ToDateTime(file.ReadLine());
                if (Convert.ToInt32(file.ReadLine()) == 1) isOnOption = true; else isOnOption = false;
                if (Convert.ToInt32(file.ReadLine()) == 1) isAutoConnectoin = true; else isAutoConnectoin = false;
                file.Close();
                return 0;
            }
            catch (Exception ex)
            {
                file.Close();
                return -1;
            }
        }
        private int ElementsOn()
        {
            try
            {
                connectMenu.Enabled = false;
                disconnectMenu.Enabled = true;
                directionsButton.Enabled = true;
                departmentsButton.Enabled = true;
                operativesButton.Enabled = true;
                UKRFbutton.Enabled = true;
                employeesButton.Enabled = true;
                incomingDocumentsButton.Enabled = true;
                informationsButton.Enabled = true;
                materialsButton.Enabled = true;
                lettersButton.Enabled = true;
                conclutionsButton.Enabled = true;
                statButton.Enabled = true;
                docExpiredButton.Enabled = true;
                docInWorkButton.Enabled = true;
                checkButton.Enabled = true;
                missionsButton.Enabled = true;
                wdfmButton.Enabled = true;
                phoneDatasButton.Enabled = true;
                return 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int ElementsOff()
        {
            try
            {
                connectMenu.Enabled = true;
                disconnectMenu.Enabled = false;
                directionsButton.Enabled = false;
                departmentsButton.Enabled = false;
                operativesButton.Enabled = false;
                UKRFbutton.Enabled = false;
                employeesButton.Enabled = false;
                incomingDocumentsButton.Enabled = false;
                informationsButton.Enabled = false;
                materialsButton.Enabled = false;
                lettersButton.Enabled = false;
                conclutionsButton.Enabled = false;
                statButton.Enabled = false;
                docExpiredButton.Enabled = false;
                docInWorkButton.Enabled = false;
                checkButton.Enabled = false;
                missionsButton.Enabled = false;
                wdfmButton.Enabled = false;
                phoneDatasButton.Enabled = false;
                return 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int ElementsCheck()
        {
            try
            {
                connectMenu.Enabled = !connectMenu.Enabled;
                disconnectMenu.Enabled = !disconnectMenu.Enabled;
                directionsButton.Enabled = !directionsButton.Enabled;
                departmentsButton.Enabled = !departmentsButton.Enabled;
                operativesButton.Enabled = !operativesButton.Enabled;
                UKRFbutton.Enabled = !UKRFbutton.Enabled;
                employeesButton.Enabled = !employeesButton.Enabled;
                incomingDocumentsButton.Enabled = !incomingDocumentsButton.Enabled;
                informationsButton.Enabled = !informationsButton.Enabled;
                materialsButton.Enabled = !materialsButton.Enabled;
                lettersButton.Enabled = !lettersButton.Enabled;
                conclutionsButton.Enabled = !conclutionsButton.Enabled;
                statButton.Enabled = !statButton.Enabled;
                docExpiredButton.Enabled = !docExpiredButton.Enabled;
                docInWorkButton.Enabled = !docInWorkButton.Enabled;
                checkButton.Enabled = !checkButton.Enabled;
                missionsButton.Enabled = !missionsButton.Enabled;
                wdfmButton.Enabled = !wdfmButton.Enabled;
                return 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int DbConnection(string server, string database)
        {
            try
            {
                string conStr = "";
                int version = 1;
                conStr = @"Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=True;MultipleActiveResultSets=true";
                connection.ConnectionString = conStr;
                connection.Open();
                connected = true;
                ElementsOn();
                SqlCommand command = new SqlCommand("select max(number) from version", connection);
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    if (reader[0] != null) version = Convert.ToInt32(reader[0]);
                }
                if (version < Version)
                {
                    
                    DbDisonnection();
                    MessageBox.Show("Обновите базу данных", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (version > Version)
                    {
                        DbDisonnection();
                        MessageBox.Show("Обновите программное обеспечение", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connected = false;
                ElementsOff();
                connection.Close();
                
                return -1;
            }
        }
        private int DbDisonnection()
        {
            try
            {
                connection.Close();
                connected = false;
                ElementsOff();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public MainForm()
        {
            server = "";
            database = "";
            whereDate = DateTime.Now;
            isAutoConnectoin = false;
            isOnOption = false;
            InitializeComponent();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            if (connected) connection.Close();
            Application.Exit();
        }

        private void connectMenu_Click(object sender, EventArgs e)
        {
            ConnectionForm connForm = new ConnectionForm();
            connForm.ShowDialog();
            if (connForm.Changed)
            {
                if (DbConnection(connForm.Server, connForm.Database) == 0)
                    this.Text = "Главная - Сервер: " + server + " База данных: " + database;
            }
            else
            {
                MessageBox.Show("Параметры подключения не были выбраны.", "Информация", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void disconnectMenu_Click(object sender, EventArgs e)
        {
            if (DbDisonnection() == 0)
                this.Text = "Главная";
        }

        private void directionsButton_Click(object sender, EventArgs e)
        {
            DirectionsListForm directionsListForm = new DirectionsListForm(connection);
            directionsListForm.ShowDialog();
        }

        private void departmentsButton_Click(object sender, EventArgs e)
        {
            DepartmentsListForm departmentsListForm = new DepartmentsListForm(connection);
            departmentsListForm.ShowDialog();
        }

        private void operativesButton_Click(object sender, EventArgs e)
        {
            OperativesListForm operativesListForm = new OperativesListForm(connection);
            operativesListForm.ShowDialog();
        }

        private void UKRFbutton_Click(object sender, EventArgs e)
        {
            UKRFListForm ukrfForm = new UKRFListForm(connection);
            ukrfForm.ShowDialog();
        }

        private void employeesButton_Click(object sender, EventArgs e)
        {
            EmployeesListForm employeesListForm = new EmployeesListForm(connection);
            employeesListForm.ShowDialog();
        }

        private void incomingDocumentsButton_Click(object sender, EventArgs e)
        {
            IncomingDocumentsListForm incomingDocumentsListForm;
            if (isOnOption)
            {
                incomingDocumentsListForm = new IncomingDocumentsListForm(connection, whereDate);
            }
            else
            {
                incomingDocumentsListForm = new IncomingDocumentsListForm(connection);    
            }
            
            incomingDocumentsListForm.ShowDialog();
        }

        private void informationsButton_Click(object sender, EventArgs e)
        {
            InformationsListForm informationsListForm;
            if (isOnOption)
            {
                informationsListForm = new InformationsListForm(connection, whereDate);
            }
            else
            {
                informationsListForm = new InformationsListForm(connection);
            }
            informationsListForm.ShowDialog();
        }

        private void materialsButton_Click(object sender, EventArgs e)
        {
            MaterialsListForm materialsListForm;
            if (isOnOption)
            {
                materialsListForm = new MaterialsListForm(connection, whereDate);
            }
            else
            {
                materialsListForm = new MaterialsListForm(connection);
            }
            materialsListForm.ShowDialog();
        }

        private void lettersButton_Click(object sender, EventArgs e)
        {
            LettersListForm lettersListForm;
            if (isOnOption)
            {
                lettersListForm = new LettersListForm(connection, whereDate);
            }
            else
            {
                lettersListForm = new LettersListForm(connection);
            }
            lettersListForm.ShowDialog();
        }

        private void conclutionsButton_Click(object sender, EventArgs e)
        {

            ConclutionsListForm conclutionsListForm;
            if (isOnOption)
            {
                conclutionsListForm = new ConclutionsListForm(connection, whereDate);
            }
            else
            {
                conclutionsListForm = new ConclutionsListForm(connection);
            }
            conclutionsListForm.ShowDialog();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            CheckForm checkForm = new CheckForm(connection);
            checkForm.ShowDialog();
        }

        private void docInWorkButton_Click(object sender, EventArgs e)
        {
            InformOnDocForm informOnDocForm = new InformOnDocForm(connection, 1);
            informOnDocForm.ShowDialog();
        }

        private void docExpiredButton_Click(object sender, EventArgs e)
        {
            InformOnDocForm informOnDocForm = new InformOnDocForm(connection, 2);
            informOnDocForm.ShowDialog();
        }

        private void statButton_Click(object sender, EventArgs e)
        {
            StatForm statForm = new StatForm(connection);
            statForm.ShowDialog();
        }

        private void settingsMenu_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
            if (settings.IsSaved)
            {
                whereDate = settings.SinceDate;
                isOnOption = settings.IsOnOption;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                string disc = Directory.GetCurrentDirectory();
                DriveInfo drive = new DriveInfo(disc[0].ToString());
                if (drive.DriveType == DriveType.Network)
                {
                    string message =
                        "Так как у некоторых сотрудников данная программа бывает запущена целый рабочий день без необходимости, теперь ее запуск с сетевого диска запрещен.\n" +
                        "Необходимо создать на локальном жестком диске папку, в нее скопировать файл программы (Statistics.exe) и файл настроек (statistics.ini)\n" +
                        "Далее запускаем с локального компьютера!";
                    MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    connection = new SqlConnection();
                    GetSettings();
                    if (isAutoConnectoin)
                    {
                        if (DbConnection(server, database) == 0)
                            this.Text = "Главная Сервер:" + server + " База данных:" + database;

                    }
                }
            }
            catch (Exception exception)
            {
                string message =
                        "Так как у некоторых сорудников данная программа бывает запущена целый рабочий день без необходимости, теперь ее запуск с сетевого диска запрещен.\n" +
                        "Необходимо создать на локальном жестком диске папку, в нее скопировать файл программы (Statistics.exe) и файл настроек (statistics.ini)\n" +
                        "Далее запускаем с локального компьютера!";
                MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void missionsButton_Click(object sender, EventArgs e)
        {
            /*
            
            MissionTargetsListForm missionTargets = new MissionTargetsListForm(connection);
            missionTargets.ShowDialog();
             * */
            MissionsListForm missionsList;
            if (isOnOption)
            {
                missionsList = new MissionsListForm(connection, whereDate);
            }
            else
            {
                missionsList = new MissionsListForm(connection);
            }
            missionsList.ShowDialog();
        }

        private void wdfmButton_Click(object sender, EventArgs e)
        {
            WeekDataFromMissionListForm weekDataFromMissionForm;
            if (isOnOption)
            {
                weekDataFromMissionForm = new WeekDataFromMissionListForm(connection, whereDate);
            }
            else
            {
                weekDataFromMissionForm = new WeekDataFromMissionListForm(connection);
            }
            weekDataFromMissionForm.ShowDialog();
        }

        private void phoneDatasButton_Click(object sender, EventArgs e)
        {
            PhoneDatasListForm phoneDatasForm;
            if (isOnOption)
            {
                phoneDatasForm = new PhoneDatasListForm(connection, whereDate);
            }
            else
            {
                phoneDatasForm = new PhoneDatasListForm(connection);
            }
            phoneDatasForm.ShowDialog();
        }
    }
}
