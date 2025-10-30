using Microsoft.Extensions.Logging;
using TodoApp.Data;
using TodoApp.Repositories;
using TodoApp.ViewModels;

namespace TodoApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<Database>();
            builder.Services.AddSingleton<IRepository, TodoRepository>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<TaskCreationPage>();
            builder.Services.AddTransient<TaskCreationViewModel>();

            return builder.Build();
        }
    }
}
