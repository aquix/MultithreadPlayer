using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Lab7.Model
{
    class PlaylistManager : INotifyCollectionChanged
    {

        #region Constructors
        private PlaylistManager()
        {
            playlists = new ObservableCollection<Playlist>();
            playlists.Add(new Playlist("Default"));
        }
        #endregion

        #region Fields

        private static PlaylistManager playlistManager;

        private ObservableCollection<Playlist> playlists;

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion

        #region Properties
        public static PlaylistManager Instance
        {
            get
            {
                if (playlistManager == null) {
                    playlistManager = new PlaylistManager();
                }
                return playlistManager;
            }
        }

        public ObservableCollection<Playlist> Playlists
        {
            get
            {
                return playlists;
            }

            set
            {
                this.playlists = value;
            }
        }

        public Playlist CurrentPlaylist { get; set; }
        #endregion

        #region Methods
        public void RaiseCollectionChanged(NotifyCollectionChangedAction action)
        {
            if (CollectionChanged != null) {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action));
            }
        }

        public static void Save(Playlist p, string path)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path, FileMode.OpenOrCreate)) {
                binFormatter.Serialize(stream, p);
            }
        }

        public static Playlist Load(string path)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path, FileMode.Open)) {
                Playlist p = (Playlist)binFormatter.Deserialize(stream);
                return p;
            }
        }
        #endregion
    }
}
