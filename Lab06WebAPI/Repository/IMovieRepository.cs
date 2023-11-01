using Lab06Lib;

namespace Lab06WebAPI.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> findAll();
        Task<Movie> findOne(int id);
        Task<bool> createMovie(Movie newMovie);
        Task<bool> updateMovie(Movie editMovie);
        Task<bool> deleteMovie(int id);
    }
}
