using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly Process process = new();
        private bool realClose = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            process.StartInfo.FileName = "clash.exe";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!realClose)
            {
                e.Cancel = true;
                Hide();
            }
            else
            {
                process.Kill();
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            realClose = true;
            Close();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process.Kill();
            Thread.Sleep(1000);
            process.Start();
            MessageBox.Show("已重新启动 Clash。");
        }
    }
}