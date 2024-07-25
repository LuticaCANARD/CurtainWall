using CurtainWall.BackEnd.Data.Communication;
using Microsoft.Extensions.Logging;
using ScheduleController;
using Microsoft.Extensions.Localization;
namespace CurtainWall
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            // 이하 DB
            builder.Services.AddDbContext<ScheduleDBContext>();
            
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddBlazorBootstrap();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddLocalization();
            return builder.Build();
        }
    }
}
