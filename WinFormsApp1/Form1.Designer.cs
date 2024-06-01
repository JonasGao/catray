namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            openToolStripMenuItem = new ToolStripMenuItem();
            openConsoleToolStripMenuItem = new ToolStripMenuItem();
            queryToolStripMenuItem = new ToolStripMenuItem();
            killClashToolStripMenuItem = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            configCoreToolStripMenuItem = new ToolStripMenuItem();
            autoStartupClashTrayMenuItem = new ToolStripMenuItem();
            autoStartupClashMenuItem = new ToolStripMenuItem();
            externalUiMenuItem = new ToolStripMenuItem();
            configProfileToolStripMenuItem = new ToolStripMenuItem();
            localProfileMenuItem = new ToolStripMenuItem();
            updateProfileMenuItem = new ToolStripMenuItem();
            hostingProfileMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            logTextBox = new TextBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Clash Tray";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, openConsoleToolStripMenuItem, queryToolStripMenuItem, killClashToolStripMenuItem, restartToolStripMenuItem, toolStripSeparator1, configCoreToolStripMenuItem, autoStartupClashTrayMenuItem, autoStartupClashMenuItem, externalUiMenuItem, configProfileToolStripMenuItem, updateProfileMenuItem, hostingProfileMenuItem, toolStripSeparator2, closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(185, 302);
            contextMenuStrip1.Text = "Clash as Tray";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(184, 22);
            openToolStripMenuItem.Text = "打开窗口";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // openConsoleToolStripMenuItem
            // 
            openConsoleToolStripMenuItem.Name = "openConsoleToolStripMenuItem";
            openConsoleToolStripMenuItem.Size = new Size(184, 22);
            openConsoleToolStripMenuItem.Text = "打开控制台";
            openConsoleToolStripMenuItem.Click += OpenConsoleToolStripMenuItem_Click;
            // 
            // queryToolStripMenuItem
            // 
            queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            queryToolStripMenuItem.Size = new Size(184, 22);
            queryToolStripMenuItem.Text = "查询进程状态";
            queryToolStripMenuItem.Click += QueryToolStripMenuItem_Click;
            // 
            // killClashToolStripMenuItem
            // 
            killClashToolStripMenuItem.Name = "killClashToolStripMenuItem";
            killClashToolStripMenuItem.Size = new Size(184, 22);
            killClashToolStripMenuItem.Text = "关闭 Clash";
            killClashToolStripMenuItem.Click += KillClashToolStripMenuItem_Click;
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(184, 22);
            restartToolStripMenuItem.Text = "重新启动";
            restartToolStripMenuItem.Click += RestartToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(181, 6);
            // 
            // configCoreToolStripMenuItem
            // 
            configCoreToolStripMenuItem.Name = "configCoreToolStripMenuItem";
            configCoreToolStripMenuItem.Size = new Size(184, 22);
            configCoreToolStripMenuItem.Text = "配置 Core";
            configCoreToolStripMenuItem.Click += ConfigCoreToolStripMenuItem_Click;
            // 
            // autoStartupClashTrayMenuItem
            // 
            autoStartupClashTrayMenuItem.Name = "autoStartupClashTrayMenuItem";
            autoStartupClashTrayMenuItem.Size = new Size(184, 22);
            autoStartupClashTrayMenuItem.Text = "自动启动 ClashTray";
            autoStartupClashTrayMenuItem.Click += AutoStartupClashTrayMenuItem_Click;
            // 
            // autoStartupClashMenuItem
            // 
            autoStartupClashMenuItem.Name = "autoStartupClashMenuItem";
            autoStartupClashMenuItem.Size = new Size(184, 22);
            autoStartupClashMenuItem.Text = "自动启动 Clash";
            autoStartupClashMenuItem.Click += AutoStartupClashMenuItem_Click;
            // 
            // externalUiMenuItem
            // 
            externalUiMenuItem.Name = "externalUiMenuItem";
            externalUiMenuItem.Size = new Size(184, 22);
            externalUiMenuItem.Text = "配置 External UI";
            externalUiMenuItem.Click += ExternalUiMenuItem_Click;
            // 
            // configProfileToolStripMenuItem
            // 
            configProfileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localProfileMenuItem });
            configProfileToolStripMenuItem.Name = "configProfileToolStripMenuItem";
            configProfileToolStripMenuItem.Size = new Size(184, 22);
            configProfileToolStripMenuItem.Text = "配置 Profile";
            // 
            // localProfileMenuItem
            // 
            localProfileMenuItem.Name = "localProfileMenuItem";
            localProfileMenuItem.Size = new Size(141, 22);
            localProfileMenuItem.Text = "本地 Profile";
            localProfileMenuItem.Click += LocalProfileMenuItem_Click;
            // 
            // updateProfileMenuItem
            // 
            updateProfileMenuItem.Name = "updateProfileMenuItem";
            updateProfileMenuItem.Size = new Size(184, 22);
            updateProfileMenuItem.Text = "更新当前 Profile";
            updateProfileMenuItem.Click += UpdateProfileMenuItem_Click;
            // 
            // hostingProfileMenuItem
            // 
            hostingProfileMenuItem.Name = "hostingProfileMenuItem";
            hostingProfileMenuItem.Size = new Size(184, 22);
            hostingProfileMenuItem.Text = "配置托管 Profile";
            hostingProfileMenuItem.Click += HostingProfileMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(181, 6);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(184, 22);
            closeToolStripMenuItem.Text = "退出";
            closeToolStripMenuItem.Click += ToolStripMenuItem1_Click;
            // 
            // logTextBox
            // 
            logTextBox.BackColor = Color.Black;
            logTextBox.BorderStyle = BorderStyle.None;
            logTextBox.ContextMenuStrip = contextMenuStrip1;
            logTextBox.Dock = DockStyle.Fill;
            logTextBox.Font = new Font("Sarasa Mono SC", 9F, FontStyle.Regular, GraphicsUnit.Point);
            logTextBox.ForeColor = Color.WhiteSmoke;
            logTextBox.Location = new Point(0, 0);
            logTextBox.Margin = new Padding(5);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.Size = new Size(642, 480);
            logTextBox.TabIndex = 2;
            logTextBox.WordWrap = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 480);
            Controls.Add(logTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClashTray 0.11";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem queryToolStripMenuItem;
        private ToolStripMenuItem killClashToolStripMenuItem;
        private ToolStripMenuItem openConsoleToolStripMenuItem;
        private ToolStripMenuItem configCoreToolStripMenuItem;
        private ToolStripMenuItem configProfileToolStripMenuItem;
        private ToolStripMenuItem hostingProfileMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem autoStartupClashMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem localProfileMenuItem;
        private ToolStripMenuItem updateProfileMenuItem;
        private ToolStripMenuItem externalUiMenuItem;
        private ToolStripMenuItem autoStartupClashTrayMenuItem;
        private TextBox logTextBox;
    }
}