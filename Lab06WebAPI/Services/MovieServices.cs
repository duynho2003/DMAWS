using Lab06Lib;
using Lab06WebAPI.Repository;

namespace Lab06WebAPI.Services
{
    public class MovieServices : IMovieRepository
    {
        public Task<Movie> createMovie(Movie newMovie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> deleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> findAll()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> findOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> updateMovie(Movie editMovie)
        {
            throw new NotImplementedException();
        }
    }
}
