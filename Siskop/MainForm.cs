using System.Net;
using project_ecoranger.Views;

namespace project_ecoranger
{
    public partial class MainForm : Form
    {
        public UcLoadingScreen loadingScreen;
        public UcStartPage startPage;
        public UcLogin loginPage;
        public UcRegister registerpage;
        public UcDashboardPengepul dashboardPengepul;
        public UcKelolaPenyuplai kelolaPenyuplai;
        public UcKelolaSubKategori kelolaSubKategori;
        public UcKelolaLaporan kelolaLaporan;
        public UcKelolaHistory kelolaHistory;
        public UcKelolaHistoryTransaksi kelolaHistoryTransaksi;
        public UcKelolaHistoryPenukaran kelolaHistoryPenukaran;
        public UcKelolaHistoryPenarikan kelolaHistoryPenarikan;
        public UcKelolaKonfirmasiTransaksi kelolaKonfirmasiTransaksi;
        public UcKelolaKonfirmasiPenarikan kelolaKonfirmasiPenarikan;
        public UcDashboardPenyuplai dashboardPenyuplai;
        public UcDataDiriPenyuplai viewDataDiriPenyuplai;
        public UcTransaksiPenyuplai viewTransaksiPenyuplai;
        public UcHistoryPenyuplai viewHistoryPenyuplai;
        public UcKeuanganPenyuplai viewKeuanganPenyuplai;
        public UcHistoryPenarikanPenyuplai viewHistoryPenarikanPenyuplai;
        public UcHistoryPenukaranPoin viewHistoryPenukaranPoin;
        public UcHistoryTransaksiPenyuplai viewHistoryTransaksiPenyuplai;

        System.Windows.Forms.Timer timer;
        public MainForm()
        {
            InitializeComponent();
            loadingScreen = new UcLoadingScreen();
            startPage = new UcStartPage(this);
            loginPage = new UcLogin(this);
            registerpage = new UcRegister(this);
            
            kelolaPenyuplai = new UcKelolaPenyuplai(this);
            kelolaSubKategori = new UcKelolaSubKategori(this);
            kelolaLaporan = new UcKelolaLaporan(this);
            kelolaHistory = new UcKelolaHistory(this);
            

            kelolaHistoryTransaksi = new UcKelolaHistoryTransaksi(this);
            kelolaHistoryPenarikan = new UcKelolaHistoryPenarikan(this);
            kelolaHistoryPenukaran = new UcKelolaHistoryPenukaran(this);
            kelolaKonfirmasiTransaksi = new UcKelolaKonfirmasiTransaksi(this);
            kelolaKonfirmasiPenarikan = new UcKelolaKonfirmasiPenarikan(this);
            viewDataDiriPenyuplai = new UcDataDiriPenyuplai(this);
            viewTransaksiPenyuplai = new UcTransaksiPenyuplai(this);
            viewHistoryPenyuplai = new UcHistoryPenyuplai(this);
            viewKeuanganPenyuplai = new UcKeuanganPenyuplai(this);
            viewHistoryPenarikanPenyuplai = new UcHistoryPenarikanPenyuplai(this);
            viewHistoryPenukaranPoin = new UcHistoryPenukaranPoin(this);
            viewHistoryTransaksiPenyuplai = new UcHistoryTransaksiPenyuplai(this);
            dashboardPenyuplai = new UcDashboardPenyuplai(this);
            dashboardPengepul = new UcDashboardPengepul(this);

            this.Controls.Add(registerpage);
            this.Controls.Add(startPage);
            this.Controls.Add(loginPage);

            
            this.Controls.Add(kelolaPenyuplai);
            this.Controls.Add(kelolaSubKategori);
            this.Controls.Add(kelolaLaporan);
            this.Controls.Add(kelolaHistory);
            this.Controls.Add(kelolaHistoryTransaksi);
            this.Controls.Add(kelolaHistoryPenarikan);
            this.Controls.Add(kelolaHistoryPenukaran);
            this.Controls.Add(kelolaKonfirmasiTransaksi);
            this.Controls.Add(kelolaKonfirmasiPenarikan);
            this.Controls.Add(dashboardPengepul);

            this.Controls.Add(dashboardPenyuplai);
            this.Controls.Add(viewDataDiriPenyuplai);
            this.Controls.Add(viewKeuanganPenyuplai);
            this.Controls.Add(viewHistoryPenyuplai);
            this.Controls.Add(viewTransaksiPenyuplai);
            this.Controls.Add(viewHistoryPenarikanPenyuplai);
            this.Controls.Add(viewHistoryPenukaranPoin);
            this.Controls.Add(viewHistoryTransaksiPenyuplai);
            HideAllPage();
            //this.Controls.Add(dashboardPengepul);
            //dashboardPenyuplai.Visible = true;
            dashboardPengepul.Visible = true;
            //this.Controls.Add(dashboardPenyuplai);
            //this.Controls.Add(loadingScreen);

            //timer = new System.Windows.Forms.Timer();
            //timer.Interval = 2500;
            //timer.Tick += timer_tick;
            //timer.Start();

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
