using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TheMovies.Model;

public class Movie
{
    public string Title { get; set; }
    public int DurationMin { get; set; }
    
    // Muligheden for at have flere genrer til én film 
    public List<Genre> Genres { get; set; }

    //Constructor
    public Movie(string title, int durationMin, List<Genre> genre = null)
    {
        Title = title;
        DurationMin = durationMin;
        Genres = new List<Genre>();
    }

    public string GenreList => string.Join(", ", Genres.Select(g => g.Name));

    // Hjælpe-metode til at vise genrer som tekst
    public string GenreAsText => string.Join(", ", Genres);

    // duration to time
    //public string DurationInHoursAndMinutes()
    //{
    //    int hours = DurationMin / 60;
    //    int minutes = DurationMin % 60;
    //    return $"{hours}:{minutes}";
    //}

    private int DurationHours;
    private string DurationMinutes()
    {
        string result = "123";
        int minutes = DurationMin % 60;
        result = minutes.ToString();
        if (minutes < 10)
        {
            result = minutes.ToString("D2");
        }
        return result;
    }

    public string DurationInHoursandMinutes => $"{DurationMin / 60}:{DurationMin % 60}";
}
