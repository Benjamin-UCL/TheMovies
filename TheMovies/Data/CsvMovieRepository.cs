using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TheMovies.Model;
using TheMovies.Utility;

namespace TheMovies.Data;

public class CsvMovieRepository : IMovieRepository
{
    private readonly string _file;
    public CsvMovieRepository(string filePath)
    {
        _file = filePath;
        FileHelper.EnsureFile(_file);
    }

    public List<Movie> GetAll()
    {
        List<Movie> movies = new List<Movie>();

        using (StreamReader sr = new StreamReader(this._file))
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

    public void SaveAll(List<Movie> list)
    {
        using var sw = new StreamWriter(_file, append: false);
        foreach (var movie in list)
        {
            sw.WriteLine(movie.ToString());
        }
    }
}
