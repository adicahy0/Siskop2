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
    public partial class PinjamanControl : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly PinjamanModel _pinjamanModel;
        private readonly FlowLayoutPanel flowLayoutPanel;
        private List<Pinjaman> allpinjaman; // Store all pinjaman data for searching

        public PinjamanControl(MainForm mainForm, string connstring)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _pinjamanModel = new PinjamanModel(connstring);

            // Initialize the list
            allpinjaman = new List<Pinjaman>();

            // Subscribe to data changes
            _pinjamanModel.DataChanged += LoadPinjamanPanels;

            // Initial load
            LoadPinjamanPanels();
        }

        private void LoadPinjamanPanels()
        {
            try
            {
                // Get current pinjaman list and store it
                allpinjaman = _pinjamanModel.GetPinjamans();

                // Populate with all data
                PopulatepinjamanLayout(allpinjaman);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pinjaman panels: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to populate FlowLayout with pinjaman list
        private void PopulatepinjamanLayout(List<Pinjaman> pinjamanList)
        {
            // Clear existing controls
            flowLayoutPanel1.Controls.Clear();

            // Suspend layout for better performance
            flowLayoutPanel1.SuspendLayout();

            try
            {
                foreach (var pinjaman in pinjamanList)
                {
                    var panel = new panelPinjaman(pinjaman)
                    {
                        Margin = new Padding(5),
                    };
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
            finally
            {
                // Resume layout
                flowLayoutPanel1.ResumeLayout(true);
            }
        }

        // Method to clear search and show all
        public void ClearSearch()
        {
            PopulatepinjamanLayout(allpinjaman);
        }

        // Method to refresh the panels manually if needed
        public void RefreshPanels()
        {
            LoadPinjamanPanels();
        }

        // Method to get current pinjaman count (useful for status display)
        public int GetCurrentpinjamanCount()
        {
            return flowLayoutPanel1.Controls.Count;
        }

        // Method to get total pinjaman count
        public int GetTotalpinjamanCount()
        {
            return allpinjaman?.Count ?? 0;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        // Cleanup on disposal


    }
}