using System.Net;
using project_ecoranger.Views;
using Siskop;

namespace project_ecoranger
{
    public partial class MainForm : Form
    {
        private readonly string connString;
        public UcLogin loginPage;
        public UserControl1 NasabahDash;
        public PinjamanControl PinjamanDash;

        System.Windows.Forms.Timer timer;

        public MainForm()
        {
            connString = "Host=localhost;Username=postgres;Password=kanokon132;Database=siskop";
            InitializeComponent();
            loginPage = new UcLogin(this, connString);
            NasabahDash = new UserControl1(this, connString);

            // Don't initialize PinjamanDash here since we need nasabahId
            // It will be created when needed with ShowPinjamanForNasabah method

            this.Controls.Add(loginPage);
            this.Controls.Add(NasabahDash);
            HideAllPage();

            ShowPage(NasabahDash);
        }

        public void HideAllPage()
        {
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
        }

        public void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
        }

        public void ShowPage(UserControl uc)
        {
            HideAllPage();
            uc.Visible = true;
        }

        // Method to show pinjaman for a specific nasabah
        public void ShowPinjamanForNasabah(int nasabahId)
        {
            // Remove existing PinjamanDash if it exists
            if (PinjamanDash != null)
            {
                this.Controls.Remove(PinjamanDash);
                PinjamanDash.Dispose();
            }

            // Create new PinjamanControl for specific nasabah
            PinjamanDash = new PinjamanControl(this, connString, nasabahId);
            this.Controls.Add(PinjamanDash);

            // Show the pinjaman page
            ShowPage(PinjamanDash);
        }

        // Method to go back to nasabah dashboard
        public void ShowNasabahDashboard()
        {
            ShowPage(NasabahDash);
        }

        // Method to show login page
        public void ShowLoginPage()
        {
            ShowPage(loginPage);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}