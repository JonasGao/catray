using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private const string configFileName = ".config";
    private readonly Process _process;
    private bool _clashRunning;
    private bool _realClose;
    private string ClashFileName
    {
        get
        {
            return _process.StartInfo.FileName;
        }
        set
        {
            _process.StartInfo.FileName = value;
            WriteClashFileName(value);
        }
    }

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
        process.StartInfo.FileName = ReadClashFileName();
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
        StartupClash();
        SetOutput("已重新启动");
    }

    private void QueryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var pwd = Directory.GetCurrentDirectory();
        var builder = new StringBuilder()
            .Append("# Working Directory: ").AppendLine(pwd)
            .Append("# Core: ").AppendLine(ClashFileName)
            .AppendLine("------");
        if (!_clashRunning)
        {
            builder.AppendLine("# Running Flag: false");
        }
        else
        {
            int pid;
            try
            {
                pid = _process.Id;
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

    private void StartupClash()
    {
        if (!File.Exists(ClashFileName))
        {
            SetOutput("Can not found clash.exe");
            return;
        }

        _clashRunning = true;
        _process.Start();
    }

    private void KillClash()
    {
        if (!_clashRunning) return;
        _process.Kill();
        _clashRunning = false;
        _process.WaitForExit();
    }

    private void KillClashToolStripMenuItem_Click(object sender, EventArgs e)
    {
        KillClash();
    }

    private void SetOutput(string content)
    {
        label1.Text = content;
    }

    private void ConfigCoreToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var d = new OpenFileDialog
        {
            Filter = "应用程序(*.exe)|*.exe"
        };
        var r = d.ShowDialog();
        if (r == DialogResult.OK)
        {
            ClashFileName = d.FileName;
            WriteClashFileName(ClashFileName);
            SetOutput("配置 Core 为：" + ClashFileName);
        }
        d.Dispose();
    }

    private void OpenConsoleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string target = "http://localhost:9090/ui";
        try
        {
            Process.Start(target);
        }
        catch (Win32Exception noBrowser)
        {
            if (noBrowser.ErrorCode == -2147467259)
            {
                MessageBox.Show(noBrowser.Message, "打开控制台URL失败");
            }
        }
        catch (Exception other)
        {
            MessageBox.Show(other.Message, "其他错误");
        }
    }

    private static void WriteClashFileName(string clashFileName)
    {
        File.WriteAllText(configFileName, clashFileName);
    }

    private static string ReadClashFileName()
    {
        string clashFileName;
        if (File.Exists(configFileName))
        {
            clashFileName = File.ReadAllText(configFileName);
            if (string.IsNullOrEmpty(clashFileName))
            {
                clashFileName = "clash.exe";
            }
        }
        else
        {
            clashFileName = "clash.exe";
        }
        return clashFileName;
    }
}