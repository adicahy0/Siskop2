using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project_ecoranger.Models;

namespace project_ecoranger.Views
{
    public partial class UcDashboardPengepul : UserControl
    {
        MainForm mainform;
        int idPengepul;
        TransaksiContext transaksiContext;
        PenyuplaiContext penyuplaiContext;
        List<Transaksi> listTransaksi;
        int jumlahPenyuplai;
        public UcDashboardPengepul(MainForm mainform)
        {
            InitializeComponent();
            this.mainform = mainform;

            penyuplaiContext = new PenyuplaiContext();
            jumlahPenyuplai = penyuplaiContext.GetJumlahPenyuplai();
            lblJumlahPenyuplai.Text = $"{jumlahPenyuplai}";
            
            SetSesion();
        }
        public void SetSesion()
        {
            transaksiContext = new TransaksiContext();
            listTransaksi = transaksiContext.getAllTransaksiForPengepulDashboard(1);
            mainform.kelolaPenyuplai.SetSesion(); 
            mainform.kelolaKonfirmasiTransaksi.SetSesion();
            mainform.kelolaSubKategori.SetSesion();
            mainform.kelolaHistoryTransaksi.SetSesion();

            int jarak = 400;
            foreach (var value in listTransaksi)
            {
                int idTransaksi = value.idTransaksi;

                Panel fillCard = new Panel();
                Panel btnTerima = new Panel();
                Panel btnTolak = new Panel();
                Label lblBerat = new Label();
                Label lblHarga = new Label();
                Label lblSampah = new Label();
                Label lblPenyuplai = new Label();
                Label lblTanggal = new Label();
                Label lblIdTransaksi = new Label();


                // fillCard
                // 
                fillCard.BackgroundImage = Properties.Resources.fillCard;
                fillCard.BackgroundImageLayout = ImageLayout.Stretch;
                fillCard.BackColor = Color.Transparent;
                fillCard.Controls.Add(lblBerat);
                fillCard.Controls.Add(lblHarga);
                fillCard.Controls.Add(lblSampah);
                fillCard.Controls.Add(lblPenyuplai);
                fillCard.Controls.Add(lblTanggal);
                fillCard.Controls.Add(lblIdTransaksi);
                fillCard.Controls.Add(btnTolak);
                fillCard.Controls.Add(btnTerima);
                fillCard.Location = new Point(jarak, 574);
                fillCard.Name = "fillCard";
                fillCard.Size = new Size(401, 388);
                fillCard.TabIndex = 5;
                // 
                // lblBerat
                // 
                lblBerat.AutoSize = true;
                lblBerat.BackColor = Color.Transparent;
                lblBerat.Font = new Font("Roboto Black", 16F, FontStyle.Bold);
                lblBerat.ForeColor = SystemColors.Control;
                lblBerat.Location = new Point(9, 252);
                lblBerat.Name = "lblBerat";
                lblBerat.Size = new Size(169, 27);
                lblBerat.TabIndex = 13;
                lblBerat.Text = $" Berat Sampah : {value.beratSampah} Kg";
                // 
                // lblHarga
                // 
                lblHarga.AutoSize = true;
                lblHarga.BackColor = Color.Transparent;
                lblHarga.Font = new Font("Roboto Black", 16F, FontStyle.Bold);
                lblHarga.ForeColor = SystemColors.Control;
                lblHarga.ImageAlign = ContentAlignment.MiddleRight;
                lblHarga.Location = new Point(9, 207);
                lblHarga.Name = "lblHarga";
                lblHarga.Size = new Size(129, 27);
                lblHarga.TabIndex = 12;
                lblHarga.Text = $"Harga / Kg : Rp.{value.hargaSampah}";
                // 
                // lblSampah
                // 
                lblSampah.AutoSize = true;
                lblSampah.BackColor = Color.Transparent;
                lblSampah.Font = new Font("Roboto Black", 16F, FontStyle.Bold);
                lblSampah.ForeColor = SystemColors.Control;
                lblSampah.Location = new Point(9, 163);
                lblSampah.Name = "lblSampah";
                lblSampah.Size = new Size(110, 27);
                lblSampah.TabIndex = 11;
                lblSampah.Text = $"Sampah : {value.namaSampah}";
                // 
                // lblPenyuplai
                // 
                lblPenyuplai.AutoSize = true;
                lblPenyuplai.BackColor = Color.Transparent;
                lblPenyuplai.Font = new Font("Roboto Black", 16F, FontStyle.Bold);
                lblPenyuplai.ForeColor = SystemColors.Control;
                lblPenyuplai.Location = new Point(9, 122);
                lblPenyuplai.Name = "lblPenyuplai";
                lblPenyuplai.Size = new Size(116, 27);
                lblPenyuplai.TabIndex = 10;
                lblPenyuplai.Text = $"Penyuplai : {value.namaPenyuplai}";
                // 
                // lblTanggal
                // 
                lblTanggal.AutoSize = true;
                lblTanggal.BackColor = Color.Transparent;
                lblTanggal.Font = new Font("Roboto Black", 16F, FontStyle.Bold);
                lblTanggal.ForeColor = SystemColors.Control;
                lblTanggal.Location = new Point(9, 82);
                lblTanggal.Name = "lblTanggal";
                lblTanggal.Size = new Size(175, 27);
                lblTanggal.TabIndex = 9;
                lblTanggal.Text = $"Tanggal Masuk : {value.tanggalTransaksi.Date.ToShortDateString()}";
                // 
                // lblIdTransaksi
                // 
                lblIdTransaksi.AutoSize = true;
                lblIdTransaksi.BackColor = Color.Transparent;
                lblIdTransaksi.Font = new Font("Roboto Black", 20F, FontStyle.Bold);
                lblIdTransaksi.ForeColor = SystemColors.Control;
                lblIdTransaksi.Location = new Point(16, 9);
                lblIdTransaksi.Name = "lblIdTransaksi";
                lblIdTransaksi.Size = new Size(179, 33);
                lblIdTransaksi.TabIndex = 8;
                lblIdTransaksi.Text = $"ID Transaksi : {value.idTransaksi}";
                // 
                // btnTolak
                // 
                btnTolak.BackColor = Color.Transparent;
                btnTolak.BackgroundImage = Properties.Resources.BtnTolak;
                btnTolak.BackgroundImageLayout = ImageLayout.Stretch;
                btnTolak.Location = new Point(62, 322);
                btnTolak.Name = "btnTolak";
                btnTolak.Size = new Size(133, 47);
                btnTolak.TabIndex = 7;
                btnTolak.Click += (s, e) =>
                {
                    if (MessageBox.Show("Apakah Anda Yakin Menolak Transaksi ini ? ", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        transaksiContext.konfirmasiTransaksi(value.idTransaksi, 3);
                        MessageBox.Show("Transaksi Berhasil Ditolak", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flowLayoutPanel1.Controls.Clear();
                        SetSesion();
                    }

                };
                // 
                // btnTerima
                // 
                btnTerima.BackColor = Color.Transparent;
                btnTerima.BackgroundImage = Properties.Resources.btnTerima;
                btnTerima.BackgroundImageLayout = ImageLayout.Stretch;
                btnTerima.Location = new Point(202, 323);
                btnTerima.Name = "btnTerima";
                btnTerima.Size = new Size(133, 47);
                btnTerima.TabIndex = 6;
                btnTerima.Click += (s, e) =>
                {
                    if (MessageBox.Show("Apakah Anda Yakin Akan Memproses Transaksi ini ? ", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        transaksiContext.konfirmasiTransaksi(value.idTransaksi, 2);
                        MessageBox.Show("Transaksi Sudah Diperoses", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flowLayoutPanel1.Controls.Clear();
                        SetSesion();
                    }
                };

                flowLayoutPanel1.Controls.Add(fillCard);
                jarak += fillCard.Height + 30;
            }

      
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainform.ShowPage(mainform.dashboardPengepul);
        }

        private void btnSubKategori_Click(object sender, EventArgs e)
        {
            mainform.ShowPage(mainform.kelolaSubKategori);
        }
        private void btnPenyuplai_Click(object sender, EventArgs e)
        {
            mainform.ShowPage(mainform.kelolaPenyuplai);
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            mainform.ShowPage(mainform.kelolaLaporan);
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            mainform.ShowPage(mainform.kelolaHistory);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            mainform.ShowPage(mainform.startPage);
        }
    }
}
