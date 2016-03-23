using Lab7.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab7.ViewModel.Commands
{
    class TotalControlCommand : ICommand
    {
        private IPlayer player;

        public TotalControlCommand()
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
            if (player.IsPlaying) {
                player.Pause(null);
            } else {
                player.Play(null);
            }
        }
    }
}
