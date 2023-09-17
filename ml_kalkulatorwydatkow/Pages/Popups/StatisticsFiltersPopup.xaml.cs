using CommunityToolkit.Maui.Views;
using ml_kalkulatorwydatkow;

namespace ml_kalkulatorwydatkow;

public partial class StatisticsFiltersPopup : Popup
{
    public Statystyki lRef { get ; set; }
	public StatisticsFiltersPopup()
	{
		InitializeComponent();
        dTo.Date = App.db.to;
        dFrom.Date = App.db.from;
        dTo.MaximumDate = DateTime.Now;
        dFrom.Date = DateTime.MinValue;
    }

    private void btn_update_Clicked(object sender, EventArgs e)
    {
        App.db.from = dFrom.Date;
        App.db.to = dTo.Date;
        Close();
    }
}