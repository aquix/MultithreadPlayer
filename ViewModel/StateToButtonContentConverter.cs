using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Lab7.ViewModel
{
    class StateToButtonContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool) {
                bool val = (bool)value;
                BitmapImage img = new BitmapImage();
                if (val) {
                    return new Uri(@"/Resources/Images/pause.png", UriKind.Relative);
                } else {
                    return new Uri(@"/Resources/Images/play.png", UriKind.Relative);
                }
            } else {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
