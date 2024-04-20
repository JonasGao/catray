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
            autoStartupClashMenuItem = new ToolStripMenuItem();
            configProfileToolStripMenuItem = new ToolStripMenuItem();
            hostingProfileMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            localProfileMenuItem = new ToolStripMenuItem();
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
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, openConsoleToolStripMenuItem, queryToolStripMenuItem, killClashToolStripMenuItem, restartToolStripMenuItem, toolStripSeparator1, configCoreToolStripMenuItem, autoStartupClashMenuItem, configProfileToolStripMenuItem, hostingProfileMenuItem, toolStripSeparator2, closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(160, 236);
            contextMenuStrip1.Text = "Clash as Tray";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(159, 22);
            openToolStripMenuItem.Text = "打开窗口";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // openConsoleToolStripMenuItem
            // 
            openConsoleToolStripMenuItem.Name = "openConsoleToolStripMenuItem";
            openConsoleToolStripMenuItem.Size = new Size(159, 22);
            openConsoleToolStripMenuItem.Text = "打开控制台";
            openConsoleToolStripMenuItem.Click += OpenConsoleToolStripMenuItem_Click;
            // 
            // queryToolStripMenuItem
            // 
            queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            queryToolStripMenuItem.Size = new Size(159, 22);
            queryToolStripMenuItem.Text = "查询进程状态";
            queryToolStripMenuItem.Click += QueryToolStripMenuItem_Click;
            // 
            // killClashToolStripMenuItem
            // 
            killClashToolStripMenuItem.Name = "killClashToolStripMenuItem";
            killClashToolStripMenuItem.Size = new Size(159, 22);
            killClashToolStripMenuItem.Text = "关闭 Clash";
            killClashToolStripMenuItem.Click += KillClashToolStripMenuItem_Click;
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(159, 22);
            restartToolStripMenuItem.Text = "重新启动";
            restartToolStripMenuItem.Click += RestartToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(156, 6);
            // 
            // configCoreToolStripMenuItem
            // 
            configCoreToolStripMenuItem.Name = "configCoreToolStripMenuItem";
            configCoreToolStripMenuItem.Size = new Size(159, 22);
            configCoreToolStripMenuItem.Text = "配置 Core";
            configCoreToolStripMenuItem.Click += ConfigCoreToolStripMenuItem_Click;
            // 
            // autoStartupClashMenuItem
            // 
            autoStartupClashMenuItem.Name = "autoStartupClashMenuItem";
            autoStartupClashMenuItem.Size = new Size(159, 22);
            autoStartupClashMenuItem.Text = "自动启动 Clash";
            autoStartupClashMenuItem.Click += AutoStartupClashMenuItem_Click;
            // 
            // configProfileToolStripMenuItem
            // 
            configProfileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localProfileMenuItem });
            configProfileToolStripMenuItem.Name = "configProfileToolStripMenuItem";
            configProfileToolStripMenuItem.Size = new Size(159, 22);
            configProfileToolStripMenuItem.Text = "配置 Profile";
            // 
            // hostingProfileMenuItem
            // 
            hostingProfileMenuItem.Name = "hostingProfileMenuItem";
            hostingProfileMenuItem.Size = new Size(159, 22);
            hostingProfileMenuItem.Text = "托管 Profile";
            hostingProfileMenuItem.Click += HostingProfileMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(156, 6);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(159, 22);
            closeToolStripMenuItem.Text = "退出";
            closeToolStripMenuItem.Click += ToolStripMenuItem1_Click;
            // 
            // label1
            // 
            label1.ContextMenuStrip = contextMenuStrip1;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(467, 382);
            label1.TabIndex = 1;
            label1.Text = "右键菜单控制";
            // 
            // localProfileMenuItem
            // 
            localProfileMenuItem.Name = "localProfileMenuItem";
            localProfileMenuItem.Size = new Size(180, 22);
            localProfileMenuItem.Text = "本地 Profile";
            localProfileMenuItem.Click += LocalProfileMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 382);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "ClashTray";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
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
        private Label label1;
        private ToolStripMenuItem hostingProfileMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem autoStartupClashMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem localProfileMenuItem;
    }
}