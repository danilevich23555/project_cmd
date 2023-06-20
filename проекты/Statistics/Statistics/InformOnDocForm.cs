using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class InformOnDocForm : Form
    {
        private SqlConnection connection;
        private int tascType;

        private int GetDocs()
        {
            switch (tascType)
            {
                case 1:
                    this.Text = @"Документы в работе";
                   // GetInfAboutDoc();
                    break;
                case 2:
                    this.Text = @"Просроченные и непродленные документы в работе";
                    //GetInfAboutDoc();
                    break;
                default:
                    this.Text = @"";
                    break;
            }
            return GetInfAboutDoc();
            
        }
        private string GetDateAccessFormat(DateTime date)
        {
            return date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
        }
        public InformOnDocForm(SqlConnection connection, int tascType)
        {
            this.connection = connection;
            this.tascType = tascType;
            InitializeComponent();
        }
        private int GetInfAboutDoc()
        {
            try
            {
                string cmdStr = "";
                switch (tascType)
                {
                    case 1:
                        cmdStr = @"SELECT Employees.empNotation, 
	                                       IncomingDocuments.idNumber, 
	                                       DocTypes.dtName, 
	                                       TaskTypes.ttName, 
	                                       case IncomingDocuments.idExpress
	                                       when 1 then 'Срочный'
	                                       when 0 then ''
	                                       end, 
  	                                       case IncomingDocuments.idProlonged
	                                       when 1 then 'Продленный'
	                                       when 0 then ''
	                                       end, 
	                                       IncomingDocuments.idFinishDate, 
	                                       Count(Numbers.phoneNumber), 
	                                       IncomingDocuments.idID
                                    from   IncomingDocuments left join  Numbers on (Numbers.idID = IncomingDocuments.idID)
	                                                                                    left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                                                        left join Departments on (Operatives.depID = departments.depID)
                                                                                        left join Directions on (Departments.dirID = Directions.dirID) 
                                                                                        left join Employees on (Employees.empID = IncomingDocuments.empID)
													                                    left join DocTypes on (IncomingDocuments.dtID = DocTypes.dtID)
													                                    left join TaskTypes on (IncomingDocuments.ttID = TaskTypes.ttID)
                                    where IncomingDocuments.idExecuted = 0
                                    group by Employees.empNotation, IncomingDocuments.idNumber, DocTypes.dtName, TaskTypes.ttName, IncomingDocuments.idExpress, IncomingDocuments.idProlonged, IncomingDocuments.idFinishDate,IncomingDocuments.idID
                                    ORDER BY Employees.empNotation, IncomingDocuments.idFinishDate";
                         break;
                    case 2:
                         cmdStr = @"SELECT Employees.empNotation, 
	                                       IncomingDocuments.idNumber, 
	                                       DocTypes.dtName, 
	                                       TaskTypes.ttName, 
	                                       case IncomingDocuments.idExpress
	                                       when 1 then 'Срочный'
	                                       when 0 then ''
	                                       end, 
  	                                       case IncomingDocuments.idProlonged
	                                       when 1 then 'Продленный'
	                                       when 0 then ''
	                                       end, 
	                                       IncomingDocuments.idFinishDate, 
	                                       Count(Numbers.phoneNumber), 
	                                       IncomingDocuments.idID
                                    from   IncomingDocuments left join  Numbers on (Numbers.idID = IncomingDocuments.idID)
	                                                                                    left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                                                        left join Departments on (Operatives.depID = departments.depID)
                                                                                        left join Directions on (Departments.dirID = Directions.dirID) 
                                                                                        left join Employees on (Employees.empID = IncomingDocuments.empID)
													                                    left join DocTypes on (IncomingDocuments.dtID = DocTypes.dtID)
													                                    left join TaskTypes on (IncomingDocuments.ttID = TaskTypes.ttID)
                                    where (IncomingDocuments.idExecuted = 0) AND (IncomingDocuments.idFinishDate < '" + DateTime.Now.ToShortDateString() +"') " +
                                    @"group by Employees.empNotation, IncomingDocuments.idNumber, DocTypes.dtName, TaskTypes.ttName, IncomingDocuments.idExpress, IncomingDocuments.idProlonged, IncomingDocuments.idFinishDate,IncomingDocuments.idID
                                    ORDER BY Employees.empNotation, IncomingDocuments.idFinishDate";

                        break;
                    default:
                        this.Text = @"";
                        break;                     
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Information");
                adapter.Fill(ds, "Information");
                BindingSource bs = new BindingSource(ds, "Information");
                docsDataGrid.DataSource = bs;
                docsDataGrid.Columns[0].HeaderText = "Исполнитель";
                docsDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                docsDataGrid.Columns[1].HeaderText = "Номер документа";
                docsDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                docsDataGrid.Columns[2].HeaderText = "Тип документа";
                docsDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                docsDataGrid.Columns[3].HeaderText = "Тип задачи";
                docsDataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                docsDataGrid.Columns[4].HeaderText = "Срочный";
                docsDataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                docsDataGrid.Columns[5].HeaderText = "Продленный";
                docsDataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                docsDataGrid.Columns[6].HeaderText = "Срок исполнения";
                docsDataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                docsDataGrid.Columns[7].HeaderText = "Количество номеров";
                docsDataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                docsDataGrid.Columns[8].Visible = false;
                docsDataGrid.Columns[8].HeaderText = "idID";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void InformOnDocForm_Load(object sender, EventArgs e)
        {
            if (GetDocs() != 0) Close();
        }

        private void docsDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
                {
                    docsDataGrid.CurrentCell = docsDataGrid[e.ColumnIndex, e.RowIndex];
                    docsDataGrid.CurrentRow.Selected = true;
                    DataGridViewRow row = new DataGridViewRow();
                    row = docsDataGrid.Rows[e.RowIndex];
                    contextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
            else
            {
                if ((e.Button == System.Windows.Forms.MouseButtons.Left) & (e.Clicks == 2))
                {
                    openDocumentMenu_Click(sender, e);
                }
            }

        }

        private void openDocumentMenu_Click(object sender, EventArgs e)
        {
            DataGridView dataGrid = new DataGridView();
            dataGrid = docsDataGrid;
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                IncomingDocumentEditForm idEditForm = new IncomingDocumentEditForm(connection,false, (int)row.Cells[8].Value);
                idEditForm.ShowDialog();
                if (idEditForm.IsChanged)
                {
                    GetDocs();

                }
            }
        }
    }
}
