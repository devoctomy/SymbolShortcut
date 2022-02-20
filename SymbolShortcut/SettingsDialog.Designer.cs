namespace SymbolShortcut
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.ShortcutsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsPanel.SuspendLayout();
            this.NotifyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.ShortcutsCheckedListBox);
            this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(397, 420);
            this.SettingsPanel.TabIndex = 0;
            // 
            // ShortcutsCheckedListBox
            // 
            this.ShortcutsCheckedListBox.FormattingEnabled = true;
            this.ShortcutsCheckedListBox.Location = new System.Drawing.Point(12, 12);
            this.ShortcutsCheckedListBox.Name = "ShortcutsCheckedListBox";
            this.ShortcutsCheckedListBox.Size = new System.Drawing.Size(373, 400);
            this.ShortcutsCheckedListBox.TabIndex = 0;
            this.ShortcutsCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ShortcutsCheckedListBox_ItemCheck);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "SymbolShortcut";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            this.NotifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDown);
            // 
            // NotifyContextMenu
            // 
            this.NotifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startWithWindowsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.NotifyContextMenu.Name = "NotifyContextMenu";
            this.NotifyContextMenu.Size = new System.Drawing.Size(179, 54);
            this.NotifyContextMenu.VisibleChanged += new System.EventHandler(this.NotifyContextMenu_VisibleChanged);
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Start With Windows";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.startWithWindowsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 420);
            this.Controls.Add(this.SettingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsDialog";
            this.Text = "Symbol Shortcut Settings";
            this.SettingsPanel.ResumeLayout(false);
            this.NotifyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel SettingsPanel;
        private CheckedListBox ShortcutsCheckedListBox;
        private NotifyIcon NotifyIcon;
        private ContextMenuStrip NotifyContextMenu;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem startWithWindowsToolStripMenuItem;
    }
}