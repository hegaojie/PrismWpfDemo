using System.Collections.Generic;
using System.Threading.Tasks;
using PrismWpfDemo.Domain;

namespace PrismWpfDemo.Business.Interfaces
{
    public interface IMovieService
    {
        void SaveMovie(Movie movie);

        IEnumerable<Movie> LoadMovies();

        Task<IEnumerable<Movie>> LoadMoviesAsync();
    }
}
