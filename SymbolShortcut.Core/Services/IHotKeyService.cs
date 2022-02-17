using SymbolShortcut.Core.Enums;
using SymbolShortcut.Core.Extensions;

namespace SymbolShortcut.Core.Services
{
    public interface IHotKeyService
    {
        event EventHandler<HotKeyEventArgs>? HotKeyPressed;

        int RegisterHotKey(Keys key, KeyModifiers modifiers);
        void UnregisterHotKey(int id);
        void RegisterConfigHotKeys(SymbolShortcutConfig config);
    }
}
