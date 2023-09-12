namespace ml_kalkulatorwydatkow
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Dodaj_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dodaj());
        }

        private void Lista_Clicked(object sender, EventArgs e)
        {

        }

        private void Staty_Clicked(object sender, EventArgs e)
        {

        }
    }
}