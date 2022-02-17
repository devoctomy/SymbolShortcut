namespace SymbolShortcut.Core.Services
{
    public class MessageWindow : Form
    {
        private readonly HotKeyService _hotKeyService;

        public MessageWindow(HotKeyService hotKeyService)
        {
            _hotKeyService = hotKeyService;
            _hotKeyService.Attach(this);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                var e = new HotKeyEventArgs(m.LParam);
                _hotKeyService.RaiseHotKeyEvent(e);
            }

            base.WndProc(ref m);
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }

        private const int WM_HOTKEY = 0x312;
    }
}
