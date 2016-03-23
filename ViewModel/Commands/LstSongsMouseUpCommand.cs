using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab7.ViewModel.Commands
{
    class LstSongsMouseUpCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ListBoxItem item = parameter as ListBoxItem;
            item.IsSelected = true;
        }
    }
}
