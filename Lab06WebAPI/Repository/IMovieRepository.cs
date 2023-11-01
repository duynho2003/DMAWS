using Lab06Lib;

namespace Lab06WebAPI.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> findAll();
        Task<Movie> findOne(int id);
        Task<Movie> createMovie(Movie newMovie);
        Task<Movie> updateMovie(Movie editMovie);
        Task<Movie> deleteMovie(int id);
    }
}
