using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_ecoranger.Views
{
    public partial class UcStartPage : UserControl
    {
        MainForm mainForm;
        
        public UcStartPage(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(mainForm.loginPage);
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(mainForm.registerpage);

        }
    }
}
