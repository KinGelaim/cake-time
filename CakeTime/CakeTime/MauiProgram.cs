using CakeTime.Application;
using CakeTime.Domain;
using CakeTime.Infrastructure;
using CakeTime.Presentation.ViewModels;
using Microsoft.Extensions.Logging;

namespace CakeTime;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => fonts.AddFont("DroidSansMono.ttf", "DroidSansMono"));

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddSingleton<IEventRepository, EventRepository>();
        builder.Services.AddSingleton<EventService>();
        builder.Services.AddSingleton<INotificationSettingsRepository, NotificationSettingsRepository>();
        builder.Services.AddSingleton<NotificationSettingsService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}