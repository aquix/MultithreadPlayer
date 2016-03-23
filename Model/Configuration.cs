using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lab7.ViewModel;

namespace Lab7.Model
{
    [Serializable]
    public class Configuration
    {
        private Configuration()
        {
        }

        public static int savings = 0;
        private static Configuration config;
        public static Configuration Instance
        {
            get
            {
                if (config == null) {
                    config = new Configuration();
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    if (File.Exists("Player.conf")) {
                        using (Stream stream = new FileStream("Player.conf", FileMode.Open)) {
                            config = (Configuration)binFormatter.Deserialize(stream);
                        }
                    }
                }
                return config;
            }
        }

        private string culture;

        public bool CrazyMode { get; set; } = false;
        public string Culture
        {
            get
            {
                return culture;
            }
            set
            {
                culture = value;
                CultureInfo ci = new CultureInfo(Instance.Culture);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                StringsViewModel.Instance.SubmitCultureChanged();
            }
        }

        public bool NeedRestart { get; set; }

        [field: NonSerialized()]
        public event Action<bool> ConfigChanged;

        public void UpdateConfig(bool needRestart)
        {
            if (ConfigChanged != null && savings == 0) {
                ConfigChanged(needRestart);
            }
        }
    }
}
