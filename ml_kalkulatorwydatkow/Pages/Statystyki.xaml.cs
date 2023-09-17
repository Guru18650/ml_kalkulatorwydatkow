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

public partial class MainPageVM
{
    List<DEntry> entries = App.db.getEntries();

    public ISeries[] Series { get; set; } = new ISeries[] {

        new PieSeries<double> {Values = new double[] { 1 }, DataLabelsFormatter = point => "Test", DataLabelsPaint = new SolidColorPaint(SKColors.Black),},
        new PieSeries<double> {Values = new double[] { 1 }},
        new PieSeries<double> {Values = new double[] { 1 }},
        new PieSeries<double> {Values = new double[] { 1 }},
   };
}
