namespace dt_learning
{
    partial class Welcome
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
            this.id = new MetroFramework.Controls.MetroTextBox();
            this.pwd = new MetroFramework.Controls.MetroTextBox();
            this.login = new MetroFramework.Controls.MetroButton();
            this.cancel = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // id
            // 
            // 
            // 
            // 
            this.id.CustomButton.Image = null;
            this.id.CustomButton.Location = new System.Drawing.Point(298, 1);
            this.id.CustomButton.Name = "";
            this.id.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.id.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.id.CustomButton.TabIndex = 1;
            this.id.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.id.CustomButton.UseSelectable = true;
            this.id.CustomButton.Visible = false;
            this.id.Lines = new string[0];
            this.id.Location = new System.Drawing.Point(35, 201);
            this.id.MaxLength = 32767;
            this.id.Name = "id";
            this.id.PasswordChar = '\0';
            this.id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.id.SelectedText = "";
            this.id.SelectionLength = 0;
            this.id.SelectionStart = 0;
            this.id.ShortcutsEnabled = true;
            this.id.Size = new System.Drawing.Size(320, 23);
            this.id.TabIndex = 0;
            this.id.UseSelectable = true;
            this.id.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.id.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pwd
            // 
            // 
            // 
            // 
            this.pwd.CustomButton.Image = null;
            this.pwd.CustomButton.Location = new System.Drawing.Point(298, 1);
            this.pwd.CustomButton.Name = "";
            this.pwd.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.pwd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pwd.CustomButton.TabIndex = 1;
            this.pwd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pwd.CustomButton.UseSelectable = true;
            this.pwd.CustomButton.Visible = false;
            this.pwd.Lines = new string[0];
            this.pwd.Location = new System.Drawing.Point(35, 263);
            this.pwd.MaxLength = 32767;
            this.pwd.Name = "pwd";
            this.pwd.PasswordChar = '\0';
            this.pwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pwd.SelectedText = "";
            this.pwd.SelectionLength = 0;
            this.pwd.SelectionStart = 0;
            this.pwd.ShortcutsEnabled = true;
            this.pwd.Size = new System.Drawing.Size(320, 23);
            this.pwd.TabIndex = 2;
            this.pwd.UseSelectable = true;
            this.pwd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pwd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(35, 312);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(143, 23);
            this.login.TabIndex = 3;
            this.login.Text = "เข้าสู่ระบบ";
            this.login.UseSelectable = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(212, 312);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(143, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "ออกจากโปรแกรม";
            this.cancel.UseSelectable = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(35, 179);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(64, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "ชื่อผู้ใช้งาน";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(35, 241);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(53, 19);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "รหัสผ่าน";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::dt_learning.Properties.Resources.user_50px;
            this.pictureBox2.Location = new System.Drawing.Point(212, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(147, 83);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::dt_learning.Properties.Resources.team_work_monochromatic;
            this.pictureBox1.Location = new System.Drawing.Point(35, 382);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 583);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.login);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.id);
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Welcome to Decision tree learning";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox id;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox pwd;
        private MetroFramework.Controls.MetroButton login;
        private MetroFramework.Controls.MetroButton cancel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

