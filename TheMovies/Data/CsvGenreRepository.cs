using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TheMovies.Model;

namespace TheMovies.Data
{
    public class CsvGenreRepository : IGenreRepository
    {
        private readonly string _file;
        public CsvGenreRepository(string filePath)
        {
            _file = filePath;
            EnsureFile();
        }

        void EnsureFile()
        {
            var dir = Path.GetDirectoryName(_file);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (!File.Exists(_file))
                File.WriteAllText(_file, "Name\n");
        }

        public IEnumerable<Genre> GetAll() =>
            File.ReadAllLines(_file).Skip(1).Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => new Genre(l.Trim()));

        public void Add(Genre genre)
        {
            using var sw = new StreamWriter(_file, append: true);
            sw.WriteLine(genre.Name);
        }
    }
}
