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
    public partial class UserControl1: UserControl
    {
            private readonly NasabahModel nasabahModel;
            private readonly FlowLayoutPanel flowLayoutPanel;

        nasabahModel.DataChanged += LoadNasabahPanels;
        
        // Initial load
        LoadNasabahPanels();
    }

    private void LoadNasabahPanels()
        {
            // Clear existing panels
            flowLayoutPanel.Controls.Clear();

            // Get current nasabah list
            var nasabahs = nasabahModel.GetNasabahs();

            // Create and add panels
            foreach (var nasabah in nasabahs)
            {
                var panel = new NasabahPanel
                {
                    Margin = new Padding(10),
                    Width = 200,
                    Height = 80
                };

                panel.SetNasabahData(nasabah);

                // Optional: Handle click events
                panel.PanelClicked += (sender, e) =>
                {
                    var clickedPanel = (NasabahPanel)sender;
                    MessageBox.Show($"Selected: {clickedPanel.NasabahNama}\nID: {clickedPanel.NasabahId}");
                };

                flowLayoutPanel.Controls.Add(panel);
            }
        }

        // Cleanup on form close
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            nasabahModel.DataChanged -= LoadNasabahPanels;
            base.OnFormClosing(e);
        }

        public UserControl1()
        {
            InitializeComponent();
        }
    }
}
