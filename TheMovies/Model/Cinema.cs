using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Cinema
    {
        public string Name { get; set; }
        
        public string Location { get; set; }

        public List<CinemaHall> CinemaHalls { get; set; }

        public List<Screening> Screenings { get; set; }

        public Cinema(string name, string location, List<CinemaHall> cinemaHall = null, List<Screening> screening = null)
        {
            Name = name;
            Location = location;
            CinemaHalls = cinemaHall;
            Screenings = screening;
        }
        public override string ToString()
        {
            return $"{Name},{Location}";
        }

        public static Cinema FromString(string data)
        {
            string[] parts = data.Split(',');
            return new Cinema(parts[0], parts[1]);
        }
    }
}
