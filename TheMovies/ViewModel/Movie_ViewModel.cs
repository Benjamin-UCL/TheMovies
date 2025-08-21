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
    // Alle film
    public ObservableCollection<Movie> Movies { get; } = new ObservableCollection<Movie>();
    // Sorterede film
    public ObservableCollection<Movie> moviesSorted;
    public ObservableCollection<Genre> Genres { get; } = new ObservableCollection<Genre>();





    public ICommand addMovieCommand { get; }

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
        // dummy data end 
        // Initialize the collections via a method
        // genres and movies
    }

    // COMMANDS
    // Command addfilm
    private void addMovie() 
    {
        Console.WriteLine("Add movie command executed.");
    }

    // command canaddfilm
    private bool canAddMovie() { Console.WriteLine("Can add movie command attempted."); return true; }

}


// første udkast
// Mangler et fetch from database hook - skal både ske når siden loades, og når der er tilføjet eller redigeret film.