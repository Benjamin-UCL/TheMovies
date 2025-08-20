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

namespace TheMovies
{
    /// <summary>
    /// Interaction logic for NewFilm.xaml
    /// </summary>
    public partial class NewFilm : Window
    {
        public NewFilm()
        {
            InitializeComponent();
            

            // persist new movie with genres to db

        }

        private void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            NewGenre newGenreWindow = new NewGenre();

            newGenreWindow.Show();
        }
    }
}
