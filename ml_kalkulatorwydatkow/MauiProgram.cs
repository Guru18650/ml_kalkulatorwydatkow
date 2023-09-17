using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ml_kalkulatorwydatkow.Data;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace ml_kalkulatorwydatkow
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseSkiaSharp(true)
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
            builder.Services.AddSingleton<SQLiteDbContext>();
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();
#endif

            return builder.Build();
        }
    }
}