using SymbolShortcut.Core.Extensions;
using SymbolShortcut.Core.Services;
using System.ComponentModel;

namespace SymbolShortcut
{
    public partial class SettingsDialog : Form
    {
        public bool AllowVisible { get; set; }
        public bool AllowClose { get; set; }

        private readonly SymbolShortcutConfig _config;
        private readonly IAutoStartupService _autoStartupService;

        public SettingsDialog(
            SymbolShortcutConfig config,
            IAutoStartupService autoStartupService)
        {
            _config = config;
            _autoStartupService = autoStartupService;
            InitializeComponent();
            DisplayShortcuts();
        }

        private void DisplayShortcuts()
        {
            ((ListBox)ShortcutsCheckedListBox).DataSource = _config.Shortcuts;
            ((ListBox)ShortcutsCheckedListBox).DisplayMember = "DisplayName";
            ((ListBox)ShortcutsCheckedListBox).ValueMember = "IsEnabled";

            for (int i = 0; i < ShortcutsCheckedListBox.Items.Count; i++)
            {
                var obj = (SymbolShortcut.Core.Services.Shortcut)ShortcutsCheckedListBox.Items[i];
                ShortcutsCheckedListBox.SetItemChecked(i, obj.IsEnabled);
            }
        }

        private void ShortcutsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var shortcut = (SymbolShortcut.Core.Services.Shortcut)ShortcutsCheckedListBox.SelectedItem;
            shortcut.IsEnabled = e.NewValue == CheckState.Checked;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            AllowVisible = !AllowVisible;
            Visible = !Visible;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !AllowClose;
            base.OnClosing(e);
            AllowVisible = false;
            Visible = false;
            NotifyIcon.Visible = !AllowClose;
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(AllowVisible ? value : AllowVisible);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowClose = true;
            Close();
        }

        private void NotifyContextMenu_VisibleChanged(object sender, EventArgs e)
        {
            startWithWindowsToolStripMenuItem.Checked = _autoStartupService.IsSet;
        }

        private void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _autoStartupService.Add();
            startWithWindowsToolStripMenuItem.Checked = _autoStartupService.IsSet;
        }

        private void NotifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                NotifyContextMenu.Show(System.Windows.Forms.Cursor.Position);
            }
        }
    }
}
