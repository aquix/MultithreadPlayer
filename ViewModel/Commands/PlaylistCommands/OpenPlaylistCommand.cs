using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab7.Model;

namespace Lab7.ViewModel.Commands
{
    class OpenPlaylistCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Playlists|*.play";
            if (dialog.ShowDialog() == true) {
                Playlist p = PlaylistManager.Load(dialog.FileName);
                PlaylistManager.Instance.Playlists.Add(p);
            }
        }
    }
}
