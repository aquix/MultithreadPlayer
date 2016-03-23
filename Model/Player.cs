using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Media;

namespace Lab7.Model
{
    public class Player : INotifyPropertyChanged, IPlayer
    {
        #region Fields
        private MediaPlayer mplayer;
        private Song song;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public bool IsPlaying { get; set; }
        #endregion

        #region Constructors
        public Player()
        {
            mplayer = new MediaPlayer();
        }
        #endregion

        #region Methods
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void Play(Song s)
        {
            if (s == null && song != null) {
                mplayer.Play();
                song.IsPlaying = true;
                IsPlaying = true;
                RaisePropertyChanged("IsPlaying");
            } else if (s != null) {
                if (song != null) {
                    mplayer.Stop();
                    song.IsPlaying = false;
                }
                song = s;
                mplayer.Open(new Uri(song.Path));
                mplayer.Play();
                song.IsPlaying = true;
                IsPlaying = true;
                RaisePropertyChanged("IsPlaying");
            }
        }

        public void Stop()
        {
            if (song != null) {
                song.IsPlaying = false;
                mplayer.Stop();
                song = null;
            }
            IsPlaying = false;
            RaisePropertyChanged("IsPlaying");
        }

        public void Pause(Song s)
        {
            mplayer.Pause();
            song.IsPlaying = false;
            IsPlaying = false;
            RaisePropertyChanged("IsPlaying");
        }

        public void Next()
        {
            Playlist playlist;
            int currentIndex = FindAndPausePlayingSong(out playlist);

            if (currentIndex == -1) {
                return;
            }

            Pause(playlist[currentIndex]);
            if (currentIndex == playlist.Count - 1) {
                currentIndex = 0;
            } else {
                currentIndex++;
            }

            Play(playlist[currentIndex]);
        }

        public void Prev()
        {
            Playlist playlist;
            int currentIndex = FindAndPausePlayingSong(out playlist);

            if (currentIndex == -1) {
                return;
            }

            Pause(playlist[currentIndex]);
            if (currentIndex == 0) {
                currentIndex = playlist.Count - 1;
            } else {
                currentIndex--;
            }

            Play(playlist[currentIndex]);
        }

        private int FindAndPausePlayingSong(out Playlist playlist)
        {
            int currentIndex = -1;
            playlist = PlaylistManager.Instance.CurrentPlaylist;
            for (int i = 0; i < playlist.Count; i++) {
                if (playlist[i].IsPlaying) {
                    currentIndex = i;
                    break;
                }
            }
            return currentIndex;
        }
        #endregion
    }
}
