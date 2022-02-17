using SymbolShortcut.Core.Enums;

namespace SymbolShortcut.Core.Services
{
    public class Shortcut
    {
        public bool IsEnabled { get; set; } = true;
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public Keys Key { get; set; }
        public KeyModifiers Modifiers { get; set; }
        public string? Output { get; set; }
    }
}
