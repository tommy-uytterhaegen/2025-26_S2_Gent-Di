using HoGentMaui.ViewModels;
using HoGentMauiBL.Interfaces;
using HoGentMauiBL.Services;
using Microsoft.Extensions.Logging;

namespace HoGentMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()

                // Our services
                .RegisterServices()

                // Our viewmodels
                .RegisterViewModels()
                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<JokeService>();
            builder.Services.AddTransient<IJokeRespository, JokeRepository>();

            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainViewModel>();

            return builder;
        }


    }
}
