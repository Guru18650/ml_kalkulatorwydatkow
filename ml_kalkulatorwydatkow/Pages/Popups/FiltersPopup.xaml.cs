using CommunityToolkit.Maui.Views;

namespace ml_kalkulatorwydatkow;

public partial class FiltersPopup : Popup
{
    public Lista lRef { get ; set; }
	public FiltersPopup()
	{
		InitializeComponent();
        dTo.Date = App.db.to;
        dFrom.Date = App.db.from;
        dTo.MaximumDate = DateTime.Now;
        dFrom.Date = DateTime.MinValue;
        typeEntry.SelectedItem = App.db.filtr;
        sortType.SelectedItem = App.db.sortType;
        sortDirection.SelectedItem = App.db.direction;
        limitEntry.Text = App.db.limit.ToString();
    }

    private void btn_update_Clicked(object sender, EventArgs e)
    {
        App.db.from = dFrom.Date;
        App.db.to = dTo.Date;
        App.db.filtr = typeEntry.SelectedItem.ToString();
        App.db.sortType = sortType.SelectedItem.ToString();
        App.db.direction = sortDirection.SelectedItem.ToString();
        App.db.limit = int.Parse(limitEntry.Text);
        lRef.processEntries();
        Close();
            }
}