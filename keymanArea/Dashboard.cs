using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;


namespace dt_learning.keymanArea
{
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='dt_learning';" +
            "username=root;password=;");
        MySqlCommand command;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader reader;
        public string employeeID;

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
        public Dashboard(string token)
        {
            InitializeComponent();
            employeeID = token;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            getEmployees();
        }
        public void getEmployees()
        {
            btn_edit_employee.Enabled = false;
            btn_save_employee.Enabled = true;

            DataSet ds = new DataSet();
            this.adapter = new MySqlDataAdapter("SELECT employees.id, employees.fname, employees.lname, employees.tel, employees.password, positions.name FROM employees JOIN positions ON employees.position_id = positions.id WHERE employees.id != '"+ employeeID + "'", connection);
            this.adapter.Fill(ds);
            table_employees.DataSource = ds.Tables[0];
            OpenConnection();


            input_id_employee.Text = "";
            input_name_employee.Text = "";
            input_lname_employee.Text = "";
            input_tel_employee.Text = "";
            input_pwd_employee.Text = "";
            km.Checked = true;
            CloseConnection();

            table_employees.Columns[0].HeaderText = "ชื่อผู้ใช้";
            table_employees.Columns[1].HeaderText = "ชื่อ";
            table_employees.Columns[2].HeaderText = "นามสกุล";
            table_employees.Columns[3].HeaderText = "เบอร์โทร";
            table_employees.Columns[4].HeaderText = "รฟัสผ่าน";
            table_employees.Columns[5].HeaderText = "ตำแหน่ง";
        }

        private void btn_save_employee_Click(object sender, EventArgs e)
        {
            int position;
            if (km.Checked)
            {
                position = 1;
            }
            else if (mn.Checked)
            {
                position = 2;
            }
            else if(sm.Checked)
            {
                position = 3;
            }
            else if (of.Checked)
            {
                position = 5;
            }
            else
            {
                position = 4;
            }
            string str = "INSERT INTO `employees`(`id`, `fname`, `lname`, `tel`, `password`, `position_id`) " +
                "VALUES ('"+ input_id_employee.Text.Trim()+ "','" + input_name_employee.Text.Trim() + "','" + input_lname_employee.Text.Trim() + "','" + input_tel_employee.Text.Trim() + "','" + input_pwd_employee.Text.Trim() + "','" + position+"')";
            executeMyQuery(str, null);
            getEmployees();
        }

        private void table_employees_MouseClick(object sender, MouseEventArgs e)
        {
            if (table_employees.Rows.Count != 0)
            {
                btn_edit_employee.Enabled = true;
                btn_save_employee.Enabled = false;

                input_id_employee.Text = table_employees.CurrentRow.Cells[0].Value.ToString();
                input_id_employee.ReadOnly = true;

                input_name_employee.Text = table_employees.CurrentRow.Cells[1].Value.ToString();
                input_lname_employee.Text = table_employees.CurrentRow.Cells[2].Value.ToString();
                input_tel_employee.Text = table_employees.CurrentRow.Cells[3].Value.ToString();
                input_pwd_employee.Text = table_employees.CurrentRow.Cells[4].Value.ToString();

                if (table_employees.CurrentRow.Cells[5].Value.ToString() == "คีย์แมน")
                {
                    km.Checked = true;
                }
                else if (table_employees.CurrentRow.Cells[5].Value.ToString() == "ผู้จัดการ")
                {
                    mn.Checked = true;
                }
                else if (table_employees.CurrentRow.Cells[5].Value.ToString() == "พนักงานขาย")
                {
                    sm.Checked = true;
                }
                else if (table_employees.CurrentRow.Cells[5].Value.ToString() == "เจ้าหน้าที่ข้อมูล")
                {
                    of.Checked = true;
                }
                else
                {
                    disable_position.Checked = true;
                }
            }
        }

        private void btn_edit_employee_Click(object sender, EventArgs e)
        {
            int position;
            if (km.Checked)
            {
                position = 1;
            }
            else if (mn.Checked)
            {
                position = 2;
            }
            else if (sm.Checked)
            {
                position = 3;
            }
            else if (of.Checked)
            {
                position = 5;
            }
            else
            {
                position = 4;
            }

            string str = "UPDATE `employees` SET " +
                "`fname`='" + input_name_employee.Text.ToString() + "'," +
                "`lname`='" + input_lname_employee.Text.ToString() + "'," +
                "`tel`='" + input_tel_employee.Text.ToString() + "'," +
                "`password`='" + input_pwd_employee.Text.ToString() + "'," +
                "`position_id`='" + position + "' " +
                "WHERE id = '"+input_id_employee.Text.ToString()+"'";
            executeMyQuery(str, null);
            getEmployees();
            input_id_employee.ReadOnly = false ;
        }

        private void btn_delete_employee_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM `employees` WHERE id = '" + input_id_employee.Text.ToString() + "'";
            executeMyQuery(str, null);
            getEmployees();
            input_id_employee.ReadOnly = false;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }
    }
}
