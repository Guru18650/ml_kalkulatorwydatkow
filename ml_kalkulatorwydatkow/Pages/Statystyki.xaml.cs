using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using ml_kalkulatorwydatkow.Data;

namespace ml_kalkulatorwydatkow;

public partial class Statystyki : ContentPage
{
	public Statystyki()
	{

        InitializeComponent();
	}

}

// Tworzenie wykresu

public partial class MainPageVM
{
    public static List<DEntry> en = App.db.getEntries();
    public static IEnumerable<DEntry> filtered1 = en.Where(i => i.Category == "Jedzenie");
    public static IEnumerable<DEntry> filtered2 = en.Where(i => i.Category == "Transport");
    public static IEnumerable<DEntry> filtered3 = en.Where(i => i.Category == "Rozrywka");
    public static IEnumerable<DEntry> filtered4 = en.Where(i => i.Category == "Inne");


    // Tworzenie danych wykresu

    public ISeries[] Series { get; set; } = new ISeries[] {

        new PieSeries<double> {Values = new double[] { filtered1.Count() }, DataLabelsFormatter = point => $"Jedzenie ({filtered1.Count()})", DataLabelsPaint = new SolidColorPaint(SKColors.Black),},
        new PieSeries<double> {Values = new double[] { filtered2.Count() }, DataLabelsFormatter = point => $"Transport ({filtered2.Count()})", DataLabelsPaint = new SolidColorPaint(SKColors.Black),},
        new PieSeries<double> {Values = new double[] { filtered3.Count() }, DataLabelsFormatter = point => $"Rozrywka ({filtered3.Count()})", DataLabelsPaint = new SolidColorPaint(SKColors.Black),},
        new PieSeries<double> {Values = new double[] { filtered4.Count() }, DataLabelsFormatter = point => $"Inne ({filtered4.Count()})", DataLabelsPaint = new SolidColorPaint(SKColors.Black),},
   };
}
