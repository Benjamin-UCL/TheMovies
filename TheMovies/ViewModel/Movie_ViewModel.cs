using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheMovies.Model;
using TheMovies.Utility;
using TheMovies.Data;

namespace TheMovies.ViewModel;

public class Movie_ViewModel: ViewModelBase
{
    public CsvGenreRepository GenreRepository = new CsvGenreRepository("Genres.csv");
    public CsvMovieRepository MovieRepository = new CsvMovieRepository("Movies.csv");
    public CsvMovieGenreRepository MovieGenreRepository = new CsvMovieGenreRepository("MovieGenres.csv");


    public ObservableCollection<Movie> Movies { get; } = new ObservableCollection<Movie>();
    public ObservableCollection<Genre> Genres { get; } = new ObservableCollection<Genre>();



    // Variabler til oprettelse af ny film.
    private string _newTitle;
    public string newTitle { get => _newTitle; set { _newTitle = value; OnPropertyChanged(); }}
    private int _newDuration;
    public int newDuration { get => _newDuration; set { _newDuration = value; OnPropertyChanged(); } }
    public ObservableCollection<Genre> SelectedGenres = new ObservableCollection<Genre>();

    private string _newDirector;
    public string newDirector { get => _newDirector; set { _newDirector = value; OnPropertyChanged(); } }

    // Variable til oprettelse af ny genre
    private string _newGenreName;
    public string newGenreName { get => _newGenreName; set { _newGenreName = value; OnPropertyChanged(); } }
    //end

    // Constructor
    public Movie_ViewModel() 
    {
        
        addMovieCommand = new RelayCommand(addMovie, canAddMovie);
        addGenreCommand = new RelayCommand(addGenre, canAddGenre);
        AttachGenreCommand = new RelayCommand(attachGenre, canattachGenre);
        MovieRepository.GetAll().ForEach( m => Movies.Add(m));
        GenreRepository.GetAll().ForEach(g => Genres.Add(g));
        var connnections = MovieGenreRepository.GetAll();
        foreach (var (MovieTitle, GenreName) in connnections)
        {
            var movie = Movies.FirstOrDefault(m => m.Title == MovieTitle);
            var genre = Genres.FirstOrDefault(g => g.Name == GenreName);
            if (movie != null && genre != null)
            {
                movie.Genres.Add(genre);
            }
        }
    }

    // COMMANDS
    public ICommand addMovieCommand { get; }
    private void addMovie(object parameter) 
    {
        Movie newMovie = new Movie(this.newTitle, this.newDirector, this.newDuration);
        foreach (var genre in SelectedGenres)
        {
            newMovie.Genres.Add(genre);
        }
        Movies.Add(newMovie);
        this.newTitle = "";
        this.newDirector = "";
        this.newDuration = 0;
   
        MovieRepository.SaveAll(Movies.ToList());
        MovieGenreRepository.SaveAll(Movies.ToList());
    }
    private bool canAddMovie()
    {
        if (string.IsNullOrWhiteSpace(this.newTitle) || string.IsNullOrWhiteSpace(this.newDirector) || this.newDuration <= 0)
        {
            return false;
        }
        return true;
    }

    public ICommand addGenreCommand { get; }
    private void addGenre(object parameter) 
    {
        Genre newGenre = new Genre(this.newGenreName);
        Genres.Add(newGenre);
        this.newGenreName = "";
        GenreRepository.SaveAll(Genres.ToList());
    }
    private bool canAddGenre()
    {
        if (string.IsNullOrWhiteSpace(this.newGenreName))
        {
            return false;
        }
        return true;
    }

    public ICommand AttachGenreCommand { get; }

    public void attachGenre(object parameter)
    {
        if (parameter is Genre clickedGenre)
        {
            if(SelectedGenres.Contains(clickedGenre)) 
            {
                SelectedGenres.Remove(clickedGenre);
            } 
            
            else 
            {
                SelectedGenres.Add(clickedGenre);
            }
        }
    }

    public bool canattachGenre()
    {
        return true;
    }
}

