using System.Net;
using project_ecoranger.Views;
using Siskop;

namespace project_ecoranger
{
    public partial class MainForm : Form
    {
        private readonly string connString;
        public UcLogin loginPage;
        public UserControl1 adminDash;

        System.Windows.Forms.Timer timer;
        public MainForm()
        {
            connString = "Host=localhost;Username=postgres;Password=kanokon132;Database=users";
            InitializeComponent();
            loginPage = new UcLogin(this, connString);
            adminDash = new UserControl1(this, connString);

            this.Controls.Add(loginPage);
            this.Controls.Add(adminDash);
            HideAllPage();
            //this.Controls.Add(dashboardPengepul);
            //dashboardPenyuplai.Visible = true;
            //this.Controls.Add(dashboardPenyuplai);
            //this.Controls.Add(loadingScreen);

            //timer = new System.Windows.Forms.Timer();
            //timer.Interval = 2500;
            //timer.Tick += timer_tick;
            //timer.Start();
            ShowPage(adminDash);
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
