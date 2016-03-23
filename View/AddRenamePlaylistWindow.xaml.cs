using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab7.Model;

namespace Lab7.View
{
    /// <summary>
    /// Логика взаимодействия для AddRenamePlaylistWindow.xaml
    /// </summary>
    public partial class AddRenamePlaylistWindow : Window
    {
        private Playlist playlist;

        public AddRenamePlaylistWindow(Playlist playlist, string windowTitle)
        {
            InitializeComponent();
            this.playlist = playlist;
            this.Title = windowTitle;
            btnAdd.Content = windowTitle;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            playlist.Name = txtName.Text;
            this.Close();
        }
    }
}
