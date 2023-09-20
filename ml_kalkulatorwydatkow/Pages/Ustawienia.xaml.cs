using System.Globalization;

namespace ml_kalkulatorwydatkow;

public partial class Ustawienia : ContentPage
{

	public List<string> Currencies = new List<string>()
	{
		"pl-PL","en-US","de-DE","en-GB","de-CH","en-CA","en-AU"
	};


    public Ustawienia()
	{
		InitializeComponent();
		string currency = Preferences.Get("currency", "pl-PL");
		currencyPick.SelectedIndex = Currencies.IndexOf(currency);
	}

    private async void btn_update_Clicked(object sender, EventArgs e)
    {
		Preferences.Set("currency", Currencies[currencyPick.SelectedIndex]);
        CultureInfo myCurrency = new CultureInfo(Preferences.Get("currency", "pl-PL"));
        CultureInfo.DefaultThreadCurrentCulture = myCurrency;
		await DisplayAlert("Sukces", "Zapisano ustawienia", "OK");
		await Navigation.PopAsync();
    }

    private async void btn_clear_Clicked(object sender, EventArgs e)
    {
        var x = await DisplayAlert("Uwaga", "Czy na pewno chcesz to zrobiæ?", "TAK", "NIE");
		if (x)
		{
			App.db.clearTable();
            await DisplayAlert("Sukces", "Usuniêto wszystkie dane", "OK");
            await Navigation.PopAsync();

        }

    }
}
