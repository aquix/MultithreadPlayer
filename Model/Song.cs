using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagLib;

namespace Lab7.Model
{
    [Serializable]
    public class Song : INotifyPropertyChanged
    {
        public Song()
        {

        }
        public Song(TagLib.File file)
        {
            title = file.Tag.Title;
            duration = file.Properties.Duration;
            author = file.Tag.FirstPerformer;
            year = file.Tag.Year;
            album = file.Tag.Album;
            path = file.Name;
            genre = file.Tag.FirstGenre;

            Tag tag123 = file.GetTag(TagTypes.Id3v2);
            var usr = "Windows Media Player 9 Series";
            TagLib.Id3v2.PopularimeterFrame frame = TagLib.Id3v2.PopularimeterFrame.Get(
                                                     (TagLib.Id3v2.Tag)tag123, usr, true);
            rating = frame.Rating / (uint)48; // frame.Rating is 0..255. Make it 0..5

            SetID();
        }

        #region Fields
        private string title;
        private TimeSpan duration;
        private string author;
        private uint year;
        private string album;
        private uint id;
        private string path;
        private string genre;
        private uint rating;
        private bool isPlaying;

        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public string Title
        {
            get
            {
                if (title != null) {
                    return title;
                } else {
                    FileInfo info = new FileInfo(path);
                    return info.Name;
                }
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return duration;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
        }

        public uint Year
        {
            get
            {
                return year;
            }
        }

        public string Album
        {
            get
            {
                return album;
            }
        }

        public uint Id
        {
            get
            {
                return id;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }
        }

        public uint Rating
        {
            get
            {
                return rating;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }

            set
            {
                this.isPlaying = value;
                RaisePropertyChanged("isPlaying");
            }
        }
        #endregion

        #region Methods
        private void SetID()
        {
            id = HashCodeGenerator.GetHash(path);
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
