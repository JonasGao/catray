using System.Diagnostics;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const string clash = "clash.exe";
        private readonly Process _process = new();
        private bool _realClose = false;
        private bool _clashRunning = false;

        public Form1()
        {
            InitializeComponent();
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
            int pid = _process.Id;
            string content = new StringBuilder()
                .Append("ID: ").AppendLine(pid.ToString())
                .Append("SessionID: ").AppendLine(_process.SessionId.ToString())
                .Append("Running: ").AppendLine(_clashRunning.ToString())
                .ToString();
            label1.Text = content;
        }

        private void StartupClash()
        {
            if (!File.Exists(clash))
            {
                MessageBox.Show("Can not found clash.exe");
                return;
            }
            _clashRunning = true;
            _process.StartInfo.FileName = clash;
            _process.StartInfo.CreateNoWindow = true;
            _process.Start();
        }

        private void KillClash()
        {
            if (_clashRunning)
            {
                _process.Kill();
                _clashRunning = false;
            }
        }

        private void KillClashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KillClash();
        }
    }
}