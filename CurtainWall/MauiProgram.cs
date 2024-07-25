using CurtainWall.BackEnd.Data.Communication;
using Microsoft.Extensions.Logging;
using ScheduleController;
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
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

			return builder.Build();
        }
    }
}
