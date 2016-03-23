using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab7.Model;

namespace Lab7.ViewModel.Commands
{
    class StopCommand : ICommand
    {
        private IPlayer player;
        public event EventHandler CanExecuteChanged;

        public StopCommand()
        {
            player = PlayerManager.Instance.Player;
            player.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
            {
                CanExecuteChanged(sender, e);
            };
        }

        public bool CanExecute(object parameter)
        {
            if (player.IsPlaying) {
                return true;
            } else {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            player.Stop();
        }
    }
}
