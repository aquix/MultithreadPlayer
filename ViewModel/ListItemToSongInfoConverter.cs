using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Lab7.Model;

namespace Lab7.ViewModel
{
    class ListItemToSongInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Song s = value as Song;
            if (s == null) {
                return null;
            }
            return $"{Resources.Strings.SONG_TITLE}: {s.Title}\n{Resources.Strings.SONG_AUTHOR}: {s.Author}\n" +
                $"{Resources.Strings.SONG_ALBUM}: {s.Album}\n{Resources.Strings.SONG_YEAR}: {s.Year}\n" +
                $"{Resources.Strings.SONG_RATING}: {s.Rating}\n{Resources.Strings.SONG_GENRE}: {s.Genre}\n" +
                $"{Resources.Strings.SONG_PATH}: {s.Path}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
