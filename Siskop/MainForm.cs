using System.Net;
using project_ecoranger.Views;

namespace project_ecoranger
{
    public partial class MainForm : Form
    {
        private readonly string connString;
        public UcLoadingScreen loadingScreen;
        public UcStartPage startPage;
        public UcLogin loginPage;

        System.Windows.Forms.Timer timer;
        public MainForm()
        {
            connString = "Host=localhost;Username=postgres;Password=kanokon132;Database=users";
            InitializeComponent();
            loadingScreen = new UcLoadingScreen();
            startPage = new UcStartPage(this);
            loginPage = new UcLogin(this, connString);

            this.Controls.Add(startPage);
            this.Controls.Add(loginPage);

            HideAllPage();
            //this.Controls.Add(dashboardPengepul);
            //dashboardPenyuplai.Visible = true;
            //this.Controls.Add(dashboardPenyuplai);
            //this.Controls.Add(loadingScreen);

            //timer = new System.Windows.Forms.Timer();
            //timer.Interval = 2500;
            //timer.Tick += timer_tick;
            //timer.Start();
            ShowPage(loginPage);
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
            ShowPage(startPage);

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
