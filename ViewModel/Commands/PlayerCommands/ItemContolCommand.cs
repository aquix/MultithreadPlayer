using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab7.Model;

namespace Lab7.ViewModel.Commands
{
    public class ItemControlCommand : ICommand
    {
        private IPlayer player;

        public ItemControlCommand()
        {
            player = PlayerManager.Instance.Player;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Song s = parameter as Song;
            if (s == null) {
                return;
            }
            if (s.IsPlaying) {
                player.Pause(s);
                s.IsPlaying = false;
            } else {
                player.Play(s);
                s.IsPlaying = true;
            }
        }
    }
}
