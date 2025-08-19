using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model;

public class Genre
{
    public string Name { get; set; }

    //Constructor
    public Genre(string name)
    {
        Name = name;
    }
    public override string ToString() => Name;
}
