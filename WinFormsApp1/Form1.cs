using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly ClashProcess clashProcess;
    private bool _realClose;

    public Form1()
    {
        InitializeComponent();
        InitializeEncoding();
        clashProcess = ClashProcess.Create();
    }

    private static void InitializeEncoding()
    {
        var provider = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(provider);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // 启动的时候加载配置
        var config = Config.ReadConfig();
        // 如果当前配置是使用本地配置。则勾选对应选项
        localProfileMenuItem.Checked = !config.EnableHostingProfile;
        // 把配置的托管配置加载到菜单
        foreach (HostingProfile hostingProfile in config.Profiles)
        {
            ToolStripMenuItem item = new()
            {
                Text = hostingProfile.Name,
            };
            item.Click += ProfileItem_Click;
            configProfileToolStripMenuItem.DropDownItems.Add(item);
        }
        // 如果使用了托管配置，则勾选对应的托管配置菜单项
        if (config.EnableHostingProfile)
        {
            if (string.IsNullOrWhiteSpace(config.UsingProfileName))
            {
                localProfileMenuItem.Checked = true;
            }
            else
            {
                bool found = false;
                foreach (ToolStripMenuItem item in configProfileToolStripMenuItem.DropDownItems)
                {
                    if (item.Text == config.UsingProfileName)
                    {
                        item.Checked = true;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    config.EnableHostingProfile = false;
                    config.UsingProfileName = "";
                    localProfileMenuItem.Checked = true;
                    config.Save();
                }
            }
        }
        // 如果配置了自动启动，则在此时启动 Clash
        if (config.AutoStartupClash)
        {
            StartupClash(config);
            // 标记自动启动
            autoStartupClashMenuItem.Checked = true;
        }
        // 标记是否使用外部UI
        externalUiMenuItem.Checked = config.CustomExternalUi;
        // 标记是否是自动启动
        autoStartupClashTrayMenuItem.Checked = config.AutoStartupClashTray;
        // 标记是否允许外部访问控制接口和视图
        publicExuiMenuItem.Checked = config.PublicExternalUi;
    }

    private void ProfileItem_Click(object? sender, EventArgs e)
    {
        if (sender == null)
        {
            MessageBox.Show("Sender is null. Enable hosting profile failed.");
            return;
        }
        ToolStripMenuItem senderItem = (ToolStripMenuItem)sender;
        Config config = Config.ReadConfig();
        config.EnableHostingProfile = true;
        config.UsingProfileName = senderItem.Text;
        config.Save();
        foreach (ToolStripMenuItem item in configProfileToolStripMenuItem.DropDownItems)
        {
            item.Checked = item.Text == config.UsingProfileName;
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!_realClose)
        {
            e.Cancel = true;
            Hide();
        }
        else
        {
            KillClash();
        }
    }

    private void ToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        _realClose = true;
        Close();
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Show();
    }

    private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
    {
        KillClash();
        Thread.Sleep(1000);
        if (StartupClash(Config.ReadConfig()))
        {
            AppendOutput("Successfully restart.");
        }
        else
        {
            AppendOutput("Restart failed.");
        }
    }

    private void QueryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        AppendOutput(clashProcess.QueryProcess());
    }

    internal bool StartupClash(Config config)
    {
        if (clashProcess.Running)
        {
            SetOutput("Clash is runing.");
            return false;
        }

        if (!File.Exists(config.ClashFileName))
        {
            SetOutput("Can not found clash: " + config.ClashFileName);
            return false;
        }

        StringBuilder args = new();

        // 查找对应的配置
        if (config.EnableHostingProfile)
        {
            string? path = UpdateCurrentProfile(config);
            if (path != null)
            {
                args.Append(" -f ").Append(path);
            }
        }
        else
        {
            // 使用本地配置
            if (!string.IsNullOrEmpty(config.ProfileFileName))
            {
                if (!File.Exists(config.ProfileFileName))
                {
                    SetOutput("Can not found profile: " + config.ProfileFileName);
                    return false;
                }

                args.Append(" -f ").Append(config.ProfileFileName);
            }
        }

        // 配置外部UI
        if (config.CustomExternalUi)
        {
            args.Append(" -ext-ui ").Append(config.ExternalUi);
            if (config.PublicExternalUi)
            {
                args.Append(" -ext-ctl 0.0.0.0:9090");
            }
            else
            {
                args.Append(" -ext-ctl 127.0.0.1:9090");
            }
        }

        logTextBox.Text = "";
        clashProcess.Startup(config.ClashFileName, args);
        AppendOutput(clashProcess.QueryProcess());
        return true;
    }

    private string? UpdateCurrentProfile(Config config)
    {
        // 使用托管配置
        HostingProfile? profile = config.CurrentHostingProfile;
        if (!profile.HasValue)
        {
            return null;
        }
        SetOutput("Found profile: " + profile.Value.Name);
        string path = config.PathOf(profile.Value);
        if (!File.Exists(path))
        {
            DownloadProfile(profile.Value, path, config);
        }
        return path;
    }

    private async void DownloadProfile(HostingProfile profile, string path, Config config)
    {
        AppendOutput("Downloading profile: " + profile.URL);
        AppendOutput("Downloading to: " + path);
        // 确定目录
        if (!Directory.Exists(config.ProfileDir))
        {
            Directory.CreateDirectory(config.ProfileDir);
        }
        // 开始下载
        using HttpClient client = new();
        HttpResponseMessage resp = await client.GetAsync(profile.URL);
        if (resp.IsSuccessStatusCode)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                await resp.Content.CopyToAsync(fs);
            AppendOutput("Successful downloaded");
        }
        else
        {
            var body = await resp.Content.ReadAsStringAsync();
            AppendOutput(string.Join(Environment.NewLine,
                "Failure downloaded.",
                $"Status is \"{resp.StatusCode}\".",
                $"Body is \"{body}\"."));
        }
    }

    private void KillClash()
    {
        if (!clashProcess.Running) return;
        clashProcess.Kill();
    }

    private void KillClashToolStripMenuItem_Click(object sender, EventArgs e)
    {
        KillClash();
        AppendOutput(clashProcess.QueryProcess());
    }

    private void SetOutput(string content)
    {
        logTextBox.Text = content;
    }

    private void AppendOutput(string content)
    {
        logTextBox.Text = logTextBox.Text + Environment.NewLine + content;
    }

    private void ConfigCoreToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var d = new OpenFileDialog
        {
            Filter = @"应用程序(*.exe)|*.exe"
        };
        var r = d.ShowDialog();
        if (r == DialogResult.OK)
        {
            Config config = Config.ReadConfig();
            config.ClashFileName = d.FileName;
            config.Save();
            SetOutput("Using clash core：" + d.FileName);
        }

        d.Dispose();
    }

    private void OpenConsoleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        const string target = "http://localhost:9090/ui";
        try
        {
            Process.Start(new ProcessStartInfo { FileName = target, UseShellExecute = true });
        }
        catch (Win32Exception noBrowser)
        {
            if (noBrowser.ErrorCode == -2147467259)
            {
                MessageBox.Show(noBrowser.Message, @"打开控制台URL失败");
            }
        }
        catch (Exception other)
        {
            MessageBox.Show(other.Message, @"其他错误");
        }
    }

    private void HostingProfileMenuItem_Click(object sender, EventArgs e)
    {
        Form2 form2 = new();
        DialogResult result = form2.ShowDialog();
        Config config = form2.GetConfigResult();
        if (result == DialogResult.OK)
        {
            // 更新菜单画面
            configProfileToolStripMenuItem.DropDownItems.Clear();
            configProfileToolStripMenuItem.DropDownItems.Add(localProfileMenuItem);
            foreach (HostingProfile hostingProfile in config.Profiles)
            {
                ToolStripMenuItem item = new()
                {
                    Text = hostingProfile.Name,
                };
                item.Click += ProfileItem_Click;
                configProfileToolStripMenuItem.DropDownItems.Add(item);
            }
            // 如果使用了托管配置，则勾选对应的托管配置菜单项
            if (config.EnableHostingProfile)
            {
                if (!string.IsNullOrWhiteSpace(config.UsingProfileName))
                {
                    foreach (ToolStripMenuItem item in configProfileToolStripMenuItem.DropDownItems)
                    {
                        if (item.Text == config.UsingProfileName)
                        {
                            item.Checked = true;
                            break;
                        }
                    }
                }
            }
        }
    }

    private void AutoStartupClashMenuItem_Click(object sender, EventArgs e)
    {
        Config config = Config.ReadConfig();
        config.AutoStartupClash = autoStartupClashMenuItem.Checked = !autoStartupClashMenuItem.Checked;
        config.Save();
    }

    private void LocalProfileMenuItem_Click(object sender, EventArgs e)
    {
        var d = new OpenFileDialog
        {
            Filter = @"配置文件(*.yaml)|*.yaml|配置文件(*.yml)|*.yml"
        };
        var r = d.ShowDialog();
        if (r == DialogResult.OK)
        {
            Config config = Config.ReadConfig();
            config.ProfileFileName = d.FileName;
            config.EnableHostingProfile = false;
            config.Save();
            localProfileMenuItem.Checked = true;
            SetOutput("Using config file：" + d.FileName);
        }

        d.Dispose();
    }

    private void UpdateProfileMenuItem_Click(object sender, EventArgs e)
    {
        Config config = Config.ReadConfig();
        HostingProfile? profile = config.CurrentHostingProfile;
        if (profile.HasValue)
        {
            SetOutput("Found profile: " + profile.Value.Name);
            string path = config.PathOf(profile.Value);
            DownloadProfile(profile.Value, path, config);
        }
    }

    private void ExternalUiMenuItem_Click(object sender, EventArgs e)
    {
        // 如果当前使用了。则取消这个配置
        if (externalUiMenuItem.Checked)
        {
            Config config = Config.ReadConfig();
            config.ExternalUi = "";
            config.Save();
            externalUiMenuItem.Checked = false;
        }
        else
        {
            var d = new FolderBrowserDialog();
            var r = d.ShowDialog();
            if (r == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(d.SelectedPath))
                {
                    Config config = Config.ReadConfig();
                    config.ExternalUi = d.SelectedPath;
                    config.Save();
                    externalUiMenuItem.Checked = true;
                }
            }
            d.Dispose();
        }
    }

    private void AutoStartupClashTrayMenuItem_Click(object sender, EventArgs e)
    {
        Config config = Config.ReadConfig();
        config.AutoStartupClashTray = autoStartupClashTrayMenuItem.Checked = !autoStartupClashTrayMenuItem.Checked;
        config.Save();
    }

    private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
    {
        Show();
    }

    private void PublicExuiMenuItem_Click(object sender, EventArgs e)
    {
        Config config = Config.ReadConfig();
        config.PublicExternalUi = publicExuiMenuItem.Checked = !publicExuiMenuItem.Checked;
        config.Save();
    }

    private void LookCurrMenuItem_Click(object sender, EventArgs e)
    {
        Config config = Config.ReadConfig();
        if (string.IsNullOrWhiteSpace(config.ProfileDir))
        {
            MessageBox.Show("Profile directory is empty.", lookCurrMenuItem.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        try
        {
            using Process? _ = Process.Start(new ProcessStartInfo()
            {
                FileName = config.ProfileDir,
                UseShellExecute = true,
                Verb = "open"
            });
        } catch (Exception ex) { 
            MessageBox.Show(ex.Message, lookCurrMenuItem.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}