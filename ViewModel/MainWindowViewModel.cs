using System.Collections.Generic;
using System.Windows.Input;
using Lab7.Model;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;

namespace Lab7.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            SetCurrentPlaylist(0);
            PlayerManager.Instance.Player.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                RaisePropertyChanged("IsPlaying");
            };

            Configuration.Instance.ConfigChanged += (bool needRestart) =>
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                using (Stream stream = new FileStream("Player.conf", FileMode.Create)) {
                    binFormatter.Serialize(stream, Configuration.Instance);
                }

                if (needRestart) {
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
                return;
            };
        }

        #region Properties
        public Playlist CurrentPlaylist
        {
            get
            {
                return PlaylistManager.Instance.CurrentPlaylist;
            }
            set
            {
                PlaylistManager.Instance.CurrentPlaylist = value;
                RaisePropertyChanged("CurrentPlaylist");
            }
        }
        public IEnumerable<Playlist> Playlists
        {
            get
            {
                return PlaylistManager.Instance.Playlists;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return PlayerManager.Instance.Player.IsPlaying;
            }
        }
        #endregion

        #region Commands
        public ICommand TotalControlCommand { get; set; } = new Commands.TotalControlCommand();
        public ICommand StopCommand { get; set; } = new Commands.StopCommand();
        public ICommand ItemControlCommand { get; set; } = new Commands.ItemControlCommand();
        public ICommand AddPlaylistCommand { get; set; } = new Commands.AddPlaylistCommand();
        public ICommand AddSongsCommand { get; set; } = new Commands.AddSongsCommand();
        public ICommand SavePlaylistCommand { get; set; } = new Commands.SavePlaylistCommand();
        public ICommand OpenPlaylistCommand { get; set; } = new Commands.OpenPlaylistCommand();
        public ICommand LstSongsMouseUpCommand { get; set; } = new Commands.LstSongsMouseUpCommand();
        public ICommand RenamePlaylistCommand { get; set; } = new Commands.RenamePlaylistCommand();
        public ICommand OpenSettingsCommand { get; set; } = new Commands.OpenSettingsCommand();
        public ICommand PlayNextCommand { get; set; } = new Commands.PlayNextCommand();
        public ICommand PlayPrevCommand { get; set; } = new Commands.PlayPrevCommand();

        public StringsViewModel StringsViewModel { get; set; } = StringsViewModel.Instance;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public void SetCurrentPlaylist(int index)
        {
            CurrentPlaylist = PlaylistManager.Instance.Playlists[index];
        }

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion

    }
}
