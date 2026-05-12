using HoGentMaui.Services;
using HoGentMaui.ViewModels;
using HoGentMauiBL.Interfaces;
using HoGentMauiBL.Services;
using MauiJokesBL.Services;
using MauiJokesDL;
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

                // Our routes
                .RegisterRoutes()

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
            builder.Services.AddTransient<MessageService>();
            builder.Services.AddTransient<NavigationService>();
            builder.Services.AddTransient<JokeService>();
            builder.Services.AddTransient<IJokeRespository, LiteDBJokeRepository>();

            builder.Services.AddSingleton<DatabaseConnection, DatabaseConnection>();

            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<JokeListViewModel>();
            builder.Services.AddTransient<JokeDetailViewModel>();

            return builder;
        }

        private static MauiAppBuilder RegisterRoutes(this MauiAppBuilder builder)
        {
            Routing.RegisterRoute(nameof(JokeDetailPage), typeof(JokeDetailPage));

            return builder;
        }

    }
}
