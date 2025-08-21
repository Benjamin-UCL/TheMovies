using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.Data
using System.Collections.Generic 
{
    public interface IGenreRepository
    {
    IEnumerable<Genre> GetAll();
    void Add(Genre genre);
    }
}
