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
        public int NasabahId { get; set; }
        public string NasabahNama { get; set; }
        
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
            NasabahId = nasabah.Id;
            NasabahNama = nasabah.Nama;
            label2.Text = $"{nasabah.Id}";
            lbNama.Text = nasabah.Nama;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Existing event handler
        }
    }
}