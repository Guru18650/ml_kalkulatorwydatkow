using ml_kalkulatorwydatkow.Data;
using System.Globalization;

namespace ml_kalkulatorwydatkow
{
    public partial class App : Application
    {
        public static SQLiteDbContext db;
        public App()
        {
            db = new SQLiteDbContext();
            InitializeComponent();
            CultureInfo myCurrency = new CultureInfo(Preferences.Get("currency", "pl-PL"));
            CultureInfo.DefaultThreadCurrentCulture = myCurrency;
            Application.Current.UserAppTheme = AppTheme.Light;
            MainPage = new NavigationPage(new MainPage());
        }
    }
}