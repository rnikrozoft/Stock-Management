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

namespace dt_learning.managerArea
{
    public partial class mnDashboard : MetroFramework.Forms.MetroForm
    {
        public string employeeID;

        public mnDashboard(string token)
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
            this.adapter = new MySqlDataAdapter("SELECT employees.id, employees.fname, employees.lname, employees.tel, employees.password, positions.name FROM employees JOIN positions ON employees.position_id = positions.id WHERE employees.position_id != '1' AND employees.id != '" + employeeID + "'", connection);
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
        private void mnDashboard_Load(object sender, EventArgs e)
        {
            getProducts();
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
            else if (tabControl2.SelectedTab == tabControl2.TabPages["sale_tab"])
            {
                getProductsForSale();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["retrunProduct_tab"])
            {
                getRetrun();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["report_tab"])
            {
                getRetrun();
                getRetrunChart();

                getOrder();

                getProductsQty();
                getProductsChart();

                getProductsExp();
                getProductsExpChart();

            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["history"])
            {
                getHistory();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["send_money"])
            {
                getSend_money();
            }
        }

        private void getRetrunChart()
        {
            retrun_product_chart.Series["chart_return"].Points.Clear();

            OpenConnection();
            command = new MySqlCommand("SELECT products.name as 'name', COUNT(*) as 'qty' FROM return_product JOIN products ON return_product.product_id = products.id GROUP BY product_id ORDER BY COUNT(*) DESC LIMIT 10", connection);
            this.reader = command.ExecuteReader();
            int i = 0;
            while (this.reader.Read())
            {
                retrun_product_chart.Series["chart_return"].Points.Add(reader.GetInt64("qty"));
                retrun_product_chart.Series["chart_return"].Points[i].Label = reader.GetInt64("qty") + " ครั้ง";
                retrun_product_chart.Series["chart_return"].Points[i].AxisLabel = reader.GetString("name");
                i++;
            }
            this.reader.Close();
            CloseConnection();
        }

        private void getProductsForSale()
        {

            DataSet ds = new DataSet();
            string str = "SELECT products.id, products.name, categories.name, supplier.name, products.qty, products.price, products.exp_date FROM products JOIN supplier ON products.supplier_id = supplier.id JOIN categories ON products.category_id = categories.id";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            table_products_sale.DataSource = ds.Tables[0];

            table_products_sale.Columns[0].HeaderText = "รหัส";
            table_products_sale.Columns[0].Width = 35;

            table_products_sale.Columns[1].HeaderText = "ชื่อสินค้า";
            table_products_sale.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            table_products_sale.Columns[2].HeaderText = "หมวดหมู่";
            table_products_sale.Columns[2].Width = 100;

            table_products_sale.Columns[3].HeaderText = "ชื่อร้าน";
            table_products_sale.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            table_products_sale.Columns[4].HeaderText = "จำนวน";
            table_products_sale.Columns[4].Width = 80;

            table_products_sale.Columns[5].HeaderText = "ราคา";

            table_products_sale.Columns[6].HeaderText = "วันหมดอายุ";
        }

        private void getSend_money()
        {
            OpenConnection();
            DataSet ds = new DataSet();
            string str = "SELECT `emp_id`, `date`, `total_price`, `non_send_money` FROM `bills` WHERE non_send_money = '0' ";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            CloseConnection();
            send_money_table.DataSource = ds.Tables[0];

            send_money_table.Columns[0].HeaderText = "รหัสพนักงาน";
            send_money_table.Columns[0].Width = 60;

            send_money_table.Columns[1].HeaderText = "วันที่ออกบิล";
            send_money_table.Columns[1].Width = 60;

            send_money_table.Columns[2].HeaderText = "ราคารวมทั้งหมด";
            send_money_table.Columns[2].Width = 100;

            send_money_table.Columns[3].HeaderText = "สถานะ";
            send_money_table.Columns[3].Width = 100;

            int sum = 0;
            for (int i = 0; i < send_money_table.Rows.Count; ++i)
            {
                if (send_money_table.Rows[i].Cells[3].Value.ToString() == "0")
                {
                    send_money_table.Rows[i].Cells[3].Value = "ยังไม่ส่งเงิน";
                }
                sum += Convert.ToInt32(send_money_table.Rows[i].Cells[2].Value);
            }
            total_text.Visible = true;
            total_text.Text = sum.ToString();

            OpenConnection();
            DataSet ds2 = new DataSet();
            string str2 = "SELECT `emp_id`, `date`, `total_price`, `non_send_money` FROM `bills` WHERE non_send_money = '1' ";
            this.adapter = new MySqlDataAdapter(str2, connection);
            this.adapter.Fill(ds2);
            CloseConnection();
            send_money_table_non.DataSource = ds2.Tables[0];

            send_money_table_non.Columns[0].HeaderText = "รหัสพนักงาน";
            send_money_table_non.Columns[0].Width = 60;

            send_money_table_non.Columns[1].HeaderText = "วันที่ออกบิล";
            send_money_table_non.Columns[1].Width = 60;

            send_money_table_non.Columns[2].HeaderText = "ราคารวมทั้งหมด";
            send_money_table_non.Columns[2].Width = 100;

            send_money_table_non.Columns[3].HeaderText = "สถานะ";
            send_money_table_non.Columns[3].Width = 100;

            int sum2 = 0;
            for (int i2 = 0; i2 < send_money_table_non.Rows.Count; ++i2)
            {
                if (send_money_table_non.Rows[i2].Cells[3].Value.ToString() == "1")
                {
                    send_money_table_non.Rows[i2].Cells[3].Value = "ส่งเงินแล้ว";
                }
                sum2 += Convert.ToInt32(send_money_table_non.Rows[i2].Cells[2].Value);
            }
            total_text_non.Visible = true;
            total_text_non.Text = sum2.ToString();
        }

        private void getData()
        {
            OpenConnection();
            command = new MySqlCommand("SELECT * FROM `employees` WHERE id = '" + employeeID + "'", connection);
            this.reader = command.ExecuteReader();
            while (this.reader.Read())
            {
                string fname = this.reader.GetString("fname");
            }
            this.reader.Close();

            CloseConnection();
        }


        //=============== employee ===============
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


                if (table_employees.CurrentRow.Cells[5].Value.ToString() == "ผู้จัดการ")
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

        private void btn_save_employee_Click(object sender, EventArgs e)
        {
            string position_id;
            if (mn.Checked)
            {
                position_id = "2";
            }
            else if (sm.Checked)
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
            if (mn.Checked)
            {
                position_id = "2";
            }
            else if (sm.Checked)
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

        //=============== products ===============
        public string ConvertToAD(DateTime dDate)
        {
            string strDate = "";
            if (!string.IsNullOrEmpty(dDate.ToString()))
            {
                strDate = dDate.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
            }
            return strDate;
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

        private void btn_delete_employee_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM `employees` WHERE id = '" + input_id_employee.Text.ToString() + "'";
            executeMyQuery(str, null);
            getEmployees();
            input_id_employee.ReadOnly = false;
        }

        private void btn_delete_products_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM `products` WHERE id = '" + int.Parse(input_id_products.Text) + "'";
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

        //=============== category ===============
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

        private void btn_delete_categories_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM `categories` WHERE id = '" + int.Parse(input_id_categoies.Text) + "'";
            executeMyQuery(str, null);
            getCategories();
        }

        private void btn_edit_categories_Click(object sender, EventArgs e)
        {
            string str = "UPDATE `categories` " +
                "SET `name`='" + input_name_categoies.Text + "' WHERE id = '" + int.Parse(input_id_categoies.Text) + "'";
            executeMyQuery(str, "แก้ไขสำเร็จ");
            getCategories();
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

        //=============== supplier ===============
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

        private void logout_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand("SELECT non_send_money FROM `bills` WHERE emp_id = '" + employeeID + "' AND non_send_money = '0'", connection);
            OpenConnection();

            if (command.ExecuteScalar() != null)
            {
                MessageBox.Show("คุณยังไม่ได้กดส่งเงิน กรุณากดส่งเงินก่อน");
            }
            else
            {
                Welcome welcome = new Welcome();
                welcome.Show();
                this.Hide();
            }
            CloseConnection();
        }

        private void table_products_sale_MouseClick(object sender, MouseEventArgs e)
        {
            addtotable.Text = "เพิ่มลงบิล";
            addtotable.Enabled = true;
            qty.Enabled = true;
            qty.ReadOnly = false;

            labelID.Text = table_products_sale.CurrentRow.Cells[0].Value.ToString();
            labelName.Text = table_products_sale.CurrentRow.Cells[3].Value.ToString();
            labelPrice.Text = table_products_sale.CurrentRow.Cells[5].Value.ToString();
            qtyStock.Text = table_products_sale.CurrentRow.Cells[4].Value.ToString();

            qty.Maximum = Int32.Parse(table_products_sale.CurrentRow.Cells[4].Value.ToString());
            qty.Value = Int32.Parse(table_products_sale.CurrentRow.Cells[4].Value.ToString());
        }

        private void addtotable_Click(object sender, EventArgs e)
        {
            if (qty.Value == 0 || qty.Text == "" && vat.Value == 0 || vat.Text == "")
            {
                MessageBox.Show("กรุณาใส่จำนวนที่ต้องการและค่า VAT");
            }
            else
            {
                bool Found = false;
                decimal val = qty.Value * Int64.Parse(labelPrice.Text.ToString());
                decimal vat7 = vat.Value;
                decimal total = val + ((val / 100) * vat7);
                String[] data =
                {
                    labelID.Text.ToString(),
                    labelName.Text.ToString(),
                    labelPrice.Text.ToString(),
                    qty.Text.ToString(),
                    total.ToString()
                };

                if (addtotable.Text.ToString() == "เพิ่มลงบิล")
                {
                    if (cart.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in cart.Rows)
                        {
                            if (Convert.ToString(row.Cells[0].Value) == labelID.Text)
                            {
                                int qtyInput = (int)Convert.ToInt64(qty.Value + Convert.ToInt16(row.Cells[3].Value));
                                int defaultQTY = (int)Int64.Parse(qtyStock.Text.ToString());
                                if (qtyInput > defaultQTY)
                                {
                                    MessageBox.Show("จำนวนในสต็อกไม่พอ");
                                }
                                else
                                {
                                    row.Cells[3].Value = Convert.ToString(qty.Value + Convert.ToInt16(row.Cells[3].Value));
                                    row.Cells[4].Value = Convert.ToString(Convert.ToInt64(row.Cells[2].Value) * Convert.ToInt64(row.Cells[3].Value));
                                }
                                Found = true;
                            }
                        }
                        if (!Found)
                        {
                            cart.Rows.Add(data);
                        }
                    }
                    else
                    {
                        cart.Rows.Add(data);
                    }
                    sumTotal();
                }
                else
                {
                    foreach (DataGridViewRow row in cart.Rows)
                    {
                        if (Convert.ToString(row.Cells[0].Value) == labelID.Text)
                        {
                            if (Convert.ToString(row.Cells[3].Value) != qty.Value.ToString())
                            {
                                row.Cells[3].Value = Convert.ToString(Convert.ToInt16(row.Cells[3].Value) - qty.Value);
                                row.Cells[4].Value = Convert.ToString(Convert.ToInt64(row.Cells[2].Value) * Convert.ToInt64(row.Cells[3].Value));
                                qty.Value = Convert.ToInt64(row.Cells[3].Value);
                            }
                            else
                            {
                                cart.Rows.Remove(cart.CurrentRow);
                                qty.Value = 0;
                                addtotable.Text = "เพิ่มลงบิล";
                            }
                        }
                    }
                    if (cart.Rows.Count == 0)
                    {
                        qty.Value = 0;
                        addtotable.Enabled = false;
                        qty.Enabled = false;
                        qty.ReadOnly = true;

                        labelID.Text = "เลือกรายการที่คุณต้องการ";
                        labelName.Text = "เลือกรายการที่คุณต้องการ";
                        labelPrice.Text = "เลือกรายการที่คุณต้องการ";
                        qtyStock.Text = "เลือกรายการที่คุณต้องการ";
                    }
                    sumTotal();
                }
            }
        }

        private void cart_MouseClick(object sender, MouseEventArgs e)
        {
            if (cart.Rows.Count > 0)
            {
                addtotable.Text = "ลบ";
                labelID.Text = cart.CurrentRow.Cells[0].Value.ToString();
                labelName.Text = cart.CurrentRow.Cells[1].Value.ToString();
                labelPrice.Text = cart.CurrentRow.Cells[2].Value.ToString();

                qty.Maximum = Int32.Parse(cart.CurrentRow.Cells[3].Value.ToString());
                qty.Value = Int32.Parse(cart.CurrentRow.Cells[3].Value.ToString());
            }
        }

        private void sumTotal()
        {
            decimal sum = 0;
            for (int i = 0; i < cart.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(cart.Rows[i].Cells[4].Value);
            }
            total.Text = sum.ToString();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            cart.Rows.Clear();
            cart.Refresh();
            qty.Value = 0;
            total.Text = "0";

            addtotable.Enabled = false;
            qty.Enabled = false;
            qty.ReadOnly = true;

            labelID.Text = "เลือกรายการที่คุณต้องการ";
            labelName.Text = "เลือกรายการที่คุณต้องการ";
            labelPrice.Text = "เลือกรายการที่คุณต้องการ";
            qtyStock.Text = "เลือกรายการที่คุณต้องการ";
        }

        private void save_order_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            string insertBill = "INSERT INTO `bills`(`emp_id`, `date`, `total_price`, `non_send_money`) " +
                "VALUES ('" + employeeID + "','" + today.ToString("yyyy-MM-dd H:m:s") + "','" + total.Text.ToString() + "','0')";
            executeMyQuery(insertBill, null);

            command = new MySqlCommand("SELECT id FROM bills ORDER BY id DESC LIMIT 1", connection);
            int lastID;
            OpenConnection();
            if (command.ExecuteScalar() != null)
            {
                string return_value = command.ExecuteScalar().ToString();
                lastID = int.Parse(return_value);
            }
            else
            {
                lastID = 1;
            }

            CloseConnection();

            foreach (DataGridViewRow row in cart.Rows)
            {
                string xxx = "INSERT INTO `orders`(`bill_id`, `product_id`, `price`, `qty`, `total_price`) VALUES ('" + lastID + "'," +
                    "'" + row.Cells[0].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + row.Cells[4].Value + "')";
                executeMyQuery(xxx, null);

                string updateQTY = "UPDATE `products` SET `qty`= qty - '" + qty.Value.ToString() + "' WHERE id = '" + row.Cells[0].Value + "'";
                executeMyQuery(updateQTY, null);
            }


            cart.Rows.Clear();
            cart.Refresh();
            qty.Value = 0;
            total.Text = "0";

            addtotable.Enabled = false;
            qty.Enabled = false;
            qty.ReadOnly = true;

            labelID.Text = "เลือกรายการที่คุณต้องการ";
            labelName.Text = "เลือกรายการที่คุณต้องการ";
            labelPrice.Text = "เลือกรายการที่คุณต้องการ";
            qtyStock.Text = "เลือกรายการที่คุณต้องการ";
            getProductsForSale();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            OpenConnection();
            DataTable ds = new DataTable();
            string strxx = "SELECT `bill_id`, orders.id, `product_id`, products.name, orders.price, orders.qty " +
                "FROM orders JOIN products ON orders.product_id = products.id " +
                "WHERE orders.bill_id = '" + search.Text + "' AND orders.qty != '0' ";
            this.adapter = new MySqlDataAdapter(strxx, connection);
            this.adapter.Fill(ds);
            searth_table.DataSource = ds;
            CloseConnection();

            searth_table.Columns[0].HeaderText = "บิล";
            searth_table.Columns[0].Width = 35;

            searth_table.Columns[1].HeaderText = "ออร์เดอร์";
            searth_table.Columns[1].Width = 90;

            searth_table.Columns[2].HeaderText = "รหัสสินค้า";
            searth_table.Columns[2].Width = 100;

            searth_table.Columns[3].HeaderText = "ชื่อสินค้า";
            searth_table.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            searth_table.Columns[4].HeaderText = "ราคา";
            searth_table.Columns[4].Width = 100;

            searth_table.Columns[5].HeaderText = "จำนวน";
            searth_table.Columns[5].Width = 100;
        }


        private void searth_table_MouseClick(object sender, MouseEventArgs e)
        {
            if (searth_table.Rows.Count != 0)
            {
                qtyRetrun.Text = searth_table.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void btn_retrun_Click(object sender, EventArgs e)
        {
            string bill_id = searth_table.CurrentRow.Cells[0].Value.ToString();
            string order_id = searth_table.CurrentRow.Cells[1].Value.ToString();
            string product_id = searth_table.CurrentRow.Cells[2].Value.ToString();
            string qty = qtyRetrun.Text.ToString();
            int price = (int)(Convert.ToInt64(qty) * Convert.ToInt64(searth_table.CurrentRow.Cells[4].Value));
            DateTime today = DateTime.Now;

            string str = "INSERT INTO `return_product`(`bill_id`, `order_id`, `product_id`, `date`, `qty`, `price`) " +
                "VALUES ('" + bill_id + "', '" + order_id + "', '" + product_id + "','" + today.ToString("yyyy-MM-dd H:m:s") + "', '" + qty + "', '" + price + "')";
            executeMyQuery(str, null);

            string updateQTY = "UPDATE `products` SET `qty`= qty + '" + qtyRetrun.Text.ToString() + "' WHERE id = '" + product_id + "'";
            executeMyQuery(updateQTY, null);

            string updateQTYorder = "UPDATE `orders` SET `qty`= qty - '" + qtyRetrun.Text.ToString() + "' WHERE id = '" + order_id + "'";
            executeMyQuery(updateQTYorder, null);

            OpenConnection();
            DataTable ds = new DataTable();
            string strxx = "SELECT `bill_id`, orders.id, `product_id`, products.name, orders.price, orders.qty " +
                "FROM orders JOIN products ON orders.product_id = products.id " +
                "WHERE orders.bill_id = '"+search.Text+"' AND orders.qty != '0' ";
            this.adapter = new MySqlDataAdapter(strxx, connection);
            this.adapter.Fill(ds);
            searth_table.DataSource = ds;
            CloseConnection();

            searth_table.Columns[0].HeaderText = "บิล";
            searth_table.Columns[0].Width = 35;

            searth_table.Columns[1].HeaderText = "ออร์เดอร์";
            searth_table.Columns[1].Width = 90;

            searth_table.Columns[2].HeaderText = "รหัสสินค้า";
            searth_table.Columns[2].Width = 100;

            searth_table.Columns[3].HeaderText = "ชื่อสินค้า";
            searth_table.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            searth_table.Columns[4].HeaderText = "ราคา";
            searth_table.Columns[4].Width = 100;

            searth_table.Columns[5].HeaderText = "จำนวน";
            searth_table.Columns[5].Width = 100;

        }

        private void getRetrun()
        {
            OpenConnection();
            DataTable ds = new DataTable();
            string str = "SELECT products.name, COUNT(*), return_product.date FROM return_product JOIN products ON return_product.product_id = products.id GROUP BY product_id ORDER BY COUNT(*) DESC";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            retrun_table.DataSource = ds;
            CloseConnection();

            retrun_table.Columns[0].HeaderText = "ชื่อสินค้า";
            retrun_table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            retrun_table.Columns[1].HeaderText = "จำนวนครั้งการคืน";
            retrun_table.Columns[1].Width = 120;

            retrun_table.Columns[2].HeaderText = "คืนวันที่";
            retrun_table.Columns[2].Width = 120;
        }

        private void getOrder()
        {
            OpenConnection();
            DataTable ds = new DataTable();
            string str = "SELECT products.name,COUNT(*) FROM orders JOIN products ON orders.product_id = products.id GROUP BY product_id ORDER BY COUNT(*) DESC";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            order_table.DataSource = ds;
            CloseConnection();

            order_table.Columns[0].HeaderText = "ชื่อสินค้า";
            order_table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            order_table.Columns[1].HeaderText = "จำนวนครั้งการขาย";
            order_table.Columns[1].Width = 120;
        }

        private void getProductsQty()
        {
            OpenConnection();
            DataTable ds = new DataTable();
            string str = "SELECT name, qty FROM products ORDER BY qty ASC";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            productQty_table.DataSource = ds;
            CloseConnection();

            productQty_table.Columns[0].HeaderText = "ชื่อสินค้า";
            productQty_table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            productQty_table.Columns[1].HeaderText = "จำนวนที่เหลือ";
            productQty_table.Columns[1].Width = 120;
        }

        private void getProductsExp()
        {
            OpenConnection();
            DataTable ds = new DataTable();
            string str = "SELECT name, exp_date FROM products ORDER BY exp_date ASC";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            productsExp_table.DataSource = ds;
            CloseConnection();

            productsExp_table.Columns[0].HeaderText = "ชื่อสินค้า";
            productsExp_table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            productsExp_table.Columns[1].HeaderText = "วันหมดอายุ";
            productsExp_table.Columns[1].Width = 120;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bill_table.Rows)
            {
                string xxx = "UPDATE `bills` SET `non_send_money`= '1' WHERE id = '" + row.Cells[0].Value + "'";
                executeMyQuery(xxx, null);
            }
            getHistory();
        }

        private void bill_table_MouseClick(object sender, MouseEventArgs e)
        {
            if (bill_table.Rows.Count > 0)
            {
                string bill_id = bill_table.CurrentRow.Cells[0].Value.ToString();
                OpenConnection();
                DataTable ds = new DataTable();
                string str = "SELECT products.name, orders.price, orders.qty, orders.total_price FROM `orders` JOIN products ON orders.product_id = products.id WHERE orders.bill_id = '" + bill_id + "' ";
                this.adapter = new MySqlDataAdapter(str, connection);
                this.adapter.Fill(ds);
                orders_table.DataSource = ds;
                CloseConnection();

                orders_table.Columns[0].HeaderText = "ชื่อสินค้า";
                orders_table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                orders_table.Columns[1].HeaderText = "ราคา / ยูนิต";
                orders_table.Columns[1].Width = 120;

                orders_table.Columns[2].HeaderText = "จำนวนที่ขายออกไป";
                orders_table.Columns[2].Width = 120;

                orders_table.Columns[3].HeaderText = "ราคารวม";
                orders_table.Columns[3].Width = 120;
            }
        }

        private void getHistory()
        {
            
            OpenConnection();
            DataSet ds = new DataSet();
            string str = "SELECT `id`, `total_price`, `date`, non_send_money FROM `bills` WHERE emp_id = '" + employeeID + "'";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            CloseConnection();

            bill_table.DataSource = ds.Tables[0];

            bill_table.Columns[0].HeaderText = "หมายเลขบิล";
            bill_table.Columns[0].Width = 60;

            bill_table.Columns[1].HeaderText = "ราคา";
            bill_table.Columns[1].Width = 60;

            bill_table.Columns[2].HeaderText = "วันที่ออกบิล";
            bill_table.Columns[2].Width = 100;

            bill_table.Columns[3].HeaderText = "ส่งเงิน";
            bill_table.Columns[3].Width = 100;

            long sum = 0;
            for (int i = 0; i < bill_table.Rows.Count; i++)
            {
                if (bill_table.Rows[i].Cells[3].Value.ToString() == "1")
                {
                    bill_table.Rows[i].Cells[3].Value = "ส่งเงินแล้ว";
                }
                else
                {
                    bill_table.Rows[i].Cells[3].Value = "ยังไม่ส่งเงิน";
                }
                sum += Convert.ToInt64(bill_table.Rows[i].Cells[1].Value);
            }
            total_price.Visible = true;
            total_price.Text = sum.ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabControl1.TabPages["return_report"])
            {
                getRetrunChart();
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["order_report"])
            {
                getOrderChart();
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["qty_report"])
            {
                getProductsChart();
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["final_tab"])
            {
                getFinalReport();
            }
            else
            {
                getProductsExpChart();
            }
        }

        private void getFinalReport()
        {
            chart1.Series["finalChart"].Points.Clear();

            OpenConnection();
            command = new MySqlCommand("SELECT products.name, COUNT(orders.id) as 'orderQty', COUNT(return_product.id) as 'returnQry', COUNT(orders.id) - COUNT(return_product.id) AS 'result' FROM orders LEFT OUTER JOIN return_product ON return_product.order_id = orders.id JOIN products ON orders.product_id = products.id GROUP BY products.id ORDER BY result ASC", connection);
            this.reader = command.ExecuteReader();
            int i = 0;
            while (this.reader.Read())
            {
                chart1.Series["finalChart"].Points.Add(reader.GetInt64("result"));
                chart1.Series["finalChart"].Points[i].Label = "จำนวนที่ขายได้ " + reader.GetString("result");
                chart1.Series["finalChart"].Points[i].AxisLabel = reader.GetString("name");
                i++;
            }
            this.reader.Close();

            CloseConnection();
        }

        private void getProductsExpChart()
        {
            //exp_date_chart.Series["exp_date_chart"].Points.Clear();
            //OpenConnection();
            //command = new MySqlCommand("SELECT name, exp_date FROM products ORDER BY exp_date ASC", connection);
            //this.reader = command.ExecuteReader();
            //int i = 0;
            //while (this.reader.Read())
            //{
            //    MessageBox.Show(Convert.ToDecimal(reader.GetString("exp_date")).ToString());
            //    //decimal date = Convert.ToDecimal(reader.GetString("exp_date"));
            //    //exp_date_chart.Series["exp_date_chart"].Points.Add(reader.GetInt64(date.ToString()));
            //    //exp_date_chart.Series["exp_date_chart"].Points[i].Label = reader.GetString("exp_date");
            //    //exp_date_chart.Series["exp_date_chart"].Points[i].AxisLabel = reader.GetString("name");
            //    i++;
            //}
            //this.reader.Close();
            //CloseConnection();
        }

        private void getProductsChart()
        {
            productsExp_Chart.Series["productsExp_Chart"].Points.Clear();

            OpenConnection();
            command = new MySqlCommand("SELECT products.name, products.qty FROM products ORDER BY qty ASC", connection);
            this.reader = command.ExecuteReader();
            int i = 0;
            while (this.reader.Read())
            {
                productsExp_Chart.Series["productsExp_Chart"].Points.Add(reader.GetInt64("qty"));
                productsExp_Chart.Series["productsExp_Chart"].Points[i].Label = reader.GetInt64("qty") + " ยูนิต";
                productsExp_Chart.Series["productsExp_Chart"].Points[i].AxisLabel = reader.GetString("name");
                i++;
            }
            this.reader.Close();
            CloseConnection();
        }

        private void getOrderChart()
        {
            order_chart.Series["order_chart"].Points.Clear();

            OpenConnection();
            command = new MySqlCommand("SELECT products.name,COUNT(*) as qty FROM orders JOIN products ON orders.product_id = products.id GROUP BY product_id ORDER BY COUNT(*) DESC", connection);
            this.reader = command.ExecuteReader();
            int i = 0;
            while (this.reader.Read())
            {
                order_chart.Series["order_chart"].Points.Add(reader.GetInt64("qty"));
                order_chart.Series["order_chart"].Points[i].Label = reader.GetInt64("qty") + " ครั้ง";
                order_chart.Series["order_chart"].Points[i].AxisLabel = reader.GetString("name");
                i++;
            }
            this.reader.Close();
            CloseConnection();
        }
    }
}
