using Microsoft.Extensions.DependencyInjection;
using SymbolShortcut.Core.Services;

namespace SymbolShortcut.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCoreServices(
            this IServiceCollection services,
            SymbolShortcutConfig config)
        {
            services.AddSingleton(config);
            var autoStartupServiceConfig = new AutoStartupServiceConfig
            {
                AppName = config.AppName
            };
            services.AddScoped<IAutoStartupService, AutoStartupService>(s => new AutoStartupService(autoStartupServiceConfig));
            services.AddSingleton<IHotKeyService, HotKeyService>();
        }
    }
}
