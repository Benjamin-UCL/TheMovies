using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheMovies.ViewModel;
using System.IO;
using TheMovies.Data;
//using System.IO.Path;

namespace TheMovies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Movie_ViewModel();

            //var dataDir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data");
            //var genresCsv = Path.Combine(dataDir, "genres.csv");
            //var moviesCsv = Path.Combine(dataDir, "movies.csv");

            //var genreRepo = new CsvGenreRepository(genresCsv);
            //var movieRepo = new CsvMovieRepository(moviesCsv);

        }

        private void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as Movie_ViewModel;
            NewFilm newFilmWindow = new NewFilm();
            newFilmWindow.DataContext = vm;
            newFilmWindow.Show();
        }
    }
}

