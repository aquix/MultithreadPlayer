using Lab7.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab7.ViewModel.Commands
{
    class OpenSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ConfigWindow window = new ConfigWindow();
            window.ShowDialog();
        }
    }
}
