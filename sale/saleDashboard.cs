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

namespace dt_learning.sale
{
    public partial class saleDashboard : MetroFramework.Forms.MetroForm
    {
        public string employssID;
        public saleDashboard(string token)
        {
            InitializeComponent();
            employssID = token;
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

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tabControl2.TabPages["sale_tab"])
            {
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["retrunProduct_tab"])
            {
                getProducts();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["report_tab"])
            {
                getRetrun();
                getOrder();
                getProductsQty();
                getProductsExp();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["history_sale"])
            {
                getHistory();
            }
        }

        private void getHistory()
        {
            OpenConnection();
            DataTable d2 = new DataTable();
            DataSet ds = new DataSet();
            string str = "SELECT `id`, `total_price`, `date`, non_send_money FROM `bills` WHERE emp_id = '" + employssID+"'";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            this.adapter.Fill(d2);
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

            int sum = 0;
            for (int i = 0; i < bill_table.Rows.Count; ++i)
            {
                if (bill_table.Rows[i].Cells[3].Value.ToString() == "1")
                {
                    bill_table.Rows[i].Cells[3].Value = "ส่งเงินแล้ว";
                }
                else
                {
                    bill_table.Rows[i].Cells[3].Value = "ยังไม่ส่งเงิน";
                }
                sum += Convert.ToInt32(bill_table.Rows[i].Cells[1].Value);
            }
            total_price.Visible = true;
            total_price.Text = sum.ToString();
        }

        private void getProducts()
        {
            DataSet ds = new DataSet();
            string str = "SELECT products.id, supplier.name, categories.name, products.name, products.qty, products.price, products.exp_date FROM products JOIN supplier ON products.supplier_id = supplier.id JOIN categories ON products.category_id = categories.id ORDER BY products.id ASC";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            table_products_sale.DataSource = ds.Tables[0];
            table_products_sale.Columns[0].HeaderText = "รหัส";
            table_products_sale.Columns[0].Width = 35;

            table_products_sale.Columns[1].HeaderText = "ชื่อร้าน";
            table_products_sale.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            table_products_sale.Columns[2].HeaderText = "หมวดหมู่";
            table_products_sale.Columns[2].Width = 100;

            table_products_sale.Columns[3].HeaderText = "ชื่อสินค้า";
            table_products_sale.Columns[3].Width = 100;

            table_products_sale.Columns[4].HeaderText = "จำนวน";
            table_products_sale.Columns[4].Width = 80;

            table_products_sale.Columns[5].HeaderText = "ราคา";

            table_products_sale.Columns[6].HeaderText = "วันหมดอายุ";
        }

        private void saleDashboard_Load(object sender, EventArgs e)
        {
            getProductsForSale();
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

        private void table_products_sale_MouseClick(object sender, MouseEventArgs e)
        {
            if (table_products_sale.Rows.Count > 0)
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
        }

        private void addtotable_Click(object sender, EventArgs e)
        {
            if (qty.Value == 0 || qty.Text == "")
            {
                MessageBox.Show("กรุณาใส่จำนวนที่ต้องการ");
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
        private void sumTotal()
        {
            decimal sum = 0;
            for (int i = 0; i < cart.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(cart.Rows[i].Cells[4].Value);
            }
            total.Text = sum.ToString();
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

        private void save_order_Click(object sender, EventArgs e)
        {
            if (total.Text != "0" || total.Text != "")
            {
                DateTime today = DateTime.Now;
                string insertBill = "INSERT INTO `bills`(`emp_id`, `date`, `total_price`, `non_send_money`) " +
                    "VALUES ('" + employssID + "','" + today.ToString("yyyy-MM-dd H:m:s") + "','" + total.Text.ToString() + "','0')";
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
                getProducts();
            }
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
            if (qtyRetrun.Text != "0" || qtyRetrun.Text != "")
            {
                if (searth_table.Rows.Count > 0)
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

                    string updatePrice = "UPDATE `bills` SET `total_price`= total_price - '" + price + "' WHERE id = '" + bill_id + "'";
                    executeMyQuery(updatePrice, null);

                    string updateQTY = "UPDATE `products` SET `qty`= qty + '" + qtyRetrun.Text.ToString() + "' WHERE id = '" + product_id + "'";
                    executeMyQuery(updateQTY, null);

                    string updateQTYorder = "UPDATE `orders` SET `qty`= qty - '" + qtyRetrun.Text.ToString() + "' WHERE id = '" + order_id + "'";
                    executeMyQuery(updateQTYorder, null);

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
            }
        }

        private void getRetrun()
        {
            OpenConnection();
            DataTable ds = new DataTable();
            string str = "SELECT products.name,COUNT(*) FROM return_product JOIN products ON return_product.product_id = products.id GROUP BY product_id ORDER BY COUNT(*) DESC";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            retrun_table.DataSource = ds;
            CloseConnection();

            retrun_table.Columns[0].HeaderText = "ชื่อสินค้า";
            retrun_table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            retrun_table.Columns[1].HeaderText = "จำนวนครั้งการคืน";
            retrun_table.Columns[1].Width = 120;
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
            string str = "SELECT name, exp_date FROM products ORDER BY exp_date DESC";
            this.adapter = new MySqlDataAdapter(str, connection);
            this.adapter.Fill(ds);
            productsExp_table.DataSource = ds;
            CloseConnection();

            productsExp_table.Columns[0].HeaderText = "ชื่อสินค้า";
            productsExp_table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            productsExp_table.Columns[1].HeaderText = "วันหมดอายุ";
            productsExp_table.Columns[1].Width = 120;
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bill_table.Rows)
            {
                string xxx = "UPDATE `bills` SET `non_send_money`= '1' WHERE id = '"+row.Cells[0].Value+"'";
                executeMyQuery(xxx, null);
            }
            getHistory();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand("SELECT non_send_money FROM `bills` WHERE emp_id = '" + employssID+"' AND non_send_money = '0'", connection);
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
    }
}
