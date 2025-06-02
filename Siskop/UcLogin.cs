using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using project_ecoranger.Models;


namespace project_ecoranger.Views
{
    public partial class UcLogin : UserControl
    {
        MainForm mainForm;
        PenyuplaiContext penyuplai;
        PengepulContext pengepul;
        private int id;
        public UcLogin(MainForm mainForm)
        {
            InitializeComponent();
            cbRole.Items.Add("Pengepul");
            cbRole.Items.Add("Penyuplai");
            this.mainForm = mainForm;
            penyuplai = new PenyuplaiContext();
            pengepul = new PengepulContext();
            clearTextBox();
        }
        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UcLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tbUsername.Text;
                string password = tbPassword.Text;
                string role = cbRole.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Username dan Password Tidak Boleh Kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (role == "Penyuplai")
                    {

                        if (penyuplai.LoginPenyuplai(username, password, out id))
                        {
                            mainForm.dashboardPenyuplai.setSesion(id);
                            mainForm.ShowPage(mainForm.dashboardPenyuplai);
                            clearTextBox();
                        }
                        else
                        {
                            MessageBox.Show("Username atau Password Salah", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (role == "Pengepul")
                    {
                        if (pengepul.LoginPengepul(username, password))
                        {
                            mainForm.dashboardPengepul.SetSesion();
                            mainForm.ShowPage(mainForm.dashboardPengepul);
                            clearTextBox();
                        }
                        else
                        {
                            MessageBox.Show("Username atau Password Salah", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearTextBox()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            cbRole.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {

            mainForm.ShowPage(mainForm.registerpage);
        }
    }
}
