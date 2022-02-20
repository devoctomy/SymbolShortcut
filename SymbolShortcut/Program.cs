using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SymbolShortcut.Core.Enums;
using SymbolShortcut.Core.Extensions;
using SymbolShortcut.Core.Services;

namespace SymbolShortcut
{
    internal static class Program
    {
        public static ServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static async Task<int> Main()
        {
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureForms(services);

            var config = await LoadConfig();
            if(config == null)
            {
                throw new Exception("Failed to load configuration.");
            }

            config.AppName = "SymbolShortcut";
            services.AddCoreServices(config);
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            ServiceProvider = serviceProvider;

            var hotKeyService = ServiceProvider.GetRequiredService<IHotKeyService>();
            hotKeyService.RegisterConfigHotKeys(config);

            var settings = serviceProvider.GetRequiredService<SettingsDialog>();
            Application.Run(settings);

            return 0;
        }

        private static async Task<SymbolShortcutConfig?> LoadConfig()
        {
            var configPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            configPath = Path.Combine(configPath, $"SymbolShortcut{Path.DirectorySeparatorChar}config.json");
            
            if(!File.Exists(configPath))
            {
                var destFile = new FileInfo(configPath);
                destFile.Directory?.Create();
                File.Copy("Resources/defaultconfig.json", configPath);
            }

            var configJson = await File.ReadAllTextAsync(configPath);
            return JsonConvert.DeserializeObject<SymbolShortcutConfig>(configJson);
        }

        private static void ConfigureForms(IServiceCollection services)
        {
            services.AddScoped<SettingsDialog>();
        }
    }
}