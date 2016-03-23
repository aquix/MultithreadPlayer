using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Model
{
    public interface IPlayer : INotifyPropertyChanged
    {
        bool IsPlaying { get; set; }
        void Play(Song s);
        void Stop();
        void Pause(Song s);
        void Next();
        void Prev();
    }
}
