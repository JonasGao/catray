using System.Diagnostics;
using System.Text;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private string _clash = "clash.exe";
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

    private Process InitializeClashComponent()
    {
        var process = new Process();
        process.StartInfo.FileName = _clash;
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
        MessageBox.Show("Restarted Clash.");
    }

    private void QueryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!_clashRunning)
        {
            SetOutput("Running Flag: false");
            return;
        }
        int pid;
        try
        {
            pid = _process.Id;
        }
        catch (Exception)
        {
            SetOutput("Running Flag: true. But Process not exists");
            return;
        }
        var content = new StringBuilder()
            .Append("ID: ").AppendLine(pid.ToString())
            .Append("Running Flag: ").AppendLine(_clashRunning.ToString())
            .Append("HasExited: ").AppendLine(_process.HasExited.ToString())
            .ToString();
        SetOutput(content);
    }

    private void StartupClash()
    {
        if (!File.Exists(_clash))
        {
            MessageBox.Show("Can not found clash.exe");
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
        textBox1.Text = content;
    }
}