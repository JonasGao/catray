using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Config
    {
        private readonly string _configFileName;
        private readonly List<string> _options;

        public string ClashFileName
        {
            get
            {
                return _options.Get(0) ?? Path.Join(Application.StartupPath, "clash.exe");
            }
            set
            {
                _options.Set(0, value);
            }
        }

        public string ProfileFileName
        {
            get
            {
                return _options.Get(1) ?? "";
            }
            set
            {
                _options.Set(1, value);
            }
        }

        public bool AutoStartupClash
        {
            get
            {
                return string.Equals(_options.Get(2), "True");
            }
            set
            {
                _options.Set(2, value.ToString());
            }
        }

        public bool EnableHostingProfile
        {
            get
            {
                return string.Equals(_options.Get(3), "True");
            }
            set
            {
                _options.Set(3, value.ToString());
            }
        }

        public string ProfileDir
        {
            get
            {
                return _options.Get(4) ?? Path.Join(Application.StartupPath, ".profiles");
            }
            set
            {
                _options.Set(4, value);
            }
        }

        public string UsingProfileName
        {
            get
            {
                return _options.Get(5) ?? "";
            }
            set
            {
                _options.Set(5, value);
            }
        }

        public List<HostingProfile> Profiles
        {
            get
            {
                return string.IsNullOrWhiteSpace(_options.Get(6)) ? new() : DecodeProfiles(_options.Get(6)!);
            }
            set
            {
                _options.Set(6, EncodeProfiles(value));
            }
        }

        public string ExternalUi
        {
            get
            {
                return _options.Get(7) ?? "";
            }
            set
            {
                _options.Set(7, value);
            }
        }

        public bool AutoStartupClashTray {
            get
            {
                return string.Equals(_options.Get(8), "True");
            }
            set
            {
                _options.Set(8, value.ToString());
                SetupAutoStartup(value);
            }
        }

        public bool PublicExternalUi
        {
            get
            {
                return string.Equals(_options.Get(9), "True");
            }
            set
            {
                _options.Set(9, value.ToString());
            }
        }

        private static void SetupAutoStartup(bool enabled)
        {
            var name = "com.github.jonasgao.clashtray";
            var subkeyName = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            var parentkey = Registry.CurrentUser;
            var subkey = parentkey.OpenSubKey(subkeyName, true);
            subkey ??= parentkey.CreateSubKey(subkeyName, true);
            if (enabled)
            {
                subkey.SetValue(name, Application.ExecutablePath);
            } else
            {
                subkey.DeleteValue(name, false);
            }
            subkey.Close();
        }

        public bool CustomExternalUi
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ExternalUi);
            }
        }

        private Config(string configPath)
        {
            _options = [];
            _configFileName = configPath;
        }

        private Config(string configPath, string[] options)
        {
            _options = [.. options];
            _configFileName = configPath;
        }

        public void Save()
        {
            File.WriteAllLines(_configFileName, _options.ToArray());
        }

        public static Config ReadConfig()
        {
            var configPath = Path.Join(Application.StartupPath, ".config");
            if (!File.Exists(configPath))
            {
                return new Config(configPath);
            }

            return new Config(configPath, File.ReadAllLines(configPath));
        }

        private static string EncodeProfiles(List<HostingProfile> profiles)
        {
            StringBuilder builder = new StringBuilder();
            foreach (HostingProfile profile in profiles)
            {
                builder.Append($"{profile.Name},{profile.URL};");
            }
            return builder.ToString();
        }

        private static List<HostingProfile> DecodeProfiles(string value)
        {
            List<HostingProfile> profiles = new();
            if (string.IsNullOrEmpty(value))
            {
                return profiles;
            }
            foreach (var item in value.Split(";", StringSplitOptions.RemoveEmptyEntries))
            {
                var values = item.Split(",");
                profiles.Add(new HostingProfile { Name = values[0], URL = values[1] });
            }
            return profiles;
        }

        internal string PathOf(HostingProfile profile)
        {
            return Path.Join(ProfileDir, profile.Name);
        }

        public HostingProfile? CurrentHostingProfile
        {
            get
            {
                foreach (HostingProfile i in Profiles)
                {
                    if (i.Name == UsingProfileName)
                    {
                        return i;
                    }
                }
                return null;
            }
        }
    }

    internal static class List
    {
        public static string? Get(this List<string> source, int index)
        {
            ArgumentNullException.ThrowIfNull(source);
            if (source.Count <= index)
            {
                return null;
            }
            return source[index];
        }

        public static void Set(this List<string> source, int index, string value)
        {
            ArgumentNullException.ThrowIfNull(source);
            if (source.Count <= index)
            {
                for (int i = source.Count; i <= index; i++)
                {
                    source.Add("");
                }
            }
            source[index] = value;
        }
    }
}
