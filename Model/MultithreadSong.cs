using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab7.Model
{
    public class MultithreadSong : IDisposable
    {
        AutoResetEvent handler = new AutoResetEvent(false);
        private Song song;
        private Thread thread;
        private bool isStopped;

        public MultithreadSong(Song song)
        {
            this.song = song;
            //this.thread = new Thread(() =>
            //{
            //    MediaPlayer player = new MediaPlayer();
            //    player.Open(new Uri(song.Path));
            //    player.Play();
            //    while (true) {
            //        handler.WaitOne();
            //        if (!song.IsPlaying) {
            //            player.Pause();
            //        } else {
            //            player.Play();
            //        }
            //    }
            //});
            //thread.IsBackground = true;
            //thread.Start();

            ThreadPool.QueueUserWorkItem((object obj) =>
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri(song.Path));
                player.Play();

                while (true) {
                    handler.WaitOne();
                    if (isStopped) {
                        player.Stop();
                        player.Close();
                        continue;
                    }

                    if (!song.IsPlaying) {
                        player.Pause();
                    } else {
                        player.Play();
                    }
                }
            });
        }

        public Song Song
        {
            get
            {
                return song;
            }

            set
            {
                this.song = value;
            }
        }

        public Thread Thread
        {
            get
            {
                return thread;
            }

            set
            {
                this.thread = value;
            }
        }

        public void Pause()
        {
            song.IsPlaying = false;
            handler.Set();
        }

        public void Play()
        {
            song.IsPlaying = true;
            handler.Set();
        }

        public void Stop()
        {
            isStopped = true;
            handler.Set();
        }

        public void Dispose()
        {
            handler.Dispose();
        }
    }
}
