using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.Data;

public interface IMovieRepository
{
    IEnumerable<Movie> GetAll();
    void Add(Movie movie);
}
