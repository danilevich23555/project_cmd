using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class StatForm : Form
    {
        private SqlConnection connection;
        private void SwitchOffComboBoxes()
        {
            forOtdComboBox.Enabled = false;
            forNaprComboBox.Enabled = false;
            weekStatTypeСomboBox.Enabled = false;
            summaryTypeСomboBox.Enabled = false;
            forOtdComboBox.SelectedIndex = -1;
            forNaprComboBox.SelectedIndex = -1;
            weekStatTypeСomboBox.SelectedIndex = -1;
            summaryTypeСomboBox.SelectedIndex = -1;

            return;
        }
        public StatForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            finishDateTimePicker.Value = DateTime.Now;
            startDateTimePicker.Value = DateTime.Now.AddDays(-7);
        }

        private int SaveReportToFile(DataGridView grid, string path)
        {
            StreamWriter file = new StreamWriter(path, false, Encoding.Unicode);
            string line = "";
            try
            {
                //MessageBox.Show(grid.Rows[0].Cells[1].Value.ToString());
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    line = line + column.HeaderText + "\t";
                }
                file.WriteLine(line);
                line = "";
                foreach (DataGridViewRow row in grid.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        line = line + cell.Value.ToString() + "\t";
                    }    
                    file.WriteLine(line);
                    line = "";
                }
                file.Close();
                return 0;
            }
            catch (Exception ex)
            {
                file.Close();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetWeekStat()
        {
            try
            {
                switch (weekStatTypeСomboBox.SelectedItem.ToString())
                {
                    case @"Статистика по справкам":

                        string statInfCmdString = @"SELECT dirName, depName, idNumber, infDate, idDou, ukNumber, infNumber
                                                            FROM Informations left join IncDocInform on (Informations.infID = IncDocInform.infID)
				                                                 left join IncomingDocuments on (IncDocInform.idID = IncomingDocuments.idID)
	                                                             left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                                 left join Departments on (Operatives.depID = departments.depID)
                                                                 left join Directions on (Departments.dirID = Directions.dirID) 
				                                                 left join TaskTypes on (TaskTypes.ttID = IncomingDocuments.ttID)
	                                                        where (ttName = 'Анализ' ) And (infOut = 1) and (infExist = 1) and (infDate between '" + startDateTimePicker.Value.ToShortDateString() + 
                                                                  @"' and '" + finishDateTimePicker.Value.ToShortDateString() + "')order by infDate, infNumber ";
                        SqlDataAdapter infAdapter = new SqlDataAdapter(statInfCmdString, connection);
                        DataSet dsInf = new DataSet();
                        dsInf.Tables.Add("InfStatistics");
                        infAdapter.Fill(dsInf, "InfStatistics");
                        BindingSource bsInf = new BindingSource(dsInf, "InfStatistics");
                        statGridView.DataSource = bsInf;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[2].HeaderText = "Номер вх. документа";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Дата подписи";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[4].HeaderText = "ДОУ";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[5].HeaderText = "Ст. УК РФ";
                        statGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[6].HeaderText = "Номер справки";
                        statGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case @"Статистика по материалам":
                        string statLetCmdString = @"select ItemsOfPlan.pID, pNum, pText, stName, count(Materials.mID) from Conclutions left join Letters on (Letters.lID = Conclutions.lID)
                                                    left join MaterialLetter on (Letters.lid = MaterialLetter.lID)
                                                    left join Materials on (Materials.mID = MaterialLetter.mID)
                                                    left join ItemsOfPlan on (Letters.pID = ItemsOfPlan.pID)
                                                    left join ServiceTypes on (Materials.stID = ServiceTypes.stID) " +
                                                    " where lDate between '" + startDateTimePicker.Value.ToShortDateString() + 
                                                    @"' and '" + finishDateTimePicker.Value.ToShortDateString() + "'" +
                                                    @"group by ItemsOfPlan.pID, pNum, pText, stName
                                                    order by ItemsOfPlan.pID, stName";
                        SqlDataAdapter letAdapter = new SqlDataAdapter(statLetCmdString, connection);
                        DataSet dsLet = new DataSet();
                        dsLet.Tables.Add("LetStatistics");
                        letAdapter.Fill(dsLet, "LetStatistics");
                        BindingSource bsLet = new BindingSource(dsLet, "LetStatistics");
                        statGridView.DataSource = bsLet;              
                        statGridView.Columns[0].HeaderText = "pID";
                        statGridView.Columns[0].Visible = false;
                        statGridView.Columns[1].HeaderText = "Пункт плана";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[2].HeaderText = "Пояснение";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[3].HeaderText = "Тип Услуги";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[4].HeaderText = "Количество информаций";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case @"Исходящие документы":
                        string outDocCmdString = @"select DocDate, dirName, depName, Text, Commentary from
                                                    (
                                                    select ldate as DocDate, dirName, depName, lText as Text, null as Commentary from Conclutions
                                                    join Letters on (Letters.lID = Conclutions.lID)
                                                    left join Operatives on (Conclutions.opID = Operatives.opID)
                                                    left join Departments on (Operatives.depID = departments.depID)
                                                    left join Directions on (Departments.dirID = Directions.dirID)  " +
                                                 " where not ((depName = 'Управление \"Р\"') and (dirName = '12 Центр')) and (lDate between '" + startDateTimePicker.Value.ToShortDateString() +
                                                    @"' and '" + finishDateTimePicker.Value.ToShortDateString() + "')" +
                                                 @" union all
                                                    select infDate,  dirName, depName,  ttName, infText from Informations
                                                    join IncDocInform on (Informations.infID = IncDocInform.infID)
                                                    join IncomingDocuments on (IncDocInform.idID = IncomingDocuments.idID)
                                                    left join Operatives on (IncomingDocuments.opID = Operatives.opID)
                                                    left join Departments on (Operatives.depID = departments.depID)
                                                    left join Directions on (Departments.dirID = Directions.dirID)
                                                    left join TaskTypes on (IncomingDocuments.ttID = TaskTypes.ttID) " +
                                                 " where not ((depName = 'Управление \"Р\"') and (dirName = '12 Центр')) and (infDate between '" + startDateTimePicker.Value.ToShortDateString() +
                                                 @"' and '" + finishDateTimePicker.Value.ToShortDateString() + "')" +
                                                 ") a  order by DocDate, dirName, depName, Text";

                        SqlDataAdapter docAdapter = new SqlDataAdapter(outDocCmdString, connection);
                        DataSet dsDoc = new DataSet();
                        dsDoc.Tables.Add("OutDocs");
                        docAdapter.Fill(dsDoc, "OutDocs");
                        BindingSource bsDoc = new BindingSource(dsDoc, "OutDocs");
                        statGridView.DataSource = bsDoc;
                        statGridView.Columns[0].HeaderText = "Дата";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Служба";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[2].HeaderText = "Управление";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[3].HeaderText = "Тип документа";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[4].HeaderText = "Комментарий";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case @"Статистика по пробивкам":

                        string statProvCmdString = @"SELECT dirName, depName, idNumber, idDate, idDou, infNumber, infDate, infCountNuvbersInfExist, count(distinct phoneNumber)
                                                                FROM Informations left join IncDocInform on (Informations.infID = IncDocInform.infID)
                                                                     left join IncomingDocuments on (IncDocInform.idID = IncomingDocuments.idID)
                                                                     left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                                     left join Departments on (Operatives.depID = departments.depID)
                                                                     left join Directions on (Departments.dirID = Directions.dirID) 
                                                                     left join TaskTypes on (TaskTypes.ttID = IncomingDocuments.ttID)
	                                                                 left join Numbers on (IncomingDocuments.idid = Numbers.idID) 
                                                                where (ttName = 'Проверка номеров' ) And (dirName != '12 Центр') And (infOut = 1)  and (infDate between '" + startDateTimePicker.Value.ToShortDateString() +
                                                                  @"' and '" + finishDateTimePicker.Value.ToShortDateString() + @"') 
                                                                group by dirName, depName, idNumber, idDate, idDou, infNumber, infDate, infCountNuvbersInfExist ";
                        SqlDataAdapter probAdapter = new SqlDataAdapter(statProvCmdString, connection);
                        DataSet dsProb = new DataSet();
                        dsProb.Tables.Add("Prob");
                        probAdapter.Fill(dsProb, "Prob");
                        BindingSource bsProb = new BindingSource(dsProb, "Prob");
                        statGridView.DataSource = bsProb;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[2].HeaderText = "№ вх. документа";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Дата подписи вх. документа";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[4].HeaderText = "ДОУ";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[5].HeaderText = "№ исх. документа";
                        statGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[6].HeaderText = "Дата подписи исх. документа";
                        statGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[7].HeaderText = "Номеров выявлено";
                        statGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[8].HeaderText = "Номеров всего";
                        statGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;

                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetStat()
        {
            try
            {
                switch (summaryTypeСomboBox.SelectedItem.ToString())
                {

                    case @"Количество материалов/информаций по Управлениям":

                        string matDirCmd = @"select dirName, depName, CAST(COUNT(cid) as varchar) + '/' + CAST (
                                                (select COUNT(mid) 
                                                from Conclutions left join Letters on (Conclutions.lID = Letters.lID) 
                                                left join MaterialLetter on (Letters.lID = MaterialLetter.lID)
                                                left join Operatives on (Conclutions.opID = Operatives.opID) 
                                                left join Departments dep2 on (Operatives.depID = dep2.depID)
                                                left join Directions  dir2 on (dep2.dirID = dir2.dirID)
                                                where (dep1.depID = dep2.depID) and (dir1.dirID = dir2.dirID) and " +
                                                " (letters.ldate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " +
                                                @"group by dir2.dirID, dirName, dep2.depID, depName) as varchar)
                                                from Conclutions left join Letters on (Conclutions.lID = Letters.lID)
                                                left join Operatives on (Conclutions.opID = Operatives.opID)
                                                left join Departments dep1 on (Operatives.depID = dep1.depID)
                                                left join Directions dir1 on (dep1.dirID = dir1.dirID) " +
                                                " where letters.ldate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "' " +
                                                @"group by dir1.dirID, dirName, dep1.depID, depName
                                                order by dirName, depName";
                        SqlDataAdapter matDirAdapter = new SqlDataAdapter(matDirCmd, connection);
                        DataSet dsMatDir = new DataSet();
                        dsMatDir.Tables.Add("MatStatistics");
                        matDirAdapter.Fill(dsMatDir, "MatStatistics");
                        BindingSource bsMatDir = new BindingSource(dsMatDir, "MatStatistics");
                        statGridView.DataSource = bsMatDir;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[2].HeaderText = "Количество материалов/информаций";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;

                    case @"Количество материалов/информаций по пунктам плана":


                        string infPlanCmd =@"select dirName, depName, pNum, pText, CAST(COUNT(cid) as varchar) + '/' + CAST ((select COUNT(mID) from 
                                                    Conclutions left join Letters on (Conclutions.lID = Letters.lID)
                                                    left join MaterialLetter on (Letters.lID = MaterialLetter.lID)
                                                    left join ItemsOfPlan as p2  on (Letters.pID = p2.pID)
                                                    left join Operatives on (Conclutions.opID = Operatives.opID)
                                                    left join Departments dep2 on (Operatives.depID = dep2.depID)
                                                    left join Directions  dir2 on (dep2.dirID = dir2.dirID)  
                                                    where (p1.pID = p2.pID) and (dep1.depID = dep2.depID) and (dir1.dirID = dir2.dirID)
                                                    and (letters.ldate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " +
                                                    @" group by dir2.dirID, dirName, dep2.depID, depName, p2.pID, pNum, pText) as varchar) 
                                                    from 
                                                    Conclutions left join Letters on (Conclutions.lID = Letters.lID)
                                                    left join ItemsOfPlan as p1 on (Letters.pID = p1.pID)
                                                    left join Operatives on (Conclutions.opID = Operatives.opID)
                                                    left join Departments dep1 on (Operatives.depID = dep1.depID)
                                                    left join Directions dir1 on (dep1.dirID = dir1.dirID) " +
                                                    " where letters.ldate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "' " +
                                                    @" group by dir1.dirID, dirName, dep1.depID, depName, p1.pID, pNum, pText
                                                    order by dirName, depName, p1.pID";

                        SqlDataAdapter infPlanAdapter = new SqlDataAdapter(infPlanCmd, connection);
                        DataSet dsPlanDir = new DataSet();
                        dsPlanDir.Tables.Add("InfPlanStatistics");
                        infPlanAdapter.Fill(dsPlanDir, "InfPlanStatistics");
                        statGridView.DataSource = new BindingSource(dsPlanDir, "InfPlanStatistics");
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[2].HeaderText = "Номер пункта плана";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Пункт плана";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[4].HeaderText = "Количество материалов/информаций";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case @"Количество аналитических справок по биллингам по Управлениям":

                        string statInfCmdString = @"SELECT dirName, depName, count(distinct Informations.infID)
                                                        FROM Informations left join IncDocInform on (Informations.infID = IncDocInform.infID)
                                                             left join IncomingDocuments on (IncDocInform.idID = IncomingDocuments.idID)
                                                             left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                             left join Departments on (Operatives.depID = departments.depID)
                                                             left join Directions on (Departments.dirID = Directions.dirID) 
                                                             left join TaskTypes on (TaskTypes.ttID = IncomingDocuments.ttID)
                                                        where (ttName = 'Анализ' ) And (infOut = 1) and (infExist = 1) and (infDate between '" + startDateTimePicker.Value.ToShortDateString() + 
                                                                  @"' and '" + finishDateTimePicker.Value.ToShortDateString() + "') " +
                                                        @" group by dirName, depName
                                                        order by dirName, depName ";
                        SqlDataAdapter statInfAdapter = new SqlDataAdapter(statInfCmdString, connection);
                        DataSet dsInf = new DataSet();
                        dsInf.Tables.Add("InfStatistics");
                        statInfAdapter.Fill(dsInf, "InfStatistics");
                        BindingSource bsIbf = new BindingSource(dsInf, "InfStatistics");
                        statGridView.DataSource = bsIbf;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[2].HeaderText = "Количество справок";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    case @"Количество информаций/материалов/справок из командировок":
                        string statFromMissions = @"select mtName, SUM(wdfmCountInf), SUM(wdfmCountMat), SUM(wdfmCountSpr) from WeekDatasFromMissions
                                                            left join Missions on (Missions.mID = WeekDatasFromMissions.mID)
                                                            left join MissionTargets on (MissionTargets.mtID = Missions.mtID) " +
                                                            " where wdfmDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "'" +
                                                            " group by mtName order by mtname";
                        SqlDataAdapter statFroMissionsAdapter = new SqlDataAdapter(statFromMissions, connection);
                        DataSet dsMissions = new DataSet();
                        dsMissions.Tables.Add("MissionsStatistics");
                        statFroMissionsAdapter.Fill(dsMissions, "MissionsStatistics");
                        BindingSource bsFromMiss = new BindingSource(dsMissions, "MissionsStatistics");
                        statGridView.DataSource = bsFromMiss;
                        statGridView.Columns[0].HeaderText = "Командировки";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Кол-во информаций";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[2].HeaderText = "Кол-во материалов";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Количество справок";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    case @"Количество аналитических справок по биллингам по тематикам":

                        string statInfThemesCmdString = @"SELECT dirName, depName, tName, count(distinct Informations.infID)
                                                        FROM Informations left join IncDocInform on (Informations.infID = IncDocInform.infID)
                                                             left join IncomingDocuments on (IncDocInform.idID = IncomingDocuments.idID)
                                                             left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                             left join Departments on (Operatives.depID = departments.depID)
                                                             left join Directions on (Departments.dirID = Directions.dirID) 
                                                             left join TaskTypes on (TaskTypes.ttID = IncomingDocuments.ttID)
                                                             left join Themes on (Informations.tID = Themes.tID)
                                                        where (ttName = 'Анализ' ) And (infOut = 1) and (infExist = 1) and (infDate between '" + startDateTimePicker.Value.ToShortDateString() +
                                                                  @"' and '" + finishDateTimePicker.Value.ToShortDateString() + "') " +
                                                        @" group by dirName, depName, tName
                                                        order by dirName, depName, tName ";
                        SqlDataAdapter statInfThemesAdapter = new SqlDataAdapter(statInfThemesCmdString, connection);
                        DataSet dsInfThemes = new DataSet();
                        dsInfThemes.Tables.Add("InfThemesStatistics");
                        statInfThemesAdapter.Fill(dsInfThemes, "InfThemesStatistics");
                        BindingSource bsInfThemes = new BindingSource(dsInfThemes, "InfThemesStatistics");
                        statGridView.DataSource = bsInfThemes;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[2].HeaderText = "Тематика";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Количество справок";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    case @"Количество аналитических справок по биллингам по сотрудникам":

                        string statEmp = @"SELECT empNotation, count(distinct Informations.infID)
                                                    FROM Informations left join IncDocInform on (Informations.infID = IncDocInform.infID)
                                                         left join IncomingDocuments on (IncDocInform.idID = IncomingDocuments.idID)
                                                         left join TaskTypes on (TaskTypes.ttID = IncomingDocuments.ttID)
                                                         left join Themes on (Informations.tID = Themes.tID)
	                                                     left join Employees on (IncomingDocuments.empID = Employees.empID)
                                                    where (ttName = 'Анализ' ) And (infOut = 1) and (infExist = 1) 
                                                     and (infDate between '" + startDateTimePicker.Value.ToShortDateString() +
                                                                  @"' and '" + finishDateTimePicker.Value.ToShortDateString() + "') " +
                                                        @" group by empNotation
                                                        order by  count(Informations.infID) desc ";
                        SqlDataAdapter statEmpAdapter = new SqlDataAdapter(statEmp, connection);
                        DataSet dsEmp = new DataSet();
                        dsEmp.Tables.Add("StatEmp");
                        statEmpAdapter.Fill(dsEmp, "StatEmp");
                        BindingSource bsStatEmp = new BindingSource(dsEmp, "StatEmp");
                        statGridView.DataSource = bsStatEmp;
                        statGridView.Columns[0].HeaderText = "Сотрудник";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Количество справок";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    case @"Количество аналитических справок по биллингам по пунктам плана":

                        string statInfPlanCmdString = @"SELECT dirName, depName, ItemsOfPlan.pNum, ItemsOfPlan.pText, count(distinct Informations.infID)
                                                        FROM Informations left join IncDocInform on (Informations.infID = IncDocInform.infID)
                                                             left join IncomingDocuments on (IncDocInform.idID = IncomingDocuments.idID)
                                                             left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                             left join Departments on (Operatives.depID = departments.depID)
                                                             left join Directions on (Departments.dirID = Directions.dirID) 
                                                             left join TaskTypes on (TaskTypes.ttID = IncomingDocuments.ttID)
                                                             left join ItemsOfPlan on (Informations.pID = ItemsOfPlan.pID)
                                                        where (ttName = 'Анализ' ) And (infOut = 1) and (infExist = 1) and (infDate between '" + startDateTimePicker.Value.ToShortDateString() +
                                                                  @"' and '" + finishDateTimePicker.Value.ToShortDateString() + "') " +
                                                        @" group by dirName, depName, ItemsOfPlan.pNum, ItemsOfPlan.pText
                                                        order by dirName, depName, ItemsOfPlan.pNum, ItemsOfPlan.pText ";
                        SqlDataAdapter statInfPlanAdapter = new SqlDataAdapter(statInfPlanCmdString, connection);
                        DataSet dsInfPlan = new DataSet();
                        dsInfPlan.Tables.Add("InfPlanStatistics");
                        statInfPlanAdapter.Fill(dsInfPlan, "InfPlanStatistics");
                        BindingSource bsInfPlan = new BindingSource(dsInfPlan, "InfPlanStatistics");
                        statGridView.DataSource = bsInfPlan;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[2].HeaderText = "Номер пункта плана";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Пункт плана";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[4].HeaderText = "Количество справок";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        break;
                    case @"Количество пробивок номеров по Управлениям":

                        string statProbCmdString = @"SELECT dirName, depName, dtName, count(IncomingDocuments.idID)
                                                        FROM IncomingDocuments 
                                                             left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                             left join Departments on (Operatives.depID = departments.depID)
                                                             left join Directions on (Departments.dirID = Directions.dirID) 
                                                             left join DocTypes on (DocTypes.dtID = IncomingDocuments.dtID)
                                                        where (ttId = 1) and (IncomingDocuments.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " +
                                                        @"group by dirName, depName, dtName
                                                        order by dirName, depName, dtName";
                        SqlDataAdapter statProbAdapter = new SqlDataAdapter(statProbCmdString, connection);
                        DataSet dsProb = new DataSet();
                        dsProb.Tables.Add("ProbStatistics");
                        statProbAdapter.Fill(dsProb, "ProbStatistics");
                        BindingSource bsProb = new BindingSource(dsProb, "ProbStatistics");
                        statGridView.DataSource = bsProb;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[2].HeaderText = "Тип пробивки";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[3].HeaderText = "Количество пробивок";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    case @"Количество номеров в пробивках по Управлениям":

                        string statNumProbCmdString = @"SELECT dirName, depName, dtName, count(distinct phoneNumber)
                                                             FROM IncomingDocuments left join Numbers on (IncomingDocuments.idID = Numbers.idID)
                                                             left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                             left join Departments on (Operatives.depID = departments.depID)
                                                             left join Directions on (Departments.dirID = Directions.dirID) 
                                                             left join DocTypes on (DocTypes.dtID = IncomingDocuments.dtID)
                                                        where (ttID = 1 ) and (IncomingDocuments.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " +
                                                        @"group by dirName, depName, dtName
                                                        order by dirName, depName, dtName";
                        SqlDataAdapter statNumProbAdapter = new SqlDataAdapter(statNumProbCmdString, connection);
                        DataSet dsNumProb = new DataSet();
                        dsNumProb.Tables.Add("NumProbStatistics");
                        statNumProbAdapter.Fill(dsNumProb, "NumProbStatistics");
                        BindingSource bsNumProb = new BindingSource(dsNumProb, "NumProbStatistics");
                        statGridView.DataSource = bsNumProb;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[2].HeaderText = "Тип пробивки";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        statGridView.Columns[3].HeaderText = "Количество номеров";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    case @"Количество найденых номеров в пробивках по Управлениям":
                        string statExistNumString = @"select dir1.dirName, dep1.depName, 
				                                                    (
				                                                    select count(distinct id3.idID)
				                                                    from Directions dir3
				                                                    left join Departments dep3 on (dir3.dirID = dep3.dirID)
				                                                    left join Operatives op3 on (op3.depID = dep3.depID)
				                                                    left join IncomingDocuments id3 on (id3.opID = op3.opID)
				                                                    left join TaskTypes t3 on (t3.ttID = id3.ttID)
				                                                    where (id3.ttID = 1) and (dir1.dirID = dir3.dirID) and (dep1.depID = dep3.depID) and (id3.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " + @"
				                                                    group by dir3.dirID,dep3.depID
				                                                    ),	
                                                                    COUNT(Numbers.phoneNumber),
                                                                    (
			                                                        select count(distinct inf4.infID) 
			                                                        from Directions dir4
			                                                        left join Departments dep4 on (dir4.dirID = dep4.dirID)
			                                                        left join Operatives op4 on (op4.depID = dep4.depID)
			                                                        left join IncomingDocuments id4 on (id4.opID = op4.opID)
			                                                        left join IncDocInform idi4 on (idi4.idID = id4.idID)
			                                                        left join Informations inf4 on (idi4.infID = inf4.infID)
			                                                        where (dir1.dirID = dir4.dirID) and (dep1.depID = dep4.depID) and (inf4.infCountNuvbersInfExist > 0) and (id4.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " + @"
			                                                        group by dir4.dirID, dir4.dirName, dep4.depID, dep4.depName
                                                                    ),							                                                     
				                                                    (select SUM(inf2.infCountNuvbersInfExist) from Directions dir2
				                                                    left join Departments dep2 on (dir2.dirID = dep2.dirID)
				                                                    left join Operatives op2 on (op2.depID = dep2.depID)
				                                                    left join IncomingDocuments id2 on (id2.opID = op2.opID)
				                                                    left join TaskTypes t2 on (t2.ttID = id2.ttID)
				                                                    left join IncDocInform on (IncDocInform.idID = id2.idID)
				                                                    left join Informations inf2 on (inf2.infID = IncDocInform.infID)
				                                                    where (id2.ttID = 1) and (dir1.dirID = dir2.dirID) and
				                                                     (dep1.depID = dep2.depID) and (id2.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " + @"
				                                                    group by dir2.dirID,dep2.depID
				                                                    ) 
                                                    from Directions dir1
                                                    left join Departments dep1 on (dir1.dirID = dep1.dirID)
                                                    left join Operatives op1 on (op1.depID = dep1.depID)
                                                    left join IncomingDocuments id1 on (id1.opID = op1.opID)
                                                    left join TaskTypes t1 on (t1.ttID = id1.ttID)
                                                    left join Numbers on (Numbers.idID = id1.idID)
                                                    where (id1.ttID = 1) and (id1.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " + @"
                                                    group by dir1.dirID, dir1.dirName, dep1.depID, dep1.depName
                                                    order by dir1.dirName, dep1.depName";
                        SqlDataAdapter statExistNumAdapter = new SqlDataAdapter(statExistNumString, connection);
                        DataSet dsExNum = new DataSet();
                        dsExNum.Tables.Add("ExistsNumbers");
                        statExistNumAdapter.Fill(dsExNum, "ExistsNumbers");
                        BindingSource bsExistNum = new BindingSource(dsExNum, "ExistsNumbers");
                        statGridView.DataSource = bsExistNum;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[2].HeaderText = "Количество запросов";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Количество номеров в запросах";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[4].HeaderText = "Количество ответов, содержащих информацию";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[5].HeaderText = "Количество номеров, по которым реализована информация";
                        statGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case @"Количество найденых номеров в пробивках по странам":
                        string statCountryExistNumString = @"select dir1.dirName, dep1.depName, ct1.ctName, 
				                                                    (
				                                                    select count(*)
				                                                    from Directions dir3
				                                                    left join Departments dep3 on (dir3.dirID = dep3.dirID)
				                                                    left join Operatives op3 on (op3.depID = dep3.depID)
				                                                    left join IncomingDocuments id3 on (id3.opID = op3.opID)
				                                                    left join TaskTypes t3 on (t3.ttID = id3.ttID)
                                                                    left join Countries ct3 on (id3.ctID = ct3.ctID)
				                                                    where (id3.ttID = 1) and (dir1.dirID = dir3.dirID) and (dep1.depID = dep3.depID) and (ct1.ctID = ct3.ctID) and (id3.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " + @"
				                                                    group by dir3.dirID,dep3.depID
				                                                    ),	
                                                                    COUNT(Numbers.phoneNumber),
                                                                    (
			                                                        select count(distinct inf4.infID) 
			                                                        from Directions dir4
			                                                        left join Departments dep4 on (dir4.dirID = dep4.dirID)
			                                                        left join Operatives op4 on (op4.depID = dep4.depID)
			                                                        left join IncomingDocuments id4 on (id4.opID = op4.opID)
			                                                        left join IncDocInform idi4 on (idi4.idID = id4.idID)
			                                                        left join Informations inf4 on (idi4.infID = inf4.infID)
                                                                    left join Countries ct4 on (id4.ctID = ct4.ctID)
			                                                        where (dir1.dirID = dir4.dirID) and (dep1.depID = dep4.depID) and (ct1.ctID = ct4.ctID) and (inf4.infCountNuvbersInfExist > 0) and (id4.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " + @"
			                                                        group by dir4.dirID, dir4.dirName, dep4.depID, dep4.depName
                                                                    ),							                                                     
				                                                    (select SUM(inf2.infCountNuvbersInfExist) from Directions dir2
				                                                    left join Departments dep2 on (dir2.dirID = dep2.dirID)
				                                                    left join Operatives op2 on (op2.depID = dep2.depID)
				                                                    left join IncomingDocuments id2 on (id2.opID = op2.opID)
				                                                    left join TaskTypes t2 on (t2.ttID = id2.ttID)
				                                                    left join IncDocInform on (IncDocInform.idID = id2.idID)
				                                                    left join Informations inf2 on (inf2.infID = IncDocInform.infID)
                                                                    left join Countries ct2 on (id2.ctID = ct2.ctID)
				                                                    where (id2.ttID = 1) and (dir1.dirID = dir2.dirID) and (ct1.ctID = ct2.ctID) and
				                                                     (dep1.depID = dep2.depID) and (id2.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " + @"
				                                                    group by dir2.dirID,dep2.depID
				                                                    ) 
                                                    from Directions dir1
                                                    left join Departments dep1 on (dir1.dirID = dep1.dirID)
                                                    left join Operatives op1 on (op1.depID = dep1.depID)
                                                    left join IncomingDocuments id1 on (id1.opID = op1.opID)
                                                    left join TaskTypes t1 on (t1.ttID = id1.ttID)
                                                    left join Numbers on (Numbers.idID = id1.idID)
                                                    left join Countries ct1 on (id1.ctID = ct1.ctID)
                                                    where (id1.ttID = 1) and (id1.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + "') " + @"
                                                    group by dir1.dirID, dir1.dirName, dep1.depID, dep1.depName, ct1.ctID, ct1.ctName
                                                    order by dir1.dirName, dep1.depName, ct1.ctName";
                        SqlDataAdapter statCountryExistNumAdapter = new SqlDataAdapter(statCountryExistNumString, connection);
                        DataSet dsCoExNum = new DataSet();
                        dsCoExNum.Tables.Add("ExistsNumbers");
                        statCountryExistNumAdapter.Fill(dsCoExNum, "ExistsNumbers");
                        BindingSource bsCoExistNum = new BindingSource(dsCoExNum, "ExistsNumbers");
                        statGridView.DataSource = bsCoExistNum;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[2].HeaderText = "Страна";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Количество запросов";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[4].HeaderText = "Количество номеров в запросах";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[5].HeaderText = "Количество ответов, содержащих информацию";
                        statGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[6].HeaderText = "Количество номеров, по которым реализована информация";
                        statGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case @"Количество пробивок и номеров по статьям УК РФ":
                        string statNumUKCmdString = @"select dir1.dirName, dep1.depName, t1.ttName, i1.ukNumber, count(*), 
                                                        (select count(Numbers.phoneNumber)  from IncomingDocuments i2
                                                        join Operatives on (i2.opID = Operatives.opID)
                                                        join Departments dep2 on (dep2.depID = Operatives.depID)
                                                        join Directions dir2 on (dep2.dirID = dir2.dirID)
                                                        join Numbers on (Numbers.idID = i2.idID)
                                                        join TaskTypes t2 on (i2.ttID = t2.ttID)
                                                        where (i2.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + @"')  and 
                                                              (dir1.dirID = dir2.dirID) and 
                                                              (dep2.depID = dep1.depID) and 
                                                              ((i1.ukNumber = i2.ukNumber) or ((i1.ukNumber is null) and (i2.ukNumber is null))) and 
                                                              (t1.ttID = t2.ttID)
                                                        group by dir2.dirID,dep2.depID, i2.ttID, i2.ukNumber)  

                                                        from IncomingDocuments i1
                                                        join Operatives on (i1.opID = Operatives.opID)
                                                        join Departments dep1 on (dep1.depID = Operatives.depID)
                                                        join Directions dir1 on (dep1.dirID = dir1.dirID)
                                                        join TaskTypes t1 on (i1.ttID = t1.ttID)
                                                        where (i1.idSectionDate between '" + startDateTimePicker.Value.ToShortDateString() + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + @"')  and  
                                                        (dir1.dirName <> '12 Центр') and (i1.dtID = 1)
                                                        group by dir1.dirID, dir1.dirName, dep1.depID, dep1.depName, t1.ttID, t1.ttName, i1.ukNumber
                                                        order by dir1.dirName, dep1.depName, t1.ttName, i1.ukNumber";
                        SqlDataAdapter statNumUKAdapter = new SqlDataAdapter(statNumUKCmdString, connection);
                        DataSet dsNumUk = new DataSet();
                        dsNumUk.Tables.Add("statNumUK");
                        statNumUKAdapter.Fill(dsNumUk, "statNumUK");
                        BindingSource bsNumUK = new BindingSource(dsNumUk, "statNumUK");
                        statGridView.DataSource = bsNumUK;
                        statGridView.Columns[0].HeaderText = "Служба";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Управление";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[2].HeaderText = "Тип задачи";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Статья УК РФ";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[4].HeaderText = "Количество запросов";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[5].HeaderText = "Количество номеров";
                        statGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    case @"Материалы анализа эффективности проведенных мероприятий":
                            DataSet ds = new DataSet();
                            string result = @"";
                            string help = @"";
                            ds.Tables.Add("Statistics");
                            ds.Tables["Statistics"].Columns.Add("num");
                            ds.Tables["Statistics"].Columns.Add("caption");
                            ds.Tables["Statistics"].Columns.Add("count");
#region Пункт 1
                            string cmdStr = "SELECT count(*) FROM Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID " + 
                                            "WHERE Letters.lDate Between " +
                                            "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "' ";
                            SqlCommand command = new SqlCommand(cmdStr, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                result = reader[0].ToString();
                            }
                            reader.Close();
                            command.CommandText = "SELECT count(*) FROM (Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID) INNER JOIN MaterialLetter ON Letters.lID = MaterialLetter.lID "
                                                  + "WHERE Letters.lDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "' ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result = result + "(" + help + ")";
                            ds.Tables["Statistics"].Rows.Add("1.",
                                                            @"Направлено в оперативные подразделения органов безопасности информационных документов, содержащих оперативно-важную информацию о терроризме, деятельности незаконных вооруженных формирований на территории СКР, коррупции, контрабанде, незаконном обороте оружия и наркотических средствах, а также о противоправных действиях в сфере экономики, кредитно-финансовой системе и иных преступлениях, расследование которых отнесено законом к ведению органов Федеральной службы безопасности (указывается количество писем и количество содержащихся в них информаций)", 
                                                              result);
#endregion
#region Пункт 2                            
                            result = "";
                            help = "";
                            command.CommandText = @"SELECT count(*) FROM Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID
                                                    where (Letters.lAddition = 0) " +
                                                   "AND (Letters.lDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result =  help;
                            ds.Tables["Statistics"].Rows.Add("2.",
                                                            @"Направлено заключений (бланков) на информацию", 
                                                              result);
#endregion
#region Пункт 3                            
                            result = "";
                            help = "";
                            command.CommandText = @"SELECT count(*) FROM Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID
                                                    where (Letters.lAddition = 0) AND  (Conclutions.mrID is not null) and (Conclutions.cRating is not null)" +
                                                   "AND (Conclutions.cReturnDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result =  help;


                            command.CommandText = @"SELECT count(*) FROM Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID
                                                    where (Letters.lAddition = 0) AND  (Conclutions.cRating > 1) and (Conclutions.mrID is not null)" +
                                                   "AND (Conclutions.cReturnDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result = result + "/" + help;


                            ds.Tables["Statistics"].Rows.Add("3.",
                                                            @"Получено всего отзывов с оценкой информации/с положительной оценкой", 
                                                              result);
#endregion
                            ds.Tables["Statistics"].Rows.Add("4.",
                                                                "Количество 'ценных' информаций (кратко указать о чем материал и каким органом безопасности оценен)",
                                                                  "");
                            ds.Tables["Statistics"].Rows.Add("5.",
                                    "На основании реализованных радиоконтрразведкой материалов оперативными подразделениями органов безопасности:",
                                      "");
#region Пункт 5.1                           
                            result = "";
                            help = "";
                            command.CommandText = @"SELECT Count(*) 
                                                    FROM MatResults INNER JOIN (Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID) ON MatResults.mrID = Conclutions.mrID " +
                                                    "where (Letters.lAddition = 0) and (MatResults.mrID = 1) " +
                                                   "AND (Conclutions.cReturnDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result =  help;
                            ds.Tables["Statistics"].Rows.Add("",
                                                            @"- заведены ДОУ, ДОБОИ, ДОРоз, ДОТД, СП и т.п. (указать название, номер дела, статью УК России, каким органом безопасности заведено)", 
                                                              result);
#endregion
#region Пункт 5.2                           
                            result = "";
                            help = "";
                            command.CommandText = @"SELECT Count(*)
                                                    FROM MatResults INNER JOIN (Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID) ON MatResults.mrID = Conclutions.mrID " +
                                                    "where (Letters.lAddition = 0) and (MatResults.mrID = 2) " +
                                                   "AND (Conclutions.cReturnDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result =  help;
                            ds.Tables["Statistics"].Rows.Add("",
                                                            @"- учтено (использовано в работе по линии работы (в том числе в рамках ДОУ, ДОБОИ, ДОРоз, ДОТД, СП и т.п.) (указать, кем учтены (использованы) материалы)", 
                                                              result);
#endregion
#region Пункт 5.3                           
                            result = "";
                            help = "";
                            command.CommandText = @"SELECT Count(*) 
                                                    FROM MatResults INNER JOIN (Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID) ON MatResults.mrID = Conclutions.mrID " +
                                                    "where (Letters.lAddition = 0) and (MatResults.mrID = 3) " +
                                                   "AND (Conclutions.cReturnDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result =  help;
                            ds.Tables["Statistics"].Rows.Add("",
                                                            @"- проводятся (проведены) проверочные мероприятия", 
                                                              result);
#endregion
#region Пункт 5.4                           
                            result = "";
                            help = "";
                            command.CommandText = @"SELECT Count(*)
                                                    FROM MatResults INNER JOIN (Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID) ON MatResults.mrID = Conclutions.mrID " +
                                                    "where (Letters.lAddition = 0) and (MatResults.mrID = 4) " +
                                                   "AND (Conclutions.cReturnDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result =  help;
                            ds.Tables["Statistics"].Rows.Add("",
                                                            @"- в том числе ориентированы (информированы, направлены в) другие заинтересованные подразделения органов безопасности и иные подразделения федеральных органов исполнительной власти", 
                                                              result);
#endregion
#region Пункт 5.5                           
                            result = "";
                            help = "";
                            command.CommandText = @"SELECT count(*)
                                                    FROM InterestAboutAddition INNER JOIN (Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID) ON InterestAboutAddition.inID = Conclutions.inID " +
                                                    "where (Letters.lAddition = 0) and (Conclutions.inID = 1) " +
                                                   "AND (Conclutions.cReturnDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                        result = help;
                            reader.Close();
                            command.CommandText = @"SELECT count(*)
                                                    FROM InterestAboutAddition INNER JOIN (Letters INNER JOIN Conclutions ON Letters.lID = Conclutions.lID) ON InterestAboutAddition.inID = Conclutions.inID " +
                                                    "where (Letters.lAddition = 0) and (Conclutions.inID = 2) " +
                                                   "AND (Conclutions.cReturnDate Between " +
                                                  "'" + startDateTimePicker.Value.ToShortDateString() + "' And '" + finishDateTimePicker.Value.ToShortDateString() + "') ";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                help = reader[0].ToString();
                            }
                            reader.Close();
                            result =  result + "/" + help;
                            ds.Tables["Statistics"].Rows.Add("",
                                                            @"- органами безопасности выражена заинтересованность в получении подобной (дополнительной, иной) информации/незаинтересованность", 
                                                              result);
#endregion
                            BindingSource bs = new BindingSource(ds, "Statistics");
                            statGridView.DataSource = bs;
                            statGridView.Columns[0].HeaderText = "№";
                            statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            statGridView.Columns[1].HeaderText = "Описание";
                            statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            statGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            statGridView.Columns[2].HeaderText = "Количество";
                            statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetOtdStat()
        {
            try
            {
                string cmdText = "";
                SqlDataAdapter adapter;
                DataSet ds;
                BindingSource bs;
                switch (forOtdComboBox.SelectedItem.ToString())
                {
                    case "Количество выявленных первичек по постам":
                        cmdText = @" select mpost, count(*) from Materials
                                     where (Materials.mFirstReveal) = 1 and (mDateTime between '" + startDateTimePicker.Value.ToShortDateString() + " 00:00:00" + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + " 23:59:59" + "') " +
                                     " group by mPost";
                        adapter = new SqlDataAdapter(cmdText, connection);
                        ds = new DataSet();
                        ds.Tables.Add("Stat");
                        adapter.Fill(ds, "Stat");
                        bs = new BindingSource(ds, "Stat");
                        statGridView.DataSource = bs;
                        statGridView.Columns[0].HeaderText = "Пост";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Количество";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case "Количество выявленных первичек по сотрудникам":
                        cmdText = @" select empNotation, count(*), (select count(distinct Materials.mID) from Materials
                                        join MaterialLetter on (MaterialLetter.mID = Materials.mID)
                                        join Employees e2 on (e2.empID = Materials.empID)
                                         where ((Materials.mFirstReveal) = 1) and (e1.empNotation = e2.empNotation) and (mDateTime between '" + startDateTimePicker.Value.ToShortDateString() + " 00:00:00" + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + " 23:59:59" + "') " +
                                        @"group by empNotation) 
                                         from Materials m1
                                         left join Employees e1 on (e1.empID = m1.empID)
                                         where (m1.mFirstReveal) = 1 and (mDateTime between '" + startDateTimePicker.Value.ToShortDateString() + " 00:00:00" + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + " 23:59:59" + "') " +
                                     "group by empNotation";
                        adapter = new SqlDataAdapter(cmdText, connection);
                        ds = new DataSet();
                        ds.Tables.Add("Stat");
                        adapter.Fill(ds, "Stat");
                        bs = new BindingSource(ds, "Stat");
                        statGridView.DataSource = bs;
                        statGridView.Columns[0].HeaderText = "Пост";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Количество выявленных";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[2].HeaderText = "Количество реализованных";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case "Количество выявленных первичек по базовым станциям":
                        cmdText = @" select mBaseStation, count(*), (select  count(*) from Materials m2
                                        join MaterialLetter on (m2.mID = MaterialLetter.mID)
                                        where ((m2.mFirstReveal) = 1) and (m1.mBaseStation = m2.mBaseStation)
                                        group by mBaseStation) 
                                        from Materials m1
                                        where (m1.mFirstReveal) = 1 and (mDateTime between '" + startDateTimePicker.Value.ToShortDateString() + " 00:00:00" + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + " 23:59:59" + "') " +
                                     "group by mBaseStation";
                        adapter = new SqlDataAdapter(cmdText, connection);
                        ds = new DataSet();
                        ds.Tables.Add("Stat");
                        adapter.Fill(ds, "Stat");
                        bs = new BindingSource(ds, "Stat");
                        statGridView.DataSource = bs;
                        statGridView.Columns[0].HeaderText = "Пост";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Количество выявленных";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[2].HeaderText = "Количество реализованных";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                    case "Реализованные первички":
                        cmdText = @" select Materials.mID, empNotation, mDateTime, mDuration,  pText, dirName, depName, opNotation, opOS, cRating, mrName, cText
                                            from Materials
                                            join MaterialLetter on (MaterialLetter.mID = Materials.mID)
											join Letters on (Letters.lID = MaterialLetter.lID)
                                            join Conclutions on (Conclutions.lID = Letters.lID)
                                            join Operatives on (Operatives.opID = Conclutions.opID)
                                            join Departments on (Departments.depID = Operatives.depID)
                                            join Directions on (Directions.dirID = Departments.dirID)
                                            left join MatResults on (MatResults.mrID = Conclutions.mrID)
											join Employees on (Employees.empID = Materials.empID)
                                            left join ItemsOfPlan on (ItemsOfPlan.pID = Letters.pID)
                                     where (Materials.mFirstReveal) = 1 and (mDateTime between '" + startDateTimePicker.Value.ToShortDateString() + " 00:00:00" + "' AND '" + finishDateTimePicker.Value.ToShortDateString() + " 23:59:59" + "') " +
                                  " order by mDateTime";
                        adapter = new SqlDataAdapter(cmdText, connection);
                        ds = new DataSet();
                        ds.Tables.Add("Stat");
                        adapter.Fill(ds, "Stat");
                        bs = new BindingSource(ds, "Stat");
                        statGridView.DataSource = bs;
                        statGridView.Columns[0].HeaderText = "mID";
                        statGridView.Columns[0].Visible = false;
                        statGridView.Columns[1].HeaderText = "Сотрудник";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[2].HeaderText = "Дата/Время";
                        statGridView.Columns[2].DefaultCellStyle.Format = "dd.MM.yy HH:mm:ss";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Длительность";
                        statGridView.Columns[3].DefaultCellStyle.Format = "HH:mm:ss";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[4].HeaderText = "Пункт плана";
                        statGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[5].HeaderText = "Служба";
                        statGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[6].HeaderText = "Управление";
                        statGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[7].HeaderText = "Оперативник";
                        statGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[8].HeaderText = "ОС";
                        statGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;                      
                        statGridView.Columns[9].HeaderText = "Оценка";
                        statGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[10].HeaderText = "Результат";
                        statGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[10].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.Columns[11].HeaderText = "Комментарий";
                        statGridView.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        statGridView.Columns[11].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        statGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        break;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        
        private int GetNaprStat()
        {
            try
            {
                string cmdText = "";
                SqlDataAdapter adapter;
                DataSet ds;
                BindingSource bs;
                switch (forNaprComboBox.SelectedItem.ToString())
                {
                    case "Количество обработанных документов и номеров":
                        cmdText = @"select * from (
                                    select  empNotation, ttName, count(distinct IncomingDocuments.idID) as countDocs, count(Numbers.phoneNumber) as countNumbers from Employees
                                    left join IncomingDocuments on (IncomingDocuments.empID = Employees.empID)
                                    full join TaskTypes on (TaskTypes.ttID = IncomingDocuments.ttID)
                                    left join Numbers on (Numbers.idID = IncomingDocuments.idID)
                                    where (ssID = 3) and (idExecuted = 1) and (IncomingDocuments.idSectionDate  between '" + 
                                          startDateTimePicker.Value.ToShortDateString() + @"' and '" +
                                          finishDateTimePicker.Value.ToShortDateString() + @"')
                                    group by empNotation, ttName
  
                                    union all

                                    select empNotation, 'Материалы радиопереговоров', count(distinct Letters.lID) as countMat, count (MaterialLetter.mid) as countInf from Employees 
                                    left join Letters on (Letters.empID = Employees.empID)
                                    join MaterialLetter on (Letters.lID = MaterialLetter.lID)
                                    where (ssID = 3) and (Letters.lDate  between '" +
                                          startDateTimePicker.Value.ToShortDateString() + @"' and '" +
                                          finishDateTimePicker.Value.ToShortDateString() + @"')
                                    group by empNotation
                                    ) as fullStat
                                    order by empNotation, ttName";
                        adapter = new SqlDataAdapter(cmdText, connection);
                        ds = new DataSet();
                        ds.Tables.Add("Stat");
                        adapter.Fill(ds, "Stat");
                        bs = new BindingSource(ds, "Stat");
                        statGridView.DataSource = bs;
                        statGridView.Columns[0].HeaderText = "Сотрудник";
                        statGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[1].HeaderText = "Тип задачи";
                        statGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[2].HeaderText = "Количество документов";
                        statGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        statGridView.Columns[3].HeaderText = "Количество номеров";
                        statGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void statTypeСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculatButton.Enabled = true;
        }

        private void calculatBeutton_Click(object sender, EventArgs e)
        {
            
            bool isDataExist = false;
            if (weekRadioButton.Checked)
            {
                if (weekStatTypeСomboBox.SelectedIndex >= 0)
                {
                    if (GetWeekStat() == 0) isDataExist = true;
                }
                else
                {
                    MessageBox.Show("Выберите пункт, по которому надо подсчитать статистику", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (summaryRadioButton.Checked)
                {
                    if (summaryTypeСomboBox.SelectedIndex >= 0)
                    {
                        if (GetStat() == 0) isDataExist = true;
                    }
                    else
                    {
                        MessageBox.Show("Выберите пункт, по которому надо подсчитать статистику", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (forOtdRadioButton.Checked)
                    {
                        if (forOtdComboBox.SelectedIndex >= 0)
                        {
                            if (GetOtdStat() == 0) isDataExist = true;
                        }
                        else
                        {
                            MessageBox.Show("Выберите пункт, по которому надо подсчитать статистику", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        if (forNaprRadioButton.Checked)
                        {
                            if (forNaprComboBox.SelectedIndex >= 0)
                            {
                                if (GetNaprStat()==0) isDataExist = true;
                            }
                            else
                            {
                                MessageBox.Show("Выберите пункт, по которому надо подсчитать статистику", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                    }
                }
            }
            if (isDataExist) saveReportButton.Enabled = true;
        }

        private void weekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SwitchOffComboBoxes();
            weekStatTypeСomboBox.Enabled = true;
        }

        private void summaryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SwitchOffComboBoxes();
            summaryTypeСomboBox.Enabled = true;
            
        }
        private void forOtdRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SwitchOffComboBoxes();
            forOtdComboBox.Enabled = true;
            
        }
        private void forNaprRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SwitchOffComboBoxes();
            forNaprComboBox.Enabled = true;
        }
        
        private void summaryTypeСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculatButton.Enabled = true;
        }

        private void saveReportButton_Click(object sender, EventArgs e)
        {
            if (saveReportFile.ShowDialog() == DialogResult.OK)
            {
                if (SaveReportToFile(statGridView, saveReportFile.FileName) == 0)
                    MessageBox.Show("Экспорт завершен успешно","Информация", MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Экспорт завершен с ошибкой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Не выбран файл для экспорта результатов.", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void forOtdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculatButton.Enabled = true;
        }

        private void statGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
                {
                    statGridView.CurrentCell = statGridView[e.ColumnIndex, e.RowIndex];
                    statGridView.CurrentRow.Selected = true;
                    DataGridViewRow row = new DataGridViewRow();
                    row = statGridView.Rows[e.RowIndex];
                    if (forOtdRadioButton.Checked)
                    {
                        if (forOtdComboBox.SelectedItem.ToString() == "Реализованные первички") contextMenu.Show(MousePosition.X, MousePosition.Y);
                    }
                }
            }
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            if (statGridView.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = statGridView.CurrentCell.RowIndex;
                row = statGridView.Rows[i];
                MaterialEditForm matEditForm = new MaterialEditForm(connection, false, (int)row.Cells[0].Value);
                matEditForm.ShowDialog();
                if (matEditForm.IsChanged) GetOtdStat();

            }
        }

        private void forNaprComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculatButton.Enabled = true;
        }




    }
}
