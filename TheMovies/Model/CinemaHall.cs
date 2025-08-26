using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class CinemaHall
    {
        public string Number { get; set; }

        public int Capacity { get; set; }

        public CinemaHall(string number, int capacity)
        {
            Number = number;
            Capacity = capacity;
        }
        public override string ToString()
        {
            return $"{Number},{Capacity}";
        }

        public static CinemaHall FromString(string data)
        {
            string[] parts = data.Split(',');
            return new CinemaHall(parts[0], int.Parse(parts[1]));
        }
    }
}
