using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Siskop
{
    public partial class panelNasabah : UserControl
    {
        private int _nasabahId;
        private string _nasabahNama;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NasabahId
        {
            get { return _nasabahId; }
            set { _nasabahId = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NasabahNama
        {
            get { return _nasabahNama ?? string.Empty; }
            set { _nasabahNama = value; }
        }

        // Parameterless constructor for designer
        public panelNasabah()
        {
            InitializeComponent();
        }

        // Modified constructor to chain to parameterless version
        public panelNasabah(Nasabah nasabah) : this()
        {
            SetNasabahData(nasabah);
        }

        // Consolidated data setting logic
        public void SetNasabahData(Nasabah nasabah)
        {
            if (nasabah != null)
            {
                NasabahId = nasabah.Id_Nasabah;
                NasabahNama = nasabah.Nama;
                label2.Text = $"{nasabah.Id_Nasabah}";
                lbNama.Text = nasabah.Nama ?? string.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("horeee");
        }
    }
}