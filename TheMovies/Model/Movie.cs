using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model;

public class Movie
{
    public string Title { get; set; }
    public int DurationMin { get; set; }
    
    // Muligheden for at have flere genrer til én film 
    public List<Genre> Genres { get; set; }

    //Constructor
    public Movie(string title, int durationMin, Genre genre)
    {
        Title = title;
        DurationMin = durationMin;
        Genre = genre;
    }

    // Hjælpe-metode til at vise genrer som tekst
    public string GenreAsText => string.Join(", ", Genres);
}
