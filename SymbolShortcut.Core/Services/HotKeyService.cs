using SymbolShortcut.Core.Enums;
using SymbolShortcut.Core.Extensions;
using System.Runtime.InteropServices;

namespace SymbolShortcut.Core.Services
{
    public class HotKeyService : IHotKeyService
    {
        private MessageWindow? _wnd;
        private IntPtr? _hwnd;
        private readonly ManualResetEvent _windowReadyEvent = new(false);
        private int _id = 0;
        private SymbolShortcutConfig? _config;

        public event EventHandler<HotKeyEventArgs>? HotKeyPressed;
        public delegate void RegisterHotKeyDelegate(IntPtr hwnd, int id, uint modifiers, uint key);
        public delegate void UnRegisterHotKeyDelegate(IntPtr hwnd, int id);


        public HotKeyService()
        {
            Thread messageLoop = new(delegate ()
            {
                Application.Run(new MessageWindow(this));
            })
            {
                Name = "MessageLoopThread",
                IsBackground = true
            };
            messageLoop.Start();
        }

        public void RegisterConfigHotKeys(SymbolShortcutConfig config)
        {
            if (config.Shortcuts == null)
            {
                return;
            }

            _config = config;
            foreach (var shortcut in config.Shortcuts)
            {
                shortcut.Id = RegisterHotKey(shortcut.Key, shortcut.Modifiers);
            }
        }

        public int RegisterHotKey(Keys key, KeyModifiers modifiers)
        {
            _windowReadyEvent.WaitOne();
            int id = Interlocked.Increment(ref _id);

            if (_wnd == null)
            {
                throw new NullReferenceException();
            }

            _wnd.Invoke(new RegisterHotKeyDelegate(RegisterHotKeyInternal), _hwnd, id, (uint)modifiers, (uint)key);
            return id;
        }

        public void UnregisterHotKey(int id)
        {
            if(_wnd == null)
            {
                throw new NullReferenceException();
            }

            _wnd.Invoke(new UnRegisterHotKeyDelegate(UnRegisterHotKeyInternal), _hwnd, id);
        }

        public void Attach(MessageWindow messageWindow)
        {
            _wnd = messageWindow;
            _hwnd = messageWindow.Handle;
            _windowReadyEvent.Set();
        }

        public void RaiseHotKeyEvent(HotKeyEventArgs e)
        {
            if (_config == null || _config.Shortcuts == null)
            {
                return;
            }

            e.Shortcut = _config.Shortcuts.SingleOrDefault(
                x => x.Key == e.Key &&
                x.Modifiers == e.Modifiers &&
                x.IsEnabled);
            if(e.Shortcut != null)
            {
                SendKeys.Send(e.Shortcut.Output);
                HotKeyPressed?.Invoke(null, e);
            }
        }

        private void RegisterHotKeyInternal(IntPtr hwnd, int id, uint modifiers, uint key)
        {
            RegisterHotKey(hwnd, id, modifiers, key);
        }

        private void UnRegisterHotKeyInternal(IntPtr hwnd, int id)
        {
            UnregisterHotKey(_hwnd.GetValueOrDefault(), id);
        }

        [DllImport("user32", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);        
    }
}
