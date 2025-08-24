using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.Data;

public interface IMovieRepository
{
    List<Movie> GetAll();
    void SaveAll(List<Movie> list);
}
