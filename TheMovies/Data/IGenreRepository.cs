using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;
using System.Collections.Generic;

namespace TheMovies.Data;


public interface IGenreRepository
{
    IEnumerable<Genre> GetAll();
    void Add(Genre genre);
}

