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
    public string Director { get; set; }
    public int DurationMin { get; set; }
    public List<Genre> Genres { get; set; }

    public Movie(string title, string director, int durationMin, List<Genre> genre = null)
    {
        this.Title = title;
        this.Director = director;
        this.DurationMin = durationMin;
        this.Genres = new List<Genre>();
    }

    public string GenreList => string.Join(", ", Genres.Select(g => g.Name));

    private string DurationMinutes()
    {
        string result = "123";
        int minutes = this.DurationMin % 60;
        result = minutes.ToString();
        if (minutes < 10)
        {
            result = minutes.ToString("D2");
        }
        return result;
    }

    public string DurationInHoursandMinutes => $"{DurationMin / 60}:{DurationMinutes()}";

    public override string ToString()
    {
        return $"{Title},{Director},{DurationMin}";
    }

    public static Movie FromString(string data)
    {
        string[] parts = data.Split(',');
        return new Movie(parts[0], parts[1], int.Parse(parts[2]));
    }
}
