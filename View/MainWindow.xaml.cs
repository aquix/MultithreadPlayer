using System.Windows;
using System.Threading;
using System.Globalization;
using Lab7.Model;

namespace Lab7.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            CultureInfo ci = new CultureInfo(Configuration.Instance.Culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            InitializeComponent();
        }
    }
}
