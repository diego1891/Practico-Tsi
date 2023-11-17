using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PracticoMobile.Services;
using PracticoMobile.ViewModel;
using PracticoMobile.Views;

namespace PracticoMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<INavegacionService, NavegacionService>();
            builder.Services.AddSingleton<UsuarioService>();

            builder.Services.AddTransient<UsuarioViewModel>();
            builder.Services.AddTransient<UsuarioPage>();

            builder.Services.AddTransient<UsuarioDetailViewModel>();
            builder.Services.AddTransient<UsuarioDetailPage>();

            Routing.RegisterRoute(nameof(UsuarioDetailPage), typeof(UsuarioDetailPage));

            builder.Services.AddSingleton(Connectivity.Current);
            builder.Services.AddSingleton<HttpClient>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}