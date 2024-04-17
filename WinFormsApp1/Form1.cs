using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private const string ConfigFileName = ".config";
    private readonly Process _process;
    private bool _clashRunning;
    private bool _realClose;

    public Form1()
    {
        InitializeComponent();
        InitializeEncoding();
        _process = InitializeClashComponent();
    }

    private static void InitializeEncoding()
    {
        var provider = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(provider);
    }

    private static Process InitializeClashComponent()
    {
        var process = new Process();
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        return process;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        StartupClash();
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
        if (StartupClash())
        {
            AppendOutput("Successfully restart.");
        } else
        {
            AppendOutput("Restart failed.");
        }
    }

    private void QueryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        QueryProcess();
    }

    private void QueryProcess()
    {
        var pwd = Directory.GetCurrentDirectory();
        var builder = new StringBuilder()
            .Append("# Working Directory: ").AppendLine(pwd)
            .Append("# Core: ").AppendLine(_process.StartInfo.FileName)
            .Append("# Arguments: ").AppendLine(_process.StartInfo.Arguments)
            .AppendLine("------");
        if (!_clashRunning)
        {
            builder.AppendLine("# Running Flag: false");
        }
        else
        {
            try
            {
                var pid = _process.Id;
                builder.Append("# ID: ").AppendLine(pid.ToString())
                    .Append("# Running Flag: ").AppendLine(_clashRunning.ToString())
                    .Append("# HasExited: ").AppendLine(_process.HasExited.ToString());
            }
            catch (Exception)
            {
                builder.AppendLine("# Running Flag: true. But Process not exists");
            }
        }

        var content = builder.ToString();
        SetOutput(content);
    }

    private bool StartupClash()
    {
        if (_clashRunning)
        {
            SetOutput("Clash is runing.");
            return false;
        }

        var readConfig = ReadConfig();
        var clashFileName = readConfig[0];
        var profileFileName = readConfig[1];

        if (!File.Exists(clashFileName))
        {
            SetOutput("Can not found clash.exe");
            return false;
        }

        _process.StartInfo.FileName = clashFileName;

        if (string.IsNullOrEmpty(profileFileName))
        {
            _process.StartInfo.Arguments = null;
        }
        else
        {
            if (!File.Exists(profileFileName))
            {
                SetOutput("Can not found " + profileFileName);
                return false;
            }

            _process.StartInfo.Arguments = "-f " + profileFileName;
        }

        _process.Start();
        _clashRunning = true;

        QueryProcess();
        return true;
    }

    private void KillClash()
    {
        if (!_clashRunning) return;
        _process.Kill();
        _process.WaitForExit();
        _clashRunning = false;
    }

    private void KillClashToolStripMenuItem_Click(object sender, EventArgs e)
    {
        KillClash();
        QueryProcess();
    }

    private void SetOutput(string content)
    {
        label1.Text = content;
    }

    private void AppendOutput(string content)
    {
        label1.Text = label1.Text + Environment.NewLine + content;
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
            WriteClashFileName(d.FileName);
            SetOutput("Using clash core：" + d.FileName);
        }

        d.Dispose();
    }

    private void ConfigProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var d = new OpenFileDialog
        {
            Filter = @"配置文件(*.yaml)|*.yaml|配置文件(*.yml)|*.yml"
        };
        var r = d.ShowDialog();
        if (r == DialogResult.OK)
        {
            WriteProfileFileName(d.FileName);
            SetOutput("Using config file：" + d.FileName);
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

    private static void WriteClashFileName(string clashFileName)
    {
        var readConfig = ReadConfig();
        readConfig[0] = clashFileName;
        File.WriteAllLines(ConfigFileName, readConfig);
    }

    private static void WriteProfileFileName(string profileFileName)
    {
        var readConfig = ReadConfig();
        readConfig[1] = profileFileName;
        File.WriteAllLines(ConfigFileName, readConfig);
    }

    private static string[] ReadConfig()
    {
        if (!File.Exists(ConfigFileName))
        {
            return new[] { "clash.exe", "" };
        }

        var lines = File.ReadAllLines(ConfigFileName);
        string clashFileName = null!;
        string profileFileName = "";
        if (lines.Length > 0)
        {
            clashFileName = lines[0];
        }

        if (string.IsNullOrEmpty(clashFileName))
        {
            clashFileName = "clash.exe";
        }

        if (lines.Length > 1)
        {
            profileFileName = lines[1];
        }

        return new[] { clashFileName, profileFileName };
    }
}