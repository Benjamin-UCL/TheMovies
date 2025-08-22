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
    public ObservableCollection<Movie> Movies { get; } = new ObservableCollection<Movie>();
    public ObservableCollection<Genre> Genres { get; } = new ObservableCollection<Genre>();


    // Variabler til oprettelse af ny film.
    private string _newTitle;
    public string newTitle { get => _newTitle; set { _newTitle = value; OnPropertyChanged(); }}
    private int _newDuration;
    public int newDuration { get => _newDuration; set { _newDuration = value; OnPropertyChanged(); } }
    public ObservableCollection<Genre> SelectedGenres = new ObservableCollection<Genre>();
    // end



    // Constructor
    public Movie_ViewModel() 
    {
        addMovieCommand = new RelayCommand(addMovie, canAddMovie);

        // midlertidig dummy data til udvikling (scarfolding)
        Movies.Add(new Movie("The Shining", 123));
        Movies.Add(new Movie("Brokeback Mountain", 210));
        Movies.Add(new Movie("Snehvide", 93));
        Genres.Add(new Genre("Drama"));
        Genres.Add(new Genre("Thriller"));
        Genres.Add(new Genre("Comedy"));
        Genres.Add(new Genre("Horror"));
        Genres.Add(new Genre("Romance"));
        Genres.Add(new Genre("Animation"));
        Movies[0].Genres.Add(this.Genres[0]);
        Movies[0].Genres.Add(this.Genres[2]);
        Movies[0].Genres.Add(this.Genres[5]);
        Movies[1].Genres.Add(this.Genres[1]);
        Movies[1].Genres.Add(this.Genres[2]);
        Movies[2].Genres.Add(this.Genres[3]);
        Movies[2].Genres.Add(this.Genres[4]);
        // dummy data end 

        // Initialize the collections via a method
        // genres and movies
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
    }
    private bool canAddMovie()
    {
        if (string.IsNullOrWhiteSpace(this.newTitle) || this.newDuration <= 0)
        {
            return false;
        }
        return true;
    }
}


// første udkast
// Mangler et fetch from database hook - skal både ske når siden loades, og når der er tilføjet eller redigeret film.