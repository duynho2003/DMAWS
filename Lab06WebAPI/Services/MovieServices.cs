using Lab06Lib;
using Lab06WebAPI.DB_Helper;
using Lab06WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab06WebAPI.Services
{
    public class MovieServices : IMovieRepository
    {
        private readonly DatabaseContext _db;
        public MovieServices(DatabaseContext db) 
        {
            _db = db;
        }
        public async Task<bool> createMovie(Movie newMovie)
        {
            await _db.Movie.AddAsync(newMovie);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteMovie(int id)
        {
            var model = _db.Movie.SingleOrDefault(m=>m.id.Equals(id));
            if (model != null) 
            {
                _db.Movie.Remove(model);
                await _db.SaveChangesAsync();
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public async Task<IEnumerable<Movie>> findAll()
        {
            return await _db.Movie.ToListAsync();
        }

        public async Task<Movie> findOne(int id)
        {
            return await _db.Movie.FindAsync(id);
        }

        public async Task<bool> updateMovie(Movie editMovie)
        {
            var movie = await _db.Movie.SingleOrDefaultAsync(m=>m.id == editMovie.id);
            if(movie != null)
            {
                movie.title = editMovie.title;
                movie.genre = editMovie.genre;
                movie.director = editMovie.director;
                movie.year = editMovie.year;
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
