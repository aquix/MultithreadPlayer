using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab7.Model;
using System.Windows.Controls;

namespace Lab7.ViewModel.Commands
{
    class RenamePlaylistCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Playlist playlist = (parameter as Playlist);
            View.AddRenamePlaylistWindow addWindow = new View.AddRenamePlaylistWindow(playlist, Resources.Strings.RENAME_PLAYLIST_WINDOW);
            addWindow.Show();
        }
    }
}
