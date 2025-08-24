using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;
using TheMovies.Utility;

namespace TheMovies.Data;

public class CsvDataHandler
{

    public string MovieFilePath { get; }
    public string GenreFilePath { get; }
    public CsvDataHandler(string movieFilePath, string genreFilePath)
    {
        MovieFilePath = movieFilePath;
        GenreFilePath = genreFilePath;
    }

    public void WrtieMoviesToFile(List<Movie> MovieList)
    {
        using (StreamWriter sw = new StreamWriter(MovieFilePath))
        {
            foreach (var Movie in MovieList)
            {
                sw.WriteLine(Movie.ToString());               
            }
        }
    }
    public void WrtieGenresToFile(List<Genre> GenreList)
    {
        using (StreamWriter sw = new StreamWriter(GenreFilePath))
        {
            foreach (var Genre in GenreList)
            {
                sw.WriteLine(Genre.ToString());
            }
        }
    }

    public List<Movie> FetchAllMovies()
    {
        //Forklaring nedunder i FetchAllGenrs()
        FileHelper.EnsureFileExists(MovieFilePath);

        List<Movie> movies = new List<Movie>();

        using (StreamReader sr = new StreamReader(MovieFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    movies.Add(Movie.FromString(line));
                }
            }
        }
        return movies;
    }

    public List<Genre> FetchAllGenres()
    {
    /* Tjek hvis filen eksisterer, ellers oepret den
    if (!File.Exists(GenreFilePath))
    {
        File.Create(GenreFilePath).Close();
    }*/
    // up top replaced with method in Filehelper class in Utility folder, because same method can be (and is) used in FetchAllMovies() as well

        FileHelper.EnsureFileExists(GenreFilePath);

        List<Genre> genres = new List<Genre>();

        using (StreamReader sr = new StreamReader(GenreFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    genres.Add(Genre.FromString(line));
                }
            }
        }
        return genres;
    }

}
