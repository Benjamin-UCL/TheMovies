using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;
using TheMovies.Utility;

namespace TheMovies.Data;

public class CsvMovieGenreRepository : IMovieGenreRepository
{
    private readonly string _file;
    public CsvMovieGenreRepository(string filePath)
    {
        _file = filePath;
        FileHelper.EnsureFile(_file);
    }

    public List<(string MovieTitle, string GenreName)> GetAll()
    {
        List<(string MovieTitle, string GenreName)> connections = new();

        using (StreamReader sr = new StreamReader(this._file))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var parts = line.Split(',');
                    connections.Add((parts[0], parts[1]));
                }
            }
        }
        return connections;
    }

    public void SaveAll(List<Movie> list)
    {
        using var sw = new StreamWriter(_file, append: false);
        foreach (var movie in list)
        {
            foreach (var genre in movie.Genres)
            {
                sw.WriteLine($"{movie.Title},{genre.Name}");
            }
        }
    }
}
