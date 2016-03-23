using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;
using Lab7.Model;

namespace Lab7.ViewModel.Commands
{
    class SavePlaylistCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Paylists | *.play";
            if (dialog.ShowDialog() == true) {
                PlaylistManager.Save((parameter as MainWindowViewModel).CurrentPlaylist, dialog.FileName);
            }
        }
    }
}
