namespace SymbolShortcut.Core.Services
{
    public interface IAutoStartupService
    {
        bool IsSet { get; }
        void Add();
        void Remove();
    }
}
