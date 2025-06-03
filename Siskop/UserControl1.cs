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
using project_ecoranger;

namespace Siskop
{
    public partial class UserControl1 : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly NasabahModel _nasabahModel;

        private readonly FlowLayoutPanel flowLayoutPanel;

        public UserControl1(MainForm mainForm, string connstring)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _nasabahModel = new NasabahModel(connstring);

            // Subscribe to data changes
            _nasabahModel.DataChanged += LoadNasabahPanels;

            // Initial load
            LoadNasabahPanels();
        }

        private void LoadNasabahPanels()
        {
            try
            {
                // Clear existing panels
                flowLayoutPanel1.Controls.Clear();

                // Get current nasabah list
                var nasabahs = _nasabahModel.GetNasabahs();

                // Create and add panels
                foreach (var nasabah in nasabahs)
                {
                    var panel = new panelNasabah(nasabah)
                    {
                        Margin = new Padding(5),
                    };


                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading nasabah panels: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to refresh the panels manually if needed
        public void RefreshPanels()
        {
            LoadNasabahPanels();
        }

        // Cleanup on disposal
       
    }
}