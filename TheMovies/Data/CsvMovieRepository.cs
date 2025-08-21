using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TheMovies.Model;

namespace TheMovies.Data
{
    public class CsvMovieRepository : IMovieRepository
    {
        private readonly string _file;
        public CsvMovieRepository(string filePath)
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
                File.WriteAllText(_file, "Title,DurationMin,Genres\n");
        }

        public IEnumerable<Movie> GetAll()
        {
            foreach (var line in File.ReadAllLines(_file).Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',', 3);
                var title = parts.ElementAtOrDefault(0) ?? "";
                int.TryParse(parts.ElementAtOrDefault(1), out var mins);
                var genres = (parts.ElementAtOrDefault(2) ?? "")
                    .Split(';', System.StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => new Genre(s.Trim()));
                yield return new Movie(title, mins, genres);
            }
        }

        public void Add(Movie movie)
        {
            var genresJoined = string.Join(';', movie.Genres.Select(g => g.Name));
            using var sw = new StreamWriter(_file, append: true);
            sw.WriteLine($"{Escape(movie.Title)},{movie.DurationMin},{Escape(genresJoined)}");
        }

        static string Escape(string s)
        {
            if (s is null) return "\"\"";
            var e = s.Replace("\"", "\"\"");
            return $"\"{e}\"";
        }
    }
}
