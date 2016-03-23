using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Model
{
    [Serializable]
    public class Playlist : ICollection<Song>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        #region Constructors
        public Playlist(string name)
        {
            this.name = name;
            collection = new ObservableCollection<Song>();
            SetID();
        }
        #endregion

        #region Fields
        private ObservableCollection<Song> collection;
        private TimeSpan duration;
        private uint id;
        private double rating;
        private string name;
        private int ratedElements;

        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        [field: NonSerialized()]
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion

        #region Properties

        public Song this[int i]
        {
            get
            {
                return collection[i];
            }
        }

        public int Count
        {
            get
            {
                return collection.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return duration;
            }
        }

        public uint Id
        {
            get
            {
                return id;
            }
        }

        public double Rating
        {
            get
            {
                return rating;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
                RaisePropertyChanged("name");
            }
        }
        #endregion

        #region Methods
        public void Add(Song item)
        {
            collection.Add(item);
            duration += item.Duration;

            if (item.Rating != 0) {
                rating = (Rating * ratedElements + item.Rating) / (ratedElements + 1);
                ratedElements++;
            }

            RaisePropertyChanged("Duration");
            RaisePropertyChanged("Rating");
            RaiseCollectionChanged(NotifyCollectionChangedAction.Add, item);
        }

        public void Clear()
        {
            collection.Clear();
            RaisePropertyChanged("Duration");
            RaisePropertyChanged("Rating");
        }

        public bool Contains(Song item)
        {
            return collection.Contains(item);
        }

        public void CopyTo(Song[] array, int arrayIndex)
        {
            collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Song> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        public bool Remove(Song item)
        {
            bool isRemoved = collection.Remove(item);
            if (isRemoved) {
                RaisePropertyChanged("Duration");
                RaisePropertyChanged("Rating");
            }
            return isRemoved;
        }

        public int GetIndexOf(Song s)
        {
            for (int i = 0; i < collection.Count; i++) {
                if (collection[i] == s) {
                    return i;
                }
            }
            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        public void UpdateInfo()
        {
            duration = new TimeSpan(0);
            rating = 0;
            foreach(Song s in collection) {
                duration += s.Duration;
                rating += s.Rating;
            }
            rating = rating / Count;
            RaisePropertyChanged("Rating");
            RaisePropertyChanged("Duration");
        }

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void RaiseCollectionChanged(NotifyCollectionChangedAction action, object obj)
        {
            if (CollectionChanged != null && PropertyChanged != null) {
                if (action == NotifyCollectionChangedAction.Reset) {
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(action));
                    PropertyChanged(this, new PropertyChangedEventArgs("FullCost"));

                } else {
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, obj));
                    PropertyChanged(this, new PropertyChangedEventArgs("FullCost"));
                }
            }
        }

        private void SetID()
        {
            id = HashCodeGenerator.GetHash(name);
        }

        #endregion
    }
}
