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
    List<Genre> GetAll();
    void SaveAll(List<Genre> list);
}

