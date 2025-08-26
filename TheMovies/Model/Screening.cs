using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Screening
    {
        public DateTime DateTime { get; set; }

        public DateTime ShowTime { get; set; }

        public int TotalDuration { get; set; }

        public Screening(DateTime dateTime, DateTime showTime, int totalduration)        
        {
            DateTime = dateTime;
            ShowTime = showTime;
            TotalDuration = totalduration;
        }

        public override string ToString()
        {
            return $"{DateTime},{ShowTime},{TotalDuration}";
        }

        public static Screening FromString(string data)
        {
            string[] parts = data.Split(',');
            return new Screening(DateTime.Parse(parts[0]), DateTime.Parse(parts[1]), int.Parse(parts[2]));
        }
        // Metode til at beregne den totale varighed af en film inklusiv reklamer og rengøring
        public int DurationPlusCommercialsAndCleaning(Movie movie)
        {
            // 15 min reklamer og 15 min til rengøring
            TotalDuration = movie.DurationMin + 30;
            return TotalDuration;
        }
    }
}
