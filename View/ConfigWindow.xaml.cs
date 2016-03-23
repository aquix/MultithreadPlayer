using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab7.Model;

namespace Lab7.View
{
    /// <summary>
    /// Логика взаимодействия для ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private bool isConfigChanged = false;
        private bool crazyMode;
        private string culture;
        private bool needRestart;

        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PickSettings();
            needRestart = false;

            if (Configuration.Instance.CrazyMode != crazyMode) {
                Configuration.Instance.CrazyMode = crazyMode;
                isConfigChanged = true;
                needRestart = true;
            }

            if (Configuration.Instance.Culture != culture) {
                Configuration.Instance.Culture = culture;
                isConfigChanged = true;
            }

            if (isConfigChanged) {
                Configuration.Instance.UpdateConfig(needRestart);
            }

            this.Close();
        }

        private void PickSettings()
        {
            crazyMode = (bool)cboxCrazyMode.IsChecked;
            culture = (string)comboCulture.SelectedValue;
        }
    }
}
