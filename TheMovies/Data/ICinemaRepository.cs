using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.Data
{
    public interface ICinemaRepository
    {
        List<Cinema> GetAll();
        void SaveAll(List<Cinema> list);
    }
}
