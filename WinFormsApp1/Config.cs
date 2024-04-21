﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Config
    {
        private const string ConfigFileName = ".config";

        private const string DefaultProfileDir = ".profiles";

        private readonly List<string> _options;

        public string ClashFileName
        {
            get
            {
                return _options.Get(0) ?? "clash.exe";
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
                return _options.Get(4) ?? DefaultProfileDir;
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

        public bool CustomExternalUi
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ExternalUi);
            }
        }

        private Config()
        {
            _options = new List<string>();
        }

        private Config(string[] options)
        {
            _options = new(options);
        }

        public void Save()
        {
            File.WriteAllLines(ConfigFileName, _options.ToArray());
        }

        public static Config ReadConfig()
        {
            if (!File.Exists(ConfigFileName))
            {
                return new Config();
            }

            return new Config(File.ReadAllLines(ConfigFileName));
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
            return ProfileDir + "/" + profile.Name;
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
            if (source.Count <= index)
            {
                return null;
            }
            return source[index];
        }

        public static void Set(this List<string> source, int index, string value)
        {
            if (source.Count < index)
            {
                for (int i = source.Count - 1; i <= index; i++)
                {
                    source.Add("");
                }
            }
            source[index] = value;
        }
    }
}
