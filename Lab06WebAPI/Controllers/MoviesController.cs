using Lab06Lib;
using Lab06WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab06WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoivesController : ControllerBase
    {
        private IMovieRepository _moviesReponsitory;
        public MoivesController(IMovieRepository moviesReponsitory)
        {
            _moviesReponsitory = moviesReponsitory;
        }
        [HttpGet]
        public Task<IEnumerable<Movie>> Get()
        {
            return _moviesReponsitory.findAll();

        }
        [HttpPost]
        public Task<bool> Post(Movie newMovie)
        {
            return _moviesReponsitory.createMovie(newMovie);

        }
        [HttpDelete("{id}")]
        public Task<bool> DeleteMovie(int id)
        {
            return _moviesReponsitory.deleteMovie(id);

        }
        [HttpPut]
        public Task<bool> updateMovie(Movie editMovie)
        {
            return _moviesReponsitory.updateMovie(editMovie);

        }
    }
}