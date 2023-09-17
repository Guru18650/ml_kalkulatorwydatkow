using CommunityToolkit.Maui.Views;
using ml_kalkulatorwydatkow;

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

        private async void Lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista());
        }

        private async void Staty_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statystyki());
        }

        private async void Ustawienia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ustawienia());
        }
    }
}