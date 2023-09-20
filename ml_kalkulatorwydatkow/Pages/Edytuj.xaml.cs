using Microsoft.Maui.Controls;
using ml_kalkulatorwydatkow.Data;

namespace ml_kalkulatorwydatkow;

public partial class Edytuj : ContentPage
{

    public DEntry edited { get ; set; }
	public Edytuj(DEntry e)
	{
		InitializeComponent();
        edited = e;
        nameEntry.Text = edited.Name;
        ammountEntry.Text = edited.Ammount.ToString();
        dateEntry.Date = edited.Date;
        typeEntry.SelectedItem = edited.Category;
    }

    private async void Update_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(nameEntry.Text) || string.IsNullOrEmpty(ammountEntry.Text) || typeEntry.SelectedIndex < 0)
        {
            await DisplayAlert("B³¹d", "Wpisz poprawne dane", "ok");
            return;

        }
        edited.Name = nameEntry.Text;
        edited.Ammount = float.Parse(ammountEntry.Text);
        edited.Date = dateEntry.Date;
        edited.Category = typeEntry.SelectedItem.ToString();

        App.db.updateEntry(edited);
        await DisplayAlert("Sukces", "Edytowano wpis", "ok");
        await Navigation.PushAsync(new Lista());
        Navigation.RemovePage(this);
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        App.db.deleteEntry(edited);
        await DisplayAlert("Sukces", "Usuniêto wpis", "ok");
        await Navigation.PushAsync(new Lista());
        Navigation.RemovePage(this);
    }
}