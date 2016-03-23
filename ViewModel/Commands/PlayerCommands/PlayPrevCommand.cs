using Lab7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab7.ViewModel.Commands
{
    class PlayPrevCommand : ICommand
    {
        private IPlayer player;

        public PlayPrevCommand()
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
            player.Prev();
        }
    }
}
