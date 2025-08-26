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
    public class CsvScreeningRepository : IScreeningRepository
    {
        private readonly string _file;
        public CsvScreeningRepository(string filePath)
        {
            _file = filePath;
            FileHelper.EnsureFile(_file);
        }
        public List<Screening> GetAll()
        {
            List<Screening> screenings = new List<Screening>();

            using (StreamReader sr = new StreamReader(this._file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        screenings.Add(Screening.FromString(line));
                    }
                }
            }
            return screenings;
        }

        public void SaveAll(List<Screening> list)
        {
            using var sw = new StreamWriter(_file, append: false);
            foreach (var screening in list)
            {
                sw.WriteLine(screening.ToString());
            }
        }
    }
}
