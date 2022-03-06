namespace dt_learning.officer
{
    partial class ofDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.products_tab = new System.Windows.Forms.TabPage();
            this.input_exp_products = new System.Windows.Forms.DateTimePicker();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.input_price_products = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.input_qty_products = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.input_name_products = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.input_category_products = new System.Windows.Forms.ComboBox();
            this.input_supplier_products = new System.Windows.Forms.ComboBox();
            this.table_products = new System.Windows.Forms.DataGridView();
            this.btn_edit_products = new MetroFramework.Controls.MetroButton();
            this.input_id_products = new System.Windows.Forms.TextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btn_delete_products = new MetroFramework.Controls.MetroButton();
            this.btn_save_products = new MetroFramework.Controls.MetroButton();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.category_tab = new System.Windows.Forms.TabPage();
            this.table_categories = new System.Windows.Forms.DataGridView();
            this.btn_edit_categories = new MetroFramework.Controls.MetroButton();
            this.input_id_categoies = new System.Windows.Forms.TextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.btn_delete_categories = new MetroFramework.Controls.MetroButton();
            this.btn_save_cateories = new MetroFramework.Controls.MetroButton();
            this.input_name_categoies = new System.Windows.Forms.TextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.supplier_tab = new System.Windows.Forms.TabPage();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.table_supplier = new System.Windows.Forms.DataGridView();
            this.btn_edit_supplier = new MetroFramework.Controls.MetroButton();
            this.input_id_supplier = new System.Windows.Forms.TextBox();
            this.btn_delete_supplier = new MetroFramework.Controls.MetroButton();
            this.btn_save_supplier = new MetroFramework.Controls.MetroButton();
            this.input_address_supplier = new System.Windows.Forms.TextBox();
            this.input_tel_supplier = new System.Windows.Forms.TextBox();
            this.input_name_supplier = new System.Windows.Forms.TextBox();
            this.employees_tab = new System.Windows.Forms.TabPage();
            this.of = new System.Windows.Forms.RadioButton();
            this.disable_position = new System.Windows.Forms.RadioButton();
            this.sm = new System.Windows.Forms.RadioButton();
            this.mn = new System.Windows.Forms.RadioButton();
            this.km = new System.Windows.Forms.RadioButton();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel25 = new MetroFramework.Controls.MetroLabel();
            this.input_pwd_employee = new System.Windows.Forms.TextBox();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.input_tel_employee = new System.Windows.Forms.TextBox();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.table_employees = new System.Windows.Forms.DataGridView();
            this.btn_edit_employee = new MetroFramework.Controls.MetroButton();
            this.input_id_employee = new System.Windows.Forms.TextBox();
            this.btn_delete_employee = new MetroFramework.Controls.MetroButton();
            this.btn_save_employee = new MetroFramework.Controls.MetroButton();
            this.input_lname_employee = new System.Windows.Forms.TextBox();
            this.input_name_employee = new System.Windows.Forms.TextBox();
            this.logout = new MetroFramework.Controls.MetroButton();
            this.tabControl2.SuspendLayout();
            this.products_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_products)).BeginInit();
            this.category_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_categories)).BeginInit();
            this.supplier_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_supplier)).BeginInit();
            this.employees_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_employees)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.products_tab);
            this.tabControl2.Controls.Add(this.category_tab);
            this.tabControl2.Controls.Add(this.supplier_tab);
            this.tabControl2.Controls.Add(this.employees_tab);
            this.tabControl2.Location = new System.Drawing.Point(23, 63);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1224, 498);
            this.tabControl2.TabIndex = 3;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // products_tab
            // 
            this.products_tab.Controls.Add(this.input_exp_products);
            this.products_tab.Controls.Add(this.metroLabel18);
            this.products_tab.Controls.Add(this.metroLabel17);
            this.products_tab.Controls.Add(this.metroLabel16);
            this.products_tab.Controls.Add(this.input_price_products);
            this.products_tab.Controls.Add(this.metroLabel15);
            this.products_tab.Controls.Add(this.metroLabel14);
            this.products_tab.Controls.Add(this.input_qty_products);
            this.products_tab.Controls.Add(this.metroLabel13);
            this.products_tab.Controls.Add(this.input_name_products);
            this.products_tab.Controls.Add(this.metroLabel12);
            this.products_tab.Controls.Add(this.input_category_products);
            this.products_tab.Controls.Add(this.input_supplier_products);
            this.products_tab.Controls.Add(this.table_products);
            this.products_tab.Controls.Add(this.btn_edit_products);
            this.products_tab.Controls.Add(this.input_id_products);
            this.products_tab.Controls.Add(this.metroLabel6);
            this.products_tab.Controls.Add(this.btn_delete_products);
            this.products_tab.Controls.Add(this.btn_save_products);
            this.products_tab.Controls.Add(this.metroLabel10);
            this.products_tab.Location = new System.Drawing.Point(4, 22);
            this.products_tab.Name = "products_tab";
            this.products_tab.Padding = new System.Windows.Forms.Padding(3);
            this.products_tab.Size = new System.Drawing.Size(1216, 472);
            this.products_tab.TabIndex = 1;
            this.products_tab.Text = "สินค้า";
            this.products_tab.UseVisualStyleBackColor = true;
            // 
            // input_exp_products
            // 
            this.input_exp_products.CustomFormat = "dd/MM/yyy";
            this.input_exp_products.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.input_exp_products.Location = new System.Drawing.Point(90, 195);
            this.input_exp_products.Name = "input_exp_products";
            this.input_exp_products.Size = new System.Drawing.Size(207, 20);
            this.input_exp_products.TabIndex = 102;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.Location = new System.Drawing.Point(17, 195);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(67, 19);
            this.metroLabel18.TabIndex = 100;
            this.metroLabel18.Text = "วันหมดอายุ";
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(35, 165);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(35, 19);
            this.metroLabel17.TabIndex = 98;
            this.metroLabel17.Text = "ราคา";
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(256, 165);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(41, 19);
            this.metroLabel16.TabIndex = 97;
            this.metroLabel16.Text = "/ ยูนิต";
            // 
            // input_price_products
            // 
            // 
            // 
            // 
            this.input_price_products.CustomButton.Image = null;
            this.input_price_products.CustomButton.Location = new System.Drawing.Point(151, 1);
            this.input_price_products.CustomButton.Name = "";
            this.input_price_products.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.input_price_products.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.input_price_products.CustomButton.TabIndex = 1;
            this.input_price_products.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.input_price_products.CustomButton.UseSelectable = true;
            this.input_price_products.CustomButton.Visible = false;
            this.input_price_products.Lines = new string[0];
            this.input_price_products.Location = new System.Drawing.Point(77, 165);
            this.input_price_products.MaxLength = 32767;
            this.input_price_products.Name = "input_price_products";
            this.input_price_products.PasswordChar = '\0';
            this.input_price_products.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.input_price_products.SelectedText = "";
            this.input_price_products.SelectionLength = 0;
            this.input_price_products.SelectionStart = 0;
            this.input_price_products.ShortcutsEnabled = true;
            this.input_price_products.Size = new System.Drawing.Size(173, 23);
            this.input_price_products.TabIndex = 96;
            this.input_price_products.UseSelectable = true;
            this.input_price_products.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.input_price_products.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(265, 136);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(32, 19);
            this.metroLabel15.TabIndex = 95;
            this.metroLabel15.Text = "ยูนิต";
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(27, 136);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(44, 19);
            this.metroLabel14.TabIndex = 94;
            this.metroLabel14.Text = "จำนวน";
            // 
            // input_qty_products
            // 
            // 
            // 
            // 
            this.input_qty_products.CustomButton.Image = null;
            this.input_qty_products.CustomButton.Location = new System.Drawing.Point(160, 1);
            this.input_qty_products.CustomButton.Name = "";
            this.input_qty_products.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.input_qty_products.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.input_qty_products.CustomButton.TabIndex = 1;
            this.input_qty_products.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.input_qty_products.CustomButton.UseSelectable = true;
            this.input_qty_products.CustomButton.Visible = false;
            this.input_qty_products.Lines = new string[0];
            this.input_qty_products.Location = new System.Drawing.Point(77, 136);
            this.input_qty_products.MaxLength = 32767;
            this.input_qty_products.Name = "input_qty_products";
            this.input_qty_products.PasswordChar = '\0';
            this.input_qty_products.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.input_qty_products.SelectedText = "";
            this.input_qty_products.SelectionLength = 0;
            this.input_qty_products.SelectionStart = 0;
            this.input_qty_products.ShortcutsEnabled = true;
            this.input_qty_products.Size = new System.Drawing.Size(182, 23);
            this.input_qty_products.TabIndex = 93;
            this.input_qty_products.UseSelectable = true;
            this.input_qty_products.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.input_qty_products.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(17, 107);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(54, 19);
            this.metroLabel13.TabIndex = 92;
            this.metroLabel13.Text = "ชื่อสินค้า";
            // 
            // input_name_products
            // 
            // 
            // 
            // 
            this.input_name_products.CustomButton.Image = null;
            this.input_name_products.CustomButton.Location = new System.Drawing.Point(198, 1);
            this.input_name_products.CustomButton.Name = "";
            this.input_name_products.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.input_name_products.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.input_name_products.CustomButton.TabIndex = 1;
            this.input_name_products.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.input_name_products.CustomButton.UseSelectable = true;
            this.input_name_products.CustomButton.Visible = false;
            this.input_name_products.Lines = new string[0];
            this.input_name_products.Location = new System.Drawing.Point(77, 107);
            this.input_name_products.MaxLength = 32767;
            this.input_name_products.Name = "input_name_products";
            this.input_name_products.PasswordChar = '\0';
            this.input_name_products.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.input_name_products.SelectedText = "";
            this.input_name_products.SelectionLength = 0;
            this.input_name_products.SelectionStart = 0;
            this.input_name_products.ShortcutsEnabled = true;
            this.input_name_products.Size = new System.Drawing.Size(220, 23);
            this.input_name_products.TabIndex = 91;
            this.input_name_products.UseSelectable = true;
            this.input_name_products.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.input_name_products.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(16, 79);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(55, 19);
            this.metroLabel12.TabIndex = 90;
            this.metroLabel12.Text = "หมวดหมู่";
            // 
            // input_category_products
            // 
            this.input_category_products.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_category_products.FormattingEnabled = true;
            this.input_category_products.Items.AddRange(new object[] {
            "เลือกรายการ"});
            this.input_category_products.Location = new System.Drawing.Point(77, 79);
            this.input_category_products.Name = "input_category_products";
            this.input_category_products.Size = new System.Drawing.Size(220, 21);
            this.input_category_products.TabIndex = 89;
            // 
            // input_supplier_products
            // 
            this.input_supplier_products.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_supplier_products.FormattingEnabled = true;
            this.input_supplier_products.Items.AddRange(new object[] {
            "เลือกรายการ"});
            this.input_supplier_products.Location = new System.Drawing.Point(77, 52);
            this.input_supplier_products.Name = "input_supplier_products";
            this.input_supplier_products.Size = new System.Drawing.Size(220, 21);
            this.input_supplier_products.TabIndex = 88;
            // 
            // table_products
            // 
            this.table_products.AllowUserToAddRows = false;
            this.table_products.AllowUserToDeleteRows = false;
            this.table_products.AllowUserToResizeColumns = false;
            this.table_products.AllowUserToResizeRows = false;
            this.table_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_products.Location = new System.Drawing.Point(322, 26);
            this.table_products.Name = "table_products";
            this.table_products.ReadOnly = true;
            this.table_products.RowHeadersVisible = false;
            this.table_products.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_products.Size = new System.Drawing.Size(870, 400);
            this.table_products.TabIndex = 85;
            this.table_products.MouseClick += new System.Windows.Forms.MouseEventHandler(this.table_products_MouseClick);
            // 
            // btn_edit_products
            // 
            this.btn_edit_products.Location = new System.Drawing.Point(153, 231);
            this.btn_edit_products.Name = "btn_edit_products";
            this.btn_edit_products.Size = new System.Drawing.Size(74, 23);
            this.btn_edit_products.TabIndex = 84;
            this.btn_edit_products.Text = "แก้ไขข้อมูล";
            this.btn_edit_products.UseSelectable = true;
            this.btn_edit_products.Click += new System.EventHandler(this.btn_edit_products_Click);
            // 
            // input_id_products
            // 
            this.input_id_products.Location = new System.Drawing.Point(77, 26);
            this.input_id_products.Name = "input_id_products";
            this.input_id_products.ReadOnly = true;
            this.input_id_products.Size = new System.Drawing.Size(220, 20);
            this.input_id_products.TabIndex = 83;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(40, 26);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(31, 19);
            this.metroLabel6.TabIndex = 82;
            this.metroLabel6.Text = "รหัส";
            // 
            // btn_delete_products
            // 
            this.btn_delete_products.Location = new System.Drawing.Point(233, 232);
            this.btn_delete_products.Name = "btn_delete_products";
            this.btn_delete_products.Size = new System.Drawing.Size(64, 23);
            this.btn_delete_products.TabIndex = 76;
            this.btn_delete_products.Text = "ลบข้อมูล";
            this.btn_delete_products.UseSelectable = true;
            this.btn_delete_products.Click += new System.EventHandler(this.btn_delete_products_Click);
            // 
            // btn_save_products
            // 
            this.btn_save_products.Location = new System.Drawing.Point(77, 232);
            this.btn_save_products.Name = "btn_save_products";
            this.btn_save_products.Size = new System.Drawing.Size(70, 23);
            this.btn_save_products.TabIndex = 75;
            this.btn_save_products.Text = "บันทึกข้อมูล";
            this.btn_save_products.UseSelectable = true;
            this.btn_save_products.Click += new System.EventHandler(this.btn_save_products_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(42, 52);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(29, 19);
            this.metroLabel10.TabIndex = 72;
            this.metroLabel10.Text = "ร้าน";
            // 
            // category_tab
            // 
            this.category_tab.Controls.Add(this.table_categories);
            this.category_tab.Controls.Add(this.btn_edit_categories);
            this.category_tab.Controls.Add(this.input_id_categoies);
            this.category_tab.Controls.Add(this.metroLabel8);
            this.category_tab.Controls.Add(this.btn_delete_categories);
            this.category_tab.Controls.Add(this.btn_save_cateories);
            this.category_tab.Controls.Add(this.input_name_categoies);
            this.category_tab.Controls.Add(this.metroLabel11);
            this.category_tab.Location = new System.Drawing.Point(4, 22);
            this.category_tab.Name = "category_tab";
            this.category_tab.Padding = new System.Windows.Forms.Padding(3);
            this.category_tab.Size = new System.Drawing.Size(1216, 472);
            this.category_tab.TabIndex = 2;
            this.category_tab.Text = "หมวดหมู่สินค้า";
            this.category_tab.UseVisualStyleBackColor = true;
            // 
            // table_categories
            // 
            this.table_categories.AllowUserToAddRows = false;
            this.table_categories.AllowUserToDeleteRows = false;
            this.table_categories.AllowUserToResizeColumns = false;
            this.table_categories.AllowUserToResizeRows = false;
            this.table_categories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_categories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_categories.Location = new System.Drawing.Point(322, 26);
            this.table_categories.Name = "table_categories";
            this.table_categories.ReadOnly = true;
            this.table_categories.RowHeadersVisible = false;
            this.table_categories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_categories.Size = new System.Drawing.Size(870, 400);
            this.table_categories.TabIndex = 65;
            this.table_categories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.table_categories_MouseClick);
            // 
            // btn_edit_categories
            // 
            this.btn_edit_categories.Location = new System.Drawing.Point(153, 80);
            this.btn_edit_categories.Name = "btn_edit_categories";
            this.btn_edit_categories.Size = new System.Drawing.Size(74, 23);
            this.btn_edit_categories.TabIndex = 64;
            this.btn_edit_categories.Text = "แก้ไขข้อมูล";
            this.btn_edit_categories.UseSelectable = true;
            this.btn_edit_categories.Click += new System.EventHandler(this.btn_edit_categories_Click);
            // 
            // input_id_categoies
            // 
            this.input_id_categoies.Location = new System.Drawing.Point(77, 26);
            this.input_id_categoies.Name = "input_id_categoies";
            this.input_id_categoies.ReadOnly = true;
            this.input_id_categoies.Size = new System.Drawing.Size(220, 20);
            this.input_id_categoies.TabIndex = 63;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(40, 26);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(31, 19);
            this.metroLabel8.TabIndex = 62;
            this.metroLabel8.Text = "รหัส";
            // 
            // btn_delete_categories
            // 
            this.btn_delete_categories.Location = new System.Drawing.Point(233, 81);
            this.btn_delete_categories.Name = "btn_delete_categories";
            this.btn_delete_categories.Size = new System.Drawing.Size(64, 23);
            this.btn_delete_categories.TabIndex = 56;
            this.btn_delete_categories.Text = "ลบข้อมูล";
            this.btn_delete_categories.UseSelectable = true;
            this.btn_delete_categories.Click += new System.EventHandler(this.btn_delete_categories_Click);
            // 
            // btn_save_cateories
            // 
            this.btn_save_cateories.Location = new System.Drawing.Point(77, 81);
            this.btn_save_cateories.Name = "btn_save_cateories";
            this.btn_save_cateories.Size = new System.Drawing.Size(70, 23);
            this.btn_save_cateories.TabIndex = 55;
            this.btn_save_cateories.Text = "บันทึกข้อมูล";
            this.btn_save_cateories.UseSelectable = true;
            this.btn_save_cateories.Click += new System.EventHandler(this.btn_save_cateories_Click);
            // 
            // input_name_categoies
            // 
            this.input_name_categoies.Location = new System.Drawing.Point(77, 52);
            this.input_name_categoies.Name = "input_name_categoies";
            this.input_name_categoies.Size = new System.Drawing.Size(220, 20);
            this.input_name_categoies.TabIndex = 53;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(47, 52);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(24, 19);
            this.metroLabel11.TabIndex = 52;
            this.metroLabel11.Text = "ชื่อ";
            // 
            // supplier_tab
            // 
            this.supplier_tab.Controls.Add(this.metroLabel4);
            this.supplier_tab.Controls.Add(this.metroLabel3);
            this.supplier_tab.Controls.Add(this.metroLabel2);
            this.supplier_tab.Controls.Add(this.metroLabel1);
            this.supplier_tab.Controls.Add(this.table_supplier);
            this.supplier_tab.Controls.Add(this.btn_edit_supplier);
            this.supplier_tab.Controls.Add(this.input_id_supplier);
            this.supplier_tab.Controls.Add(this.btn_delete_supplier);
            this.supplier_tab.Controls.Add(this.btn_save_supplier);
            this.supplier_tab.Controls.Add(this.input_address_supplier);
            this.supplier_tab.Controls.Add(this.input_tel_supplier);
            this.supplier_tab.Controls.Add(this.input_name_supplier);
            this.supplier_tab.Location = new System.Drawing.Point(4, 22);
            this.supplier_tab.Name = "supplier_tab";
            this.supplier_tab.Padding = new System.Windows.Forms.Padding(3);
            this.supplier_tab.Size = new System.Drawing.Size(1216, 472);
            this.supplier_tab.TabIndex = 3;
            this.supplier_tab.Text = "แหล่งติดต่อสินค้า";
            this.supplier_tab.UseVisualStyleBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(40, 104);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(31, 19);
            this.metroLabel4.TabIndex = 66;
            this.metroLabel4.Text = "ที่อยู่";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(17, 79);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(54, 19);
            this.metroLabel3.TabIndex = 65;
            this.metroLabel3.Text = "เบอร์โทร";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(47, 52);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(24, 19);
            this.metroLabel2.TabIndex = 64;
            this.metroLabel2.Text = "ชื่อ";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(40, 26);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(31, 19);
            this.metroLabel1.TabIndex = 63;
            this.metroLabel1.Text = "รหัส";
            // 
            // table_supplier
            // 
            this.table_supplier.AllowUserToAddRows = false;
            this.table_supplier.AllowUserToDeleteRows = false;
            this.table_supplier.AllowUserToResizeColumns = false;
            this.table_supplier.AllowUserToResizeRows = false;
            this.table_supplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_supplier.Location = new System.Drawing.Point(322, 26);
            this.table_supplier.Name = "table_supplier";
            this.table_supplier.ReadOnly = true;
            this.table_supplier.RowHeadersVisible = false;
            this.table_supplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_supplier.Size = new System.Drawing.Size(870, 400);
            this.table_supplier.TabIndex = 51;
            this.table_supplier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.table_supplier_MouseClick);
            // 
            // btn_edit_supplier
            // 
            this.btn_edit_supplier.Location = new System.Drawing.Point(153, 216);
            this.btn_edit_supplier.Name = "btn_edit_supplier";
            this.btn_edit_supplier.Size = new System.Drawing.Size(74, 23);
            this.btn_edit_supplier.TabIndex = 50;
            this.btn_edit_supplier.Text = "แก้ไขข้อมูล";
            this.btn_edit_supplier.UseSelectable = true;
            this.btn_edit_supplier.Click += new System.EventHandler(this.btn_edit_supplier_Click);
            // 
            // input_id_supplier
            // 
            this.input_id_supplier.Location = new System.Drawing.Point(77, 26);
            this.input_id_supplier.Name = "input_id_supplier";
            this.input_id_supplier.ReadOnly = true;
            this.input_id_supplier.Size = new System.Drawing.Size(220, 20);
            this.input_id_supplier.TabIndex = 49;
            // 
            // btn_delete_supplier
            // 
            this.btn_delete_supplier.Location = new System.Drawing.Point(233, 217);
            this.btn_delete_supplier.Name = "btn_delete_supplier";
            this.btn_delete_supplier.Size = new System.Drawing.Size(64, 23);
            this.btn_delete_supplier.TabIndex = 42;
            this.btn_delete_supplier.Text = "ลบข้อมูล";
            this.btn_delete_supplier.UseSelectable = true;
            this.btn_delete_supplier.Click += new System.EventHandler(this.btn_delete_supplier_Click);
            // 
            // btn_save_supplier
            // 
            this.btn_save_supplier.Location = new System.Drawing.Point(77, 217);
            this.btn_save_supplier.Name = "btn_save_supplier";
            this.btn_save_supplier.Size = new System.Drawing.Size(70, 23);
            this.btn_save_supplier.TabIndex = 41;
            this.btn_save_supplier.Text = "บันทึกข้อมูล";
            this.btn_save_supplier.UseSelectable = true;
            this.btn_save_supplier.Click += new System.EventHandler(this.btn_save_supplier_Click);
            // 
            // input_address_supplier
            // 
            this.input_address_supplier.Location = new System.Drawing.Point(77, 104);
            this.input_address_supplier.Multiline = true;
            this.input_address_supplier.Name = "input_address_supplier";
            this.input_address_supplier.Size = new System.Drawing.Size(220, 107);
            this.input_address_supplier.TabIndex = 40;
            // 
            // input_tel_supplier
            // 
            this.input_tel_supplier.Location = new System.Drawing.Point(77, 78);
            this.input_tel_supplier.Name = "input_tel_supplier";
            this.input_tel_supplier.Size = new System.Drawing.Size(220, 20);
            this.input_tel_supplier.TabIndex = 39;
            // 
            // input_name_supplier
            // 
            this.input_name_supplier.Location = new System.Drawing.Point(77, 52);
            this.input_name_supplier.Name = "input_name_supplier";
            this.input_name_supplier.Size = new System.Drawing.Size(220, 20);
            this.input_name_supplier.TabIndex = 38;
            // 
            // employees_tab
            // 
            this.employees_tab.Controls.Add(this.of);
            this.employees_tab.Controls.Add(this.disable_position);
            this.employees_tab.Controls.Add(this.sm);
            this.employees_tab.Controls.Add(this.mn);
            this.employees_tab.Controls.Add(this.km);
            this.employees_tab.Controls.Add(this.metroLabel20);
            this.employees_tab.Controls.Add(this.metroLabel25);
            this.employees_tab.Controls.Add(this.input_pwd_employee);
            this.employees_tab.Controls.Add(this.metroLabel24);
            this.employees_tab.Controls.Add(this.input_tel_employee);
            this.employees_tab.Controls.Add(this.metroLabel21);
            this.employees_tab.Controls.Add(this.metroLabel22);
            this.employees_tab.Controls.Add(this.metroLabel23);
            this.employees_tab.Controls.Add(this.table_employees);
            this.employees_tab.Controls.Add(this.btn_edit_employee);
            this.employees_tab.Controls.Add(this.input_id_employee);
            this.employees_tab.Controls.Add(this.btn_delete_employee);
            this.employees_tab.Controls.Add(this.btn_save_employee);
            this.employees_tab.Controls.Add(this.input_lname_employee);
            this.employees_tab.Controls.Add(this.input_name_employee);
            this.employees_tab.Location = new System.Drawing.Point(4, 22);
            this.employees_tab.Name = "employees_tab";
            this.employees_tab.Padding = new System.Windows.Forms.Padding(3);
            this.employees_tab.Size = new System.Drawing.Size(1216, 472);
            this.employees_tab.TabIndex = 4;
            this.employees_tab.Text = "พนักงาน";
            this.employees_tab.UseVisualStyleBackColor = true;
            // 
            // of
            // 
            this.of.AutoSize = true;
            this.of.Location = new System.Drawing.Point(77, 183);
            this.of.Name = "of";
            this.of.Size = new System.Drawing.Size(93, 17);
            this.of.TabIndex = 110;
            this.of.Text = "เจ้าหน้าที่ข้อมูล";
            this.of.UseVisualStyleBackColor = true;
            // 
            // disable_position
            // 
            this.disable_position.AutoSize = true;
            this.disable_position.Location = new System.Drawing.Point(176, 183);
            this.disable_position.Name = "disable_position";
            this.disable_position.Size = new System.Drawing.Size(97, 17);
            this.disable_position.TabIndex = 109;
            this.disable_position.Text = "ระงับการใช้งาน";
            this.disable_position.UseVisualStyleBackColor = true;
            // 
            // sm
            // 
            this.sm.AutoSize = true;
            this.sm.Checked = true;
            this.sm.Location = new System.Drawing.Point(213, 160);
            this.sm.Name = "sm";
            this.sm.Size = new System.Drawing.Size(84, 17);
            this.sm.TabIndex = 108;
            this.sm.TabStop = true;
            this.sm.Text = "พนักงานขาย";
            this.sm.UseVisualStyleBackColor = true;
            // 
            // mn
            // 
            this.mn.AutoSize = true;
            this.mn.Enabled = false;
            this.mn.Location = new System.Drawing.Point(145, 160);
            this.mn.Name = "mn";
            this.mn.Size = new System.Drawing.Size(63, 17);
            this.mn.TabIndex = 107;
            this.mn.Text = "ผู้จัดการ";
            this.mn.UseVisualStyleBackColor = true;
            // 
            // km
            // 
            this.km.AutoSize = true;
            this.km.Enabled = false;
            this.km.Location = new System.Drawing.Point(77, 160);
            this.km.Name = "km";
            this.km.Size = new System.Drawing.Size(62, 17);
            this.km.TabIndex = 106;
            this.km.Text = "คีย์แมน";
            this.km.UseVisualStyleBackColor = true;
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.Location = new System.Drawing.Point(21, 158);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(51, 19);
            this.metroLabel20.TabIndex = 105;
            this.metroLabel20.Text = "ตำแหน่ง";
            // 
            // metroLabel25
            // 
            this.metroLabel25.AutoSize = true;
            this.metroLabel25.Location = new System.Drawing.Point(18, 52);
            this.metroLabel25.Name = "metroLabel25";
            this.metroLabel25.Size = new System.Drawing.Size(53, 19);
            this.metroLabel25.TabIndex = 104;
            this.metroLabel25.Text = "รหัสผ่าน";
            // 
            // input_pwd_employee
            // 
            this.input_pwd_employee.Location = new System.Drawing.Point(77, 52);
            this.input_pwd_employee.Name = "input_pwd_employee";
            this.input_pwd_employee.Size = new System.Drawing.Size(220, 20);
            this.input_pwd_employee.TabIndex = 103;
            // 
            // metroLabel24
            // 
            this.metroLabel24.AutoSize = true;
            this.metroLabel24.Location = new System.Drawing.Point(17, 130);
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.Size = new System.Drawing.Size(54, 19);
            this.metroLabel24.TabIndex = 92;
            this.metroLabel24.Text = "เบอร์โทร";
            // 
            // input_tel_employee
            // 
            this.input_tel_employee.Location = new System.Drawing.Point(77, 130);
            this.input_tel_employee.Name = "input_tel_employee";
            this.input_tel_employee.Size = new System.Drawing.Size(220, 20);
            this.input_tel_employee.TabIndex = 90;
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.Location = new System.Drawing.Point(17, 105);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(55, 19);
            this.metroLabel21.TabIndex = 85;
            this.metroLabel21.Text = "นามสกุล";
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.Location = new System.Drawing.Point(47, 78);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(24, 19);
            this.metroLabel22.TabIndex = 84;
            this.metroLabel22.Text = "ชื่อ";
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.Location = new System.Drawing.Point(26, 27);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(45, 19);
            this.metroLabel23.TabIndex = 83;
            this.metroLabel23.Text = "ชื่อผุ้ใช้";
            // 
            // table_employees
            // 
            this.table_employees.AllowUserToAddRows = false;
            this.table_employees.AllowUserToDeleteRows = false;
            this.table_employees.AllowUserToResizeColumns = false;
            this.table_employees.AllowUserToResizeRows = false;
            this.table_employees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_employees.Location = new System.Drawing.Point(322, 26);
            this.table_employees.Name = "table_employees";
            this.table_employees.ReadOnly = true;
            this.table_employees.RowHeadersVisible = false;
            this.table_employees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_employees.Size = new System.Drawing.Size(870, 400);
            this.table_employees.TabIndex = 82;
            this.table_employees.MouseClick += new System.Windows.Forms.MouseEventHandler(this.table_employees_MouseClick);
            // 
            // btn_edit_employee
            // 
            this.btn_edit_employee.Enabled = false;
            this.btn_edit_employee.Location = new System.Drawing.Point(153, 215);
            this.btn_edit_employee.Name = "btn_edit_employee";
            this.btn_edit_employee.Size = new System.Drawing.Size(74, 23);
            this.btn_edit_employee.TabIndex = 81;
            this.btn_edit_employee.Text = "แก้ไขข้อมูล";
            this.btn_edit_employee.UseSelectable = true;
            this.btn_edit_employee.Click += new System.EventHandler(this.btn_edit_employee_Click);
            // 
            // input_id_employee
            // 
            this.input_id_employee.Location = new System.Drawing.Point(77, 26);
            this.input_id_employee.Name = "input_id_employee";
            this.input_id_employee.Size = new System.Drawing.Size(220, 20);
            this.input_id_employee.TabIndex = 80;
            // 
            // btn_delete_employee
            // 
            this.btn_delete_employee.Location = new System.Drawing.Point(233, 215);
            this.btn_delete_employee.Name = "btn_delete_employee";
            this.btn_delete_employee.Size = new System.Drawing.Size(64, 23);
            this.btn_delete_employee.TabIndex = 74;
            this.btn_delete_employee.Text = "ลบข้อมูล";
            this.btn_delete_employee.UseSelectable = true;
            this.btn_delete_employee.Click += new System.EventHandler(this.btn_delete_employee_Click);
            // 
            // btn_save_employee
            // 
            this.btn_save_employee.Location = new System.Drawing.Point(77, 215);
            this.btn_save_employee.Name = "btn_save_employee";
            this.btn_save_employee.Size = new System.Drawing.Size(70, 23);
            this.btn_save_employee.TabIndex = 73;
            this.btn_save_employee.Text = "บันทึกข้อมูล";
            this.btn_save_employee.UseSelectable = true;
            this.btn_save_employee.Click += new System.EventHandler(this.btn_save_employee_Click);
            // 
            // input_lname_employee
            // 
            this.input_lname_employee.Location = new System.Drawing.Point(77, 104);
            this.input_lname_employee.Name = "input_lname_employee";
            this.input_lname_employee.Size = new System.Drawing.Size(220, 20);
            this.input_lname_employee.TabIndex = 71;
            // 
            // input_name_employee
            // 
            this.input_name_employee.Location = new System.Drawing.Point(77, 78);
            this.input_name_employee.Name = "input_name_employee";
            this.input_name_employee.Size = new System.Drawing.Size(220, 20);
            this.input_name_employee.TabIndex = 70;
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(1132, 54);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(107, 23);
            this.logout.TabIndex = 110;
            this.logout.Text = "ออกจากระบบ";
            this.logout.UseSelectable = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // ofDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 575);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.tabControl2);
            this.Name = "ofDashboard";
            this.Text = "Officer Dashboard";
            this.Load += new System.EventHandler(this.ofDashboard_Load);
            this.tabControl2.ResumeLayout(false);
            this.products_tab.ResumeLayout(false);
            this.products_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_products)).EndInit();
            this.category_tab.ResumeLayout(false);
            this.category_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_categories)).EndInit();
            this.supplier_tab.ResumeLayout(false);
            this.supplier_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_supplier)).EndInit();
            this.employees_tab.ResumeLayout(false);
            this.employees_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_employees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage products_tab;
        private System.Windows.Forms.DateTimePicker input_exp_products;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroTextBox input_price_products;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroTextBox input_qty_products;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox input_name_products;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private System.Windows.Forms.ComboBox input_category_products;
        private System.Windows.Forms.ComboBox input_supplier_products;
        private System.Windows.Forms.DataGridView table_products;
        private MetroFramework.Controls.MetroButton btn_edit_products;
        private System.Windows.Forms.TextBox input_id_products;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton btn_delete_products;
        private MetroFramework.Controls.MetroButton btn_save_products;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private System.Windows.Forms.TabPage category_tab;
        private System.Windows.Forms.DataGridView table_categories;
        private MetroFramework.Controls.MetroButton btn_edit_categories;
        private System.Windows.Forms.TextBox input_id_categoies;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroButton btn_delete_categories;
        private MetroFramework.Controls.MetroButton btn_save_cateories;
        private System.Windows.Forms.TextBox input_name_categoies;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private System.Windows.Forms.TabPage supplier_tab;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView table_supplier;
        private MetroFramework.Controls.MetroButton btn_edit_supplier;
        private System.Windows.Forms.TextBox input_id_supplier;
        private MetroFramework.Controls.MetroButton btn_delete_supplier;
        private MetroFramework.Controls.MetroButton btn_save_supplier;
        private System.Windows.Forms.TextBox input_address_supplier;
        private System.Windows.Forms.TextBox input_tel_supplier;
        private System.Windows.Forms.TextBox input_name_supplier;
        private System.Windows.Forms.TabPage employees_tab;
        private System.Windows.Forms.RadioButton disable_position;
        private System.Windows.Forms.RadioButton sm;
        private System.Windows.Forms.RadioButton mn;
        private System.Windows.Forms.RadioButton km;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroLabel metroLabel25;
        private System.Windows.Forms.TextBox input_pwd_employee;
        private MetroFramework.Controls.MetroLabel metroLabel24;
        private System.Windows.Forms.TextBox input_tel_employee;
        private MetroFramework.Controls.MetroLabel metroLabel21;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroLabel metroLabel23;
        private System.Windows.Forms.DataGridView table_employees;
        private MetroFramework.Controls.MetroButton btn_edit_employee;
        private System.Windows.Forms.TextBox input_id_employee;
        private MetroFramework.Controls.MetroButton btn_delete_employee;
        private MetroFramework.Controls.MetroButton btn_save_employee;
        private System.Windows.Forms.TextBox input_lname_employee;
        private System.Windows.Forms.TextBox input_name_employee;
        private MetroFramework.Controls.MetroButton logout;
        private System.Windows.Forms.RadioButton of;
    }
}