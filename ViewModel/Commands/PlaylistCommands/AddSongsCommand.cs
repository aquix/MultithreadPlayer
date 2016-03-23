using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab7.ViewModel.Commands
{
    class AddSongsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Музыка mp3 | *.mp3";
            openDlg.Multiselect = true;
            if (openDlg.ShowDialog() == true) {
                foreach(var file in openDlg.FileNames) {
                    (parameter as MainWindowViewModel).CurrentPlaylist.Add(new Model.Song(TagLib.File.Create(file)));
                }
            }


        }
    }
}
