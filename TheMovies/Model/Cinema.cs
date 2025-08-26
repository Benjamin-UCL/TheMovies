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

        public Cinema(string name, string location)
        {
            Name = name;
            Location = location;
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
