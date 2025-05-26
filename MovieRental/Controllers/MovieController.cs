using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly IMovieFeatures _features;

        public MovieController(IMovieFeatures features)
        {
            _features = features;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_features.GetAll());
        }

        //GET: api/Movie/title/Godfather
        [HttpGet("title/{title}")]
        public IActionResult GetMovieByTitle(string title)
        {
            var movies= _features.GetMovieByTitle(title);
            if (movies == null)
            {
                return NotFound();
            }

	        return Ok(movies);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie.Movie movie)
        {
            return Ok(_features.Save(movie));
        }
    }
}
