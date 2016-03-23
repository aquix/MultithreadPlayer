using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7.Resources;

namespace Lab7.ViewModel
{
    public class StringsViewModel : INotifyPropertyChanged
    {
        private static StringsViewModel stringsViewModel;

        private StringsViewModel() { }

        public static StringsViewModel Instance
        {
            get
            {
                if (stringsViewModel == null) {
                    stringsViewModel = new StringsViewModel();
                }
                return stringsViewModel;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SubmitCultureChanged()
        {
            Type typeStringsViewModel = typeof(StringsViewModel);
            var properties = typeStringsViewModel.GetProperties();
            foreach (var prop in properties) {
                RaisePropertyChanged(prop.Name);
            }
        }

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string ADD_PLAYLIST
        {
            get
            {
                return Strings.ADD_PLAYLIST;
            }
        }

        public string CONFIG_LANG
        {
            get
            {
                return Strings.CONFIG_LANG;
            }
        }

        public string CONFIG_MODE
        {
            get
            {
                return Strings.CONFIG_MODE;
            }
        }

        public string CONFIG_SAVE
        {
            get
            {
                return Strings.CONFIG_SAVE;
            }
        }

        public string NEW_PLAYLIST_NAME
        {
            get
            {
                return Strings.NEW_PLAYLIST_NAME;
            }
        }

        public string OPEN_PLAYLIST
        {
            get
            {
                return Strings.OPEN_PLAYLIST;
            }
        }

        public string PLAYLIST_DURATION
        {
            get
            {
                return Strings.PLAYLIST_DURATION;
            }
        }

        public string RENAME_PLAYLIST_WINDOW
        {
            get
            {
                return Strings.RENAME_PLAYLIST_WINDOW;
            }
        }

        public string SAVE_PLAYLIST
        {
            get
            {
                return Strings.SAVE_PLAYLIST;
            }
        }

        public string SONG_ALBUM
        {
            get
            {
                return Strings.SONG_ALBUM;
            }
        }

        public string SONG_AUTHOR
        {
            get
            {
                return Strings.SONG_AUTHOR;
            }
        }

        public string SONG_GENRE
        {
            get
            {
                return Strings.SONG_GENRE;
            }
        }

        public string SONG_PATH
        {
            get
            {
                return Strings.SONG_PATH;
            }
        }

        public string SONG_RATING
        {
            get
            {
                return Strings.SONG_RATING;
            }
        }

        public string SONG_TITLE
        {
            get
            {
                return Strings.SONG_TITLE;
            }
        }

        public string SONG_YEAR
        {
            get
            {
                return Strings.SONG_YEAR;
            }
        }

    }
}
