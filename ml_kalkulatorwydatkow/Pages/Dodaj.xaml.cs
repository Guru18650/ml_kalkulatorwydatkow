using ml_kalkulatorwydatkow.Data;

namespace ml_kalkulatorwydatkow;

public partial class Dodaj : ContentPage
{
    SQLiteDbContext db;

    public Dodaj()
	{
	db = new SQLiteDbContext();
        InitializeComponent();
		dateEntry.MaximumDate = DateTime.Now;
	}


    private async void Add_Clicked(object sender, EventArgs e)
    {
		if (string.IsNullOrEmpty(nameEntry.Text) || string.IsNullOrEmpty(ammountEntry.Text) || typeEntry.SelectedIndex < 1)
		{
			await DisplayAlert("B³¹d", "Wpisz poprawne dane", "ok");
			return;

		}
        DEntry tempEntry = new DEntry() {
			Name = nameEntry.Text,
			Ammount = float.Parse(ammountEntry.Text),
			Date = dateEntry.Date,
			Category = typeEntry.SelectedItem.ToString(),
		};
        db.addEntry(tempEntry);
        await DisplayAlert("Sukces", "Dodano wpis", "ok");
		Navigation.RemovePage(this);
    }
}