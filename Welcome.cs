using dt_learning.keymanArea;
using dt_learning.managerArea;
using dt_learning.officer;
using dt_learning.sale;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dt_learning
{
    public partial class Welcome : MetroFramework.Forms.MetroForm
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='dt_learning';" +
            "username=root;password=;");
        MySqlCommand command;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader reader;
        public string employee_id;


        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้");
                        break;

                    case 1045:
                        MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านฐานข้อมูลไม่ถูกต้อง โปรดลองใหม่อีกครั้ง");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void executeMyQuery(string query, string msg)
        {
            try
            {
                OpenConnection();
                command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    if (msg != null)
                    {
                        MessageBox.Show(msg);
                    }
                }
                else
                {
                    MessageBox.Show("Query Not Exexuted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Welcome()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (id.Text != "" || pwd.Text != "")
            {
                string str = "SELECT * FROM `employees` WHERE id = '"+id.Text+"' AND password = '"+pwd.Text+"'";
                command = new MySqlCommand(str, connection);
                OpenConnection();

                if (command.ExecuteScalar() != null)
                {
                    this.reader = command.ExecuteReader();
                    
                    while (this.reader.Read())
                    {
                        employee_id = this.reader.GetString("id");
                        int position_id = this.reader.GetInt16("position_id");
                        if (position_id == 1)
                        {
                            Dashboard keymanDashboard = new Dashboard(employee_id);
                            keymanDashboard.Show();
                            this.Hide();
                        }else if (position_id == 2 )
                        {
                            mnDashboard managerDashboard = new mnDashboard(employee_id);
                            managerDashboard.Show();
                            this.Hide();
                        }
                        else if (position_id == 3)
                        {
                            saleDashboard saleDashboard = new saleDashboard(employee_id);
                            saleDashboard.Show();
                            this.Hide();
                        }
                        else if (position_id == 5)
                        {
                            ofDashboard ofDashboard = new ofDashboard(employee_id);
                            ofDashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ผู้ใช้นี้ถูกระงับการใช้งาน โปรดติดต่อ Keyman");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลผู้ใช้");
                }
                CloseConnection();
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
            }
        }
    }
}
