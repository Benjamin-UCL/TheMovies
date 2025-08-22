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
    public CsvDataHandler Db = new CsvDataHandler("Movies.csv", "Genres.csv");
    public ObservableCollection<Movie> Movies { get; } = new ObservableCollection<Movie>();
    public ObservableCollection<Genre> Genres { get; } = new ObservableCollection<Genre>();

    // Variabler til oprettelse af ny film.
    private string _newTitle;
    public string newTitle { get => _newTitle; set { _newTitle = value; OnPropertyChanged(); }}
    private int _newDuration;
    public int newDuration { get => _newDuration; set { _newDuration = value; OnPropertyChanged(); } }
    public ObservableCollection<Genre> SelectedGenres = new ObservableCollection<Genre>();

    // Variable til oprettelse af ny genre
    private string _newGenreName;
    public string newGenreName { get => _newGenreName; set { _newGenreName = value; OnPropertyChanged(); } }
    //end

    // Constructor
    public Movie_ViewModel() 
    {
        
        addMovieCommand = new RelayCommand(addMovie, canAddMovie);
        addGenreCommand = new RelayCommand(addGenre, canAddGenre);
        Db.FetchAllGenres().ForEach(g => Genres.Add(g));
        Db.FetchAllMovies().ForEach(m => Movies.Add(m));
    }

    // COMMANDS
    public ICommand addMovieCommand { get; }
    private void addMovie() 
    {
        Movie newMovie = new Movie(this.newTitle, this.newDuration);
        // mangler tilføjelse af genre
        Movies.Add(newMovie);
        this.newTitle = "";
        this.newDuration = 0;
        Db.WrtieMoviesToFile(Movies.ToList());
    }
    private bool canAddMovie()
    {
        if (string.IsNullOrWhiteSpace(this.newTitle) || this.newDuration <= 0)
        {
            return false;
        }
        return true;
    }

    public ICommand addGenreCommand { get; }
    private void addGenre() 
    {
        Genre newGenre = new Genre(this.newGenreName);
        Genres.Add(newGenre);
        this.newGenreName = "";
        Db.WrtieGenresToFile(Genres.ToList());
        // alternativt can vi lukkker vinduet her
    }
    private bool canAddGenre()
    {
        if (string.IsNullOrWhiteSpace(this.newGenreName))
        {
            return false;
        }
        return true;
    }
}
