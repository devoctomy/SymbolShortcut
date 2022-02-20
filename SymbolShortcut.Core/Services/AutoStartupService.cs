using Microsoft.Win32;

namespace SymbolShortcut.Core.Services
{
    public class AutoStartupService : IAutoStartupService
    {
        private readonly AutoStartupServiceConfig _config;
        private readonly RegistryKey? _runKey;
        public bool IsSet { get; private set; }

        public AutoStartupService(AutoStartupServiceConfig config)
        {
            _config = config;
            _runKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            UpdateIsSet();
        }

        public void Add()
        {
            if(_runKey == null)
            {
                throw new InvalidOperationException();
            }

            _runKey.SetValue(_config.AppName!, Application.ExecutablePath);
            UpdateIsSet();
        }

        public void Remove()
        {
            if (_runKey == null)
            {
                throw new InvalidOperationException();
            }

            _runKey.DeleteValue(_config.AppName!, false);
            UpdateIsSet();
        }

        private void UpdateIsSet()
        {
            if (_runKey == null)
            {
                throw new InvalidOperationException();
            }

            IsSet = _runKey.GetValue(_config.AppName!) != null;
        }
    }
}
