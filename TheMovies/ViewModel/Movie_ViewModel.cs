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

namespace TheMovies.ViewModel;

public class Movie_ViewModel: INotifyPropertyChanged
{
    // Alle film
    ObservableCollection<Movie> movies;
    // Sorterede film
    ObservableCollection<Movie> moviesSorted;

    // midlertidig dummy data til udvikling (scarfolding)
    movies.Add(new Movie("The Shining", 123)); 
    movies.Add(new Movie("Brokeback Mountain", 264)); 
    movies.Add(new Movie("Snehvide", 93)); 


    public ICommand addMovieCommand { get; }

    // Constructor
    public Movie_ViewModel() 
    {
        addMovieCommand = new RelayCommand(addMovie, canAddMovie);

        // Initialize the collections via a method
    }

    // COMMANDS
    // Command addfilm
    private void addMovie() 
    {
        Console.WriteLine("Add movie command executed.");
    }

    // command canaddfilm
    private bool canAddMovie() { Console.WriteLine("Can sdd movie command attempted."); return true; }

    // 2-way data binding (WPF Observer pattern) - kopiert fra skole eksemple
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}


// første udkast
// Mangler et fetch from database hook - skal både ske når siden loades, og når der er tilføjet eller redigeret film.