using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab7.Model
{
    class MultithreadPlayer : IDisposable, IPlayer
    {
        #region Fields
        private ObservableCollection<MultithreadSong> nowPlayingSongs;

        private bool repeat;

        public event PropertyChangedEventHandler PropertyChanged;

        //public static MultithreadPlayer player;
        #endregion

        #region Properties
        public bool IsPlaying { get; set; } = false;
        public bool IsRepeating
        {
            get
            {
                return repeat;
            }
            set
            {
                repeat = value;
            }
        }

        #endregion

        #region Constructors
        public MultithreadPlayer()
        {
            nowPlayingSongs = new ObservableCollection<MultithreadSong>();
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
            if (s != null) {
                if (nowPlayingSongs != null) {
                    foreach (var song in nowPlayingSongs) {
                        if (song.Song.Path == s.Path) {
                            song.Play();
                            IsPlaying = true;
                            RaisePropertyChanged("IsPlaying");
                            return;
                        }
                    }
                }
                nowPlayingSongs.Add(new MultithreadSong(s));
            } else {
                foreach (var song in nowPlayingSongs) {
                        song.Play();
                        IsPlaying = true;
                        RaisePropertyChanged("IsPlaying");
                        return;
                }
            }
            IsPlaying = true;
            RaisePropertyChanged("IsPlaying");
        }

        public void Stop()
        {
            List<MultithreadSong> forRemoving = new List<MultithreadSong>();
            for (int i = 0; i < nowPlayingSongs.Count; i++) {
                nowPlayingSongs[i].Stop();
                //nowPlayingSongs[i].Thread.Abort();
                nowPlayingSongs[i].Song.IsPlaying = false;
                forRemoving.Add(nowPlayingSongs[i]);
            }

            foreach (var item in forRemoving) {
                nowPlayingSongs.Remove(item);
            }

            IsPlaying = false;
            RaisePropertyChanged("IsPlaying");
        }

        public void Pause(Song s)
        {
            if (s != null) {
                foreach (var song in nowPlayingSongs) {
                    if (song.Song.Path == s.Path) {
                        song.Pause();
                        return;
                    }
                }
            } else {
                foreach (var song in nowPlayingSongs) {
                   song.Pause();
                }
            }
        }

        public void Dispose()
        {
            foreach (var song in nowPlayingSongs) {
                song.Thread.Abort();
            }
        }

        public void Next()
        {
            return;
        }

        public void Prev()
        {
            return;
        }
        #endregion
    }
}
