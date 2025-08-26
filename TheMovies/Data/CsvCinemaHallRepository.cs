using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;
using TheMovies.Utility;
using static System.Net.WebRequestMethods;

namespace TheMovies.Data
{
    public class CsvCinemaHallRepository : ICinemaHallRepository
    {
        private readonly string _file;
        public CsvCinemaHallRepository(string filePath)
        {
            _file = filePath;
            FileHelper.EnsureFile(_file);
        }
        public List<CinemaHall> GetAll()
        {
            List<CinemaHall> cinemaHalls = new List<CinemaHall>();

            using (StreamReader sr = new StreamReader(this._file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        cinemaHalls.Add(CinemaHall.FromString(line));
                    }
                }
            }
            return cinemaHalls;
        }

        public void SaveAll(List<CinemaHall> list)
        {
            using var sw = new StreamWriter(_file, append: false);
            foreach (var cinemaHall in list)
            {
                sw.WriteLine(cinemaHall.ToString());
            }
        }
    }
}
