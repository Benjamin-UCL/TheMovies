using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TheMovies.Model;
using TheMovies.Utility;

namespace TheMovies.Data
{
    public class CsvCinemaRepository : ICinemaRepository
    {
        private readonly string _file;
        public CsvCinemaRepository(string filePath)
        {
            _file = filePath;
            FileHelper.EnsureFile(_file);
        }
        public List<Cinema> GetAll()
        {
            List<Cinema> cinemas = new List<Cinema>();

            using (StreamReader sr = new StreamReader(this._file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        cinemas.Add(Cinema.FromString(line));
                    }
                }
            }
            return cinemas;
        }

        public void SaveAll(List<Cinema> list)
        {
            using var sw = new StreamWriter(_file, append: false);
            foreach (var cinema in list)
            {
                sw.WriteLine(cinema.ToString());
            }
        }
    }
}
