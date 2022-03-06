using MySql.Data.MySqlClient;
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

namespace dt_learning.officer
{
    public partial class ofDashboard : MetroFramework.Forms.MetroForm
    {
        public string employeeID;
        public ofDashboard(string token)
        {
            InitializeComponent();
            employeeID = token;
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='dt_learning';" +
            "username=root;password=;");
        MySqlCommand command;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader reader;

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

        public void getEmployees()
        {
            btn_edit_employee.Enabled = false;
            btn_save_employee.Enabled = true;

            DataSet ds = new DataSet();
            this.adapter = new MySqlDataAdapter("SELECT employees.id, employees.fname, employees.lname, employees.tel, employees.password, positions.name FROM employees JOIN positions ON employees.position_id = positions.id WHERE employees.position_id != '1' AND employees.position_id != '2' AND employees.id != '"+employeeID+"'", connection);
            this.adapter.Fill(ds);
            table_employees.DataSource = ds.Tables[0];
            OpenConnection();


            input_id_employee.Text = "";
            input_name_employee.Text = "";
            input_lname_employee.Text = "";
            input_tel_employee.Text = "";
            input_pwd_employee.Text = "";
            CloseConnection();

            table_employees.Columns[0].HeaderText = "ชื่อผู้ใช้";
            table_employees.Columns[1].HeaderText = "ชื่อ";
            table_employees.Columns[2].HeaderText = "นามสกุล";
            table_employees.Columns[3].HeaderText = "เบอร์โทร";
            table_employees.Columns[4].HeaderText = "รฟัสผ่าน";
            table_employees.Columns[5].HeaderText = "ตำแหน่ง";
        }

        public void getSupplier()
        {
            btn_edit_supplier.Enabled = false;
            btn_save_supplier.Enabled = true;

            DataSet ds = new DataSet();
            this.adapter = new MySqlDataAdapter("SELECT * FROM supplier", connection);
            this.adapter.Fill(ds);
            table_supplier.DataSource = ds.Tables[0];

            command = new MySqlCommand("SELECT id FROM supplier ORDER BY id DESC LIMIT 1", connection);
            int lastID;
            OpenConnection();

            if (command.ExecuteScalar() != null)
            {
                string return_value = command.ExecuteScalar().ToString();
                lastID = int.Parse(return_value);
                lastID++;
            }
            else
            {
                lastID = 1;
            }

            input_id_supplier.Text = lastID.ToString();
            input_name_supplier.Text = "";
            input_tel_supplier.Text = "";
            input_address_supplier.Text = "";
            CloseConnection();

            table_supplier.Columns[0].HeaderText = "รหัส";
            table_supplier.Columns[0].Width = 35;
            table_supplier.Columns[1].HeaderText = "ชื่อร้าน";
            table_supplier.Columns[1].Width = 165;
            table_supplier.Columns[2].HeaderText = "เบอร์โทร";
            table_supplier.Columns[2].Width = 80;
            table_supplier.Columns[3].HeaderText = "ที่อยู่";
            table_supplier.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void getCategories()
        {
            btn_edit_categories.Enabled = false;
            btn_save_cateories.Enabled = true;

            DataSet ds = new DataSet();
            this.adapter = new MySqlDataAdapter("SELECT * FROM categories", connection);
            this.adapter.Fill(ds);
            table_categories.DataSource = ds.Tables[0];

            command = new MySqlCommand("SELECT id FROM categories ORDER BY id DESC LIMIT 1", connection);
            int lastID;
            OpenConnection();

            if (command.ExecuteScalar() != null)
            {
                string return_value = command.ExecuteScalar().ToString();
                lastID = int.Parse(return_value);
                lastID++;
            }
            else
            {
                lastID = 1;
            }

            input_id_categoies.Text = lastID.ToString();
            input_name_categoies.Text = "";
            CloseConnection();
            table_categories.Columns[0].HeaderText = "รหัสหมวหมู่";
            table_categories.Columns[1].HeaderText = "ชื่อหมวดหมู่";
        }

        public void getProducts()
        {
            btn_edit_products.Enabled = false;
            btn_save_products.Enabled = true;

            DataSet ds = new DataSet();
            string str = "SELECT products.id, supplier.name, categories.name, products.name, products.qty, products.price, products.exp_date FROM products JOIN supplier ON products.supplier_id = supplier.id JOIN categories ON products.category_id = categories.id";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            table_products.DataSource = ds.Tables[0];

            command = new MySqlCommand("SELECT id FROM products ORDER BY id DESC LIMIT 1", connection);
            int lastID;
            OpenConnection();

            if (command.ExecuteScalar() != null)
            {
                string return_value = command.ExecuteScalar().ToString();
                lastID = int.Parse(return_value);
                lastID++;
            }
            else
            {
                lastID = 1;
            }

            input_id_products.Text = lastID.ToString();

            command = new MySqlCommand("SELECT * FROM supplier", connection);
            this.reader = command.ExecuteReader();
            input_supplier_products.Items.Clear();
            while (this.reader.Read())
            {
                string sName = this.reader.GetString("name");
                input_supplier_products.Items.Add(sName);
            }
            this.reader.Close();
            if (input_supplier_products.SelectedIndex != -1)
            {
                input_supplier_products.SelectedIndex = 0;
            }

            command = new MySqlCommand("SELECT * FROM categories", connection);
            this.reader = command.ExecuteReader();
            input_category_products.Items.Clear();
            while (this.reader.Read())
            {
                string sName = this.reader.GetString("name");
                input_category_products.Items.Add(sName);
            }
            this.reader.Close();
            if (input_category_products.SelectedIndex != -1)
            {
                input_category_products.SelectedIndex = 0;
            }


            input_name_products.Text = "";
            input_qty_products.Text = "";
            input_price_products.Text = "";
            input_exp_products.Value = DateTime.Now;

            CloseConnection();

            table_products.Columns[0].HeaderText = "รหัส";
            table_products.Columns[0].Width = 35;

            table_products.Columns[1].HeaderText = "ชื่อร้าน";
            table_products.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            table_products.Columns[2].HeaderText = "หมวดหมู่";
            table_products.Columns[2].Width = 130;

            table_products.Columns[3].HeaderText = "ชื่อสินค้า";
            table_products.Columns[3].Width = 200;

            table_products.Columns[4].HeaderText = "จำนวน";
            table_products.Columns[4].Width = 80;

            table_products.Columns[5].HeaderText = "ราคา";

            table_products.Columns[6].HeaderText = "วันหมดอายุ";
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tabControl2.TabPages["home_tab"])
            {
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["products_tab"])
            {
                getProducts();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["category_tab"])
            {
                getCategories();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["supplier_tab"])
            {
                getSupplier();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["employees_tab"])
            {
                getEmployees();
            }
        }
        public string ConvertToAD(DateTime dDate)
        {
            string strDate = "";
            if (!string.IsNullOrEmpty(dDate.ToString()))
            {
                strDate = dDate.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
            }
            return strDate;
        }

        private void ofDashboard_Load(object sender, EventArgs e)
        {
            getProducts();
        }

        private void btn_save_products_Click(object sender, EventArgs e)
        {
            DateTime exp = input_exp_products.Value;

            OpenConnection();
            MySqlCommand supplier_id_cmd = new MySqlCommand("SELECT id FROM supplier WHERE name = '" + input_supplier_products.Text.Trim() + "' ", connection);
            string supplier_id = supplier_id_cmd.ExecuteScalar().ToString();

            MySqlCommand category_id_cmd = new MySqlCommand("SELECT id FROM categories WHERE name = '" + input_category_products.Text.Trim() + "' ", connection);
            string category_id = category_id_cmd.ExecuteScalar().ToString();
            CloseConnection();

            string str = "INSERT INTO `products`(`id`, `supplier_id`, `category_id`, `name`, `qty`, `price`, `exp_date`)" +
                "VALUES ('" + input_id_products.Text + "','" + supplier_id + "','" + category_id + "','" + input_name_products.Text + "','" + input_qty_products.Text + "','" + input_price_products.Text + "','" + ConvertToAD(exp) + "')";
            executeMyQuery(str, null);
            getProducts();
        }

        private void btn_edit_products_Click(object sender, EventArgs e)
        {
            DateTime exp = input_exp_products.Value;

            OpenConnection();
            MySqlCommand supplier_id_cmd = new MySqlCommand("SELECT id FROM supplier WHERE name = '" + input_supplier_products.Text.Trim() + "' ", connection);
            string supplier_id = supplier_id_cmd.ExecuteScalar().ToString();

            MySqlCommand category_id_cmd = new MySqlCommand("SELECT id FROM categories WHERE name = '" + input_category_products.Text.Trim() + "' ", connection);
            string category_id = category_id_cmd.ExecuteScalar().ToString();
            CloseConnection();

            string str = "UPDATE `products` SET `supplier_id`='" + supplier_id + "',`category_id`='" + category_id + "',`name`='" + input_name_products.Text + "',`qty`='" + input_qty_products.Text + "',`price`='" + input_price_products.Text + "',`exp_date`='" + ConvertToAD(exp) + "' WHERE id = '" + int.Parse(input_id_products.Text) + "'";
            executeMyQuery(str, null);
            getProducts();
        }

        private void btn_delete_products_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM `products` WHERE id = '" + int.Parse(input_id_products.Text) + "'";
            executeMyQuery(str, null);
            getProducts();
        }

        private void table_products_MouseClick(object sender, MouseEventArgs e)
        {
            if (table_products.Rows.Count != 0)
            {
                btn_edit_products.Enabled = true;
                btn_save_products.Enabled = false;

                input_id_products.Text = table_products.CurrentRow.Cells[0].Value.ToString();
                input_supplier_products.Text = table_products.CurrentRow.Cells[1].Value.ToString();
                input_category_products.Text = table_products.CurrentRow.Cells[2].Value.ToString();
                input_name_products.Text = table_products.CurrentRow.Cells[3].Value.ToString();
                input_qty_products.Text = table_products.CurrentRow.Cells[4].Value.ToString();
                input_price_products.Text = table_products.CurrentRow.Cells[5].Value.ToString();
                input_exp_products.Text = table_products.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void btn_save_cateories_Click(object sender, EventArgs e)
        {
            if (input_name_categoies.Text != "")
            {
                string str = "INSERT INTO categories(id,name)" +
                    "VALUES('" + input_id_categoies.Text + "','" + input_name_categoies.Text + "')";
                executeMyQuery(str, null);
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
            }
            getCategories();
        }

        private void btn_edit_categories_Click(object sender, EventArgs e)
        {
            string str = "UPDATE `categories` " +
                "SET `name`='" + input_name_categoies.Text + "' WHERE id = '" + int.Parse(input_id_categoies.Text) + "'";
            executeMyQuery(str, "แก้ไขสำเร็จ");
            getCategories();
        }

        private void btn_delete_categories_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM `categories` WHERE id = '" + int.Parse(input_id_categoies.Text) + "'";
            executeMyQuery(str, null);
            getCategories();
        }

        private void table_categories_MouseClick(object sender, MouseEventArgs e)
        {
            if (table_categories.Rows.Count != 0)
            {
                btn_edit_categories.Enabled = true;
                btn_save_cateories.Enabled = false;

                input_id_categoies.Text = table_categories.CurrentRow.Cells[0].Value.ToString();
                input_name_categoies.Text = table_categories.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btn_save_supplier_Click(object sender, EventArgs e)
        {
            if (input_name_supplier.Text != "" || input_tel_supplier.Text != "" || input_address_supplier.Text != "")
            {
                string str = "INSERT INTO supplier(id,name, tel, address)" +
                    "VALUES('" + input_id_supplier.Text + "','" + input_name_supplier.Text + "','"
                    + input_tel_supplier.Text + "','" + input_address_supplier.Text + "')";
                executeMyQuery(str, null);
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
            }
            getSupplier();
        }

        private void btn_edit_supplier_Click(object sender, EventArgs e)
        {
            string str = "UPDATE `supplier` " +
                "SET `name`='" + input_name_supplier.Text + "',`tel`='" + input_tel_supplier.Text + "',`address`='" + input_address_supplier.Text + "'" +
                "WHERE id = '" + int.Parse(input_id_supplier.Text) + "'";
            executeMyQuery(str, "แก้ไขสำเร็จ");
            getSupplier();
        }

        private void btn_delete_supplier_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM `supplier` WHERE id = '" + int.Parse(input_id_supplier.Text) + "'";
            executeMyQuery(str, null);
            getSupplier();
        }

        private void table_supplier_MouseClick(object sender, MouseEventArgs e)
        {
            if (table_supplier.Rows.Count != 0)
            {
                btn_edit_supplier.Enabled = true;
                btn_save_supplier.Enabled = false;

                input_id_supplier.Text = table_supplier.CurrentRow.Cells[0].Value.ToString();
                input_name_supplier.Text = table_supplier.CurrentRow.Cells[1].Value.ToString();
                input_tel_supplier.Text = table_supplier.CurrentRow.Cells[2].Value.ToString();
                input_address_supplier.Text = table_supplier.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btn_save_employee_Click(object sender, EventArgs e)
        {
            string position_id;
            if (sm.Checked)
            {
                position_id = "3";
            }

            else if (of.Checked)
            {
                position_id = "5";
            }
            else
            {
                position_id = "4";
            }
            string str = "INSERT INTO `employees`(`id`, `fname`, `lname`, `tel`, `password`, `position_id`) " +
                "VALUES ('" + input_id_employee.Text.Trim() + "','" + input_name_employee.Text.Trim() + "','" + input_lname_employee.Text.Trim() + "','" + input_tel_employee.Text.Trim() + "','" + input_pwd_employee.Text.Trim() + "','" + position_id + "')";
            executeMyQuery(str, null);
            getEmployees();
        }

        private void btn_edit_employee_Click(object sender, EventArgs e)
        {
            string position_id;
            if (sm.Checked)
            {
                position_id = "3";
            }

            else if (of.Checked)
            {
                position_id = "5";
            }
            else
            {
                position_id = "4";
            }

            string str = "UPDATE `employees` SET " +
                "`fname`='" + input_name_employee.Text.ToString() + "'," +
                "`lname`='" + input_lname_employee.Text.ToString() + "'," +
                "`tel`='" + input_tel_employee.Text.ToString() + "'," +
                "`password`='" + input_pwd_employee.Text.ToString() + "'," +
                "`position_id`='" + position_id + "' " +
                "WHERE id = '" + input_id_employee.Text.ToString() + "'";
            executeMyQuery(str, null);
            getEmployees();
            input_id_employee.ReadOnly = false;
        }

        private void btn_delete_employee_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM `employees` WHERE id = '" + input_id_employee.Text.ToString() + "'";
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

                if (table_employees.CurrentRow.Cells[5].Value.ToString() == "พนักงานขาย")
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

        private void logout_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }
    }
}
