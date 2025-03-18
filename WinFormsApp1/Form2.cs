using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private Config configResult;

        internal Config GetConfigResult()
        {
            return configResult;
        }

        public Form2()
        {
            InitializeComponent();
            hostingProfile.LoadProfiles(Config.ReadConfig());
        }

        private void HostingProfile_Ok(object sender, EventArgs e)
        {
            HostingProfileOkEventArgs args = (HostingProfileOkEventArgs)e;
            List<HostingProfile> profiles = args.profiles;
            // 保存配置
            Config config = Config.ReadConfig();
            config.Profiles = profiles;
            config.Save();
            DialogResult = DialogResult.OK;
            configResult = config;
            Close();
        }

        private void HostingProfile_Cancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
