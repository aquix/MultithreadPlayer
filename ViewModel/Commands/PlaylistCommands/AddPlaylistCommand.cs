using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab7.Model;
using System.Threading;

namespace Lab7.ViewModel.Commands
{
    class AddPlaylistCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Playlist p = new Playlist(Resources.Strings.NEW_PLAYLIST_NAME);
            View.AddRenamePlaylistWindow addWindow = new View.AddRenamePlaylistWindow(p, Resources.Strings.ADD_PLAYLIST);
            addWindow.ShowDialog();
            PlaylistManager.Instance.Playlists.Add(p);
        }
    }
}
