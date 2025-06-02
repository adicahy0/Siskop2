namespace project_ecoranger.Views
{
    partial class UcRegister
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tbPassword = new TextBox();
            tbKonfirmasiPw = new TextBox();
            tbUsername = new TextBox();
            tbEmail = new TextBox();
            tbNomorTelepon = new TextBox();
            tbNama = new TextBox();
            btnRegister = new Panel();
            btnToLogin = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(tbKonfirmasiPw);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(tbEmail);
            panel1.Controls.Add(tbNomorTelepon);
            panel1.Controls.Add(tbNama);
            panel1.Location = new Point(279, 271);
            panel1.Name = "panel1";
            panel1.Size = new Size(1321, 403);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(749, 207);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(397, 28);
            tbPassword.TabIndex = 7;
            // 
            // tbKonfirmasiPw
            // 
            tbKonfirmasiPw.BorderStyle = BorderStyle.None;
            tbKonfirmasiPw.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbKonfirmasiPw.Location = new Point(749, 347);
            tbKonfirmasiPw.Name = "tbKonfirmasiPw";
            tbKonfirmasiPw.Size = new Size(397, 28);
            tbKonfirmasiPw.TabIndex = 4;
            // 
            // tbUsername
            // 
            tbUsername.BorderStyle = BorderStyle.None;
            tbUsername.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbUsername.Location = new Point(749, 76);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(397, 28);
            tbUsername.TabIndex = 3;
            // 
            // tbEmail
            // 
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbEmail.Location = new Point(51, 347);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(397, 28);
            tbEmail.TabIndex = 2;
            // 
            // tbNomorTelepon
            // 
            tbNomorTelepon.BorderStyle = BorderStyle.None;
            tbNomorTelepon.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbNomorTelepon.Location = new Point(51, 207);
            tbNomorTelepon.Name = "tbNomorTelepon";
            tbNomorTelepon.Size = new Size(397, 28);
            tbNomorTelepon.TabIndex = 1;
            // 
            // tbNama
            // 
            tbNama.BorderStyle = BorderStyle.None;
            tbNama.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbNama.Location = new Point(51, 76);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(397, 28);
            tbNama.TabIndex = 0;
            tbNama.TextChanged += tbNama_TextChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackgroundImageLayout = ImageLayout.Stretch;
            btnRegister.Location = new Point(775, 789);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(384, 122);
            btnRegister.TabIndex = 0;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnToLogin
            // 
            btnToLogin.BackgroundImageLayout = ImageLayout.Zoom;
            btnToLogin.Location = new Point(842, 912);
            btnToLogin.Name = "btnToLogin";
            btnToLogin.Size = new Size(224, 38);
            btnToLogin.TabIndex = 1;
            btnToLogin.Click += btnToLogin_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Location = new Point(722, 103);
            panel2.Name = "panel2";
            panel2.Size = new Size(437, 111);
            panel2.TabIndex = 2;
            // 
            // UcRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(btnToLogin);
            Controls.Add(btnRegister);
            Controls.Add(panel1);
            Name = "UcRegister";
            Size = new Size(1920, 1060);
            Load += UcRegister_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel btnRegister;
        private Panel btnToLogin;
        private TextBox tbNama;
        private TextBox tbKonfirmasiPw;
        private TextBox tbUsername;
        private TextBox tbEmail;
        private TextBox tbNomorTelepon;
        private TextBox tbPassword;
        private Panel panel2;
    }
}
