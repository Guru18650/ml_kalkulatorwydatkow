using CommunityToolkit.Maui.Views;
using ml_kalkulatorwydatkow.Data;
using System.Globalization;

namespace ml_kalkulatorwydatkow;

public partial class Lista : ContentPage
{
    public Lista()
	{
        
        InitializeComponent();
		processEntries();
    }

    private void btn_filters_Clicked(object sender, EventArgs e)
    {
        var popup = new FiltersPopup();
        popup.lRef = this;
        this.ShowPopup(popup);
    }
    public void processEntries()
    {
        
        var entries = App.db.getEntries();
        ilosc.Text = "Iloœæ: " + entries.Count;
        suma.Text = "Suma: " + entries.Sum(entry => entry.Ammount);
        entryListView.ItemsSource = entries;
    }

    private async void entryListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        DEntry selectedEntry = e.Item as DEntry;
        if (selectedEntry != null)
        {
            await Navigation.PushAsync(new Edytuj(selectedEntry));
            Navigation.RemovePage(this);
        }

    }
}
