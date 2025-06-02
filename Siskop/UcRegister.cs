using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project_ecoranger.Models;

namespace project_ecoranger.Views
{
    public partial class UcRegister : UserControl
    {
        MainForm mainForm;
        PenyuplaiContext penyuplai;
        public UcRegister(MainForm mainForm)
        {
            InitializeComponent();
           
            this.mainForm = mainForm;
            penyuplai = new PenyuplaiContext();
        }

        private void UcRegister_Load(object sender, EventArgs e)
        {

        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {


                string nama = tbNama.Text;
                BigInteger nomorTelepon = Convert.ToUInt64(tbNomorTelepon.Text);
                string email = tbEmail.Text;
                string username = tbUsername.Text;
                string password = tbPassword.Text;
                string konfirmasiPassword = tbKonfirmasiPw.Text;

                if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(tbNomorTelepon.Text) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(konfirmasiPassword))
                {
                    MessageBox.Show("Harap isi selurh form", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Email tidak valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (password != konfirmasiPassword)
                    {
                        MessageBox.Show("Password dan Konfirmasi Password tidak cocok", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        penyuplai.RegisterPenyuplai(nama, nomorTelepon, email, username, password);
                        penyuplai.CreateAlamat(username, password);
                        MessageBox.Show("Registrasi Berhasil Dilakukan, silahkan login menggunakan username dan password yang telah dibuat", "register berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainForm.ShowPage(mainForm.loginPage);
                        clearTextBox();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat registrasi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearTextBox()
        {
            tbNama.Clear();
            tbNomorTelepon.Clear();
            tbEmail.Clear();
            tbUsername.Clear();
            tbPassword.Clear();
            tbKonfirmasiPw.Clear();
        }

        private void btnToLogin_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(mainForm.loginPage);
        }
    }
}
