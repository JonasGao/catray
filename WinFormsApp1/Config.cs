using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Config
    {
        private const string ConfigFileName = ".config";

        public string ClashFileName { get; set; }

        public string ProfileFileName { get; set; }

        public bool AutoStartupClash { get; set; }

        public Config(string clashFileName, string profileFileName, bool autoStartupClash)
        {
            ClashFileName = clashFileName;
            ProfileFileName = profileFileName;
            AutoStartupClash = autoStartupClash;
        }

        public void Save()
        {
            File.WriteAllLines(ConfigFileName, new string[]{
                ClashFileName,
                ProfileFileName,
                AutoStartupClash.ToString()
            });
        }

        public static Config ReadConfig()
        {
            if (!File.Exists(ConfigFileName))
            {
                return new Config("clash.exe", "", false);
            }

            var lines = File.ReadAllLines(ConfigFileName);
            string clashFileName = null!;
            string profileFileName = "";
            bool autoStartupClash = false;
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

            if (lines.Length > 2)
            {
                string value = lines[2];
                autoStartupClash = string.Equals(value, "true");
            }

            return new Config(clashFileName, profileFileName, autoStartupClash);
        }
    }
}
