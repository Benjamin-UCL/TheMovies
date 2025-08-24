using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TheMovies.Model;
using TheMovies.Utility;

namespace TheMovies.Data;

public class CsvGenreRepository : IGenreRepository
{
    private readonly string _file;
    public CsvGenreRepository(string filePath)
    {
        _file = filePath;
        FileHelper.EnsureFile(_file);
    }

    public List<Genre> GetAll()
    {
        List<Genre> genres = new List<Genre>();
        using (StreamReader sr = new StreamReader(_file))
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

    public void SaveAll(List<Genre> list)
    {
        using (StreamWriter sw = new StreamWriter(_file))
        {
            foreach (var Genre in list)
            {
                sw.WriteLine(Genre.ToString());
            }
        }
    }
}
