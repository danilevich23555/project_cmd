using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forD
{
    public partial class DeleteForm : Form
    {
        private string server;
        private string schema;
        private string post;
        public DeleteForm(string server, string schema, string post)
        {
            this.server = server;
            this.schema = schema;
            this.post = post;
            InitializeComponent();
        }
        private string GetWhere()
        {
            string where = "";
            bool existWhere = false;
            where = "(s_postID = '" + post + "')";
            if ((smsCheckBox.Checked) | (IMEICheckBox.Checked) | (billingCheckBox.Checked))
            {
                if ((smsCheckBox.Checked) & (IMEICheckBox.Checked) & (billingCheckBox.Checked))
                {

                }
                else
                {
                    where += " and (";
                    if (billingCheckBox.Checked)
                    {
                        if (!existWhere)
                        {
                            where += "(S_SOURCENAME = 'billing')";
                            existWhere = true;
                        }
                        else
                        {
                            where += " or (S_SOURCENAME = 'billing')";
                            existWhere = true;
                        }
                    }
                    if (IMEICheckBox.Checked)
                    {
                        if (!existWhere)
                        {
                            where += "(S_SOURCENAME = 'imei')";
                            existWhere = true;
                        }
                        else
                        {
                            where += " or (S_SOURCENAME = 'imei')";
                            existWhere = true;
                        }
                    }

                    if (smsCheckBox.Checked)
                    {
                        if (!existWhere)
                        {
                            where += "(S_SOURCENAME = 'sms')";
                            existWhere = true;
                        }
                        else
                        {
                            where += " or (S_SOURCENAME = 'sms')";
                            existWhere = true;
                        }
                    }
                    where += ")";
                }
            }
            return where;
        }
        private void DeleteForm_Load(object sender, EventArgs e)
        {
            //infoLabel.Text = "Выберите какие данные будете удалять с сервера " + server + " из схемы " + schema + " пост " + post;
            postLabel.Text = post;
            schemaLabel.Text = schema;
            serverLabel.Text = server;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if ((smsCheckBox.Checked) | (IMEICheckBox.Checked) | (billingCheckBox.Checked))
            {
                string question = "Вы действительно хотите удалить с сервера " + server + " из схемы " + schema + " пост " + post + ": \n";
                if (billingCheckBox.Checked) question += "- billings \n";
                if (IMEICheckBox.Checked) question += "- imei \n";
                if (smsCheckBox.Checked) question += "- sms \n";
                if (MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deleteButton.Enabled = false;
                    makeDeleteScriptButton.Enabled = false;
                    Application.DoEvents();
                    OracleConnection connection = new OracleConnection(@"Data Source=" + server + "; User ID=sysdba; password=kantatalocal;");
                    try
                    {
                        connection.Open();
                        OracleTransaction transaction;
                        transaction = connection.BeginTransaction();
                        try
                        {
                            string cmd = "delete from " + schema + ".spr_speech_table where " + GetWhere();
                            OracleCommand command = new OracleCommand(cmd, connection);
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            MessageBox.Show("Удаление успешно произведено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                    deleteButton.Enabled = true;
                    makeDeleteScriptButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Выберите какой блок данных удалять", "Информация", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void makeDeleteScriptButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((smsCheckBox.Checked) | (IMEICheckBox.Checked) | (billingCheckBox.Checked))
                {
                    deleteButton.Enabled = false;
                    makeDeleteScriptButton.Enabled = false;
                    StreamWriter file = new StreamWriter(saveFileDialog.FileName, false);
                    try
                    {
                        file.WriteLine("delete from " + schema + ".spr_speech_table where ");
                        file.WriteLine(GetWhere());
                        file.WriteLine();
                        MessageBox.Show("Скрипт успешно сгенерирован", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        file.Close();
                        deleteButton.Enabled = true;
                        makeDeleteScriptButton.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите какой блок данных удалять", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
