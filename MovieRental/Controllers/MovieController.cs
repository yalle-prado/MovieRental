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

        //GET: api/Customer
        
        /// <summary>
        /// Gets all movies list
        /// </summary>
        /// <returns>Returns json with all movies informations </returns>
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_features.GetAll());
        }


        //GET: api/Movie/title/Godfather

        /// <summary>
        /// Gets specifc move by Name.
        /// </summary>
        /// <remarks>
        /// This method has to be improved to consider part  of the movie title, also prevent erros and bad requests, anyways, many improviments possible
        /// </remarks>
        /// <param title="title">The movie title. (It has to be improved to find by part of the tile, by instance, surname mistyped title,etc)  </param>
        /// <returns>Returns json with specific movie informations </returns>
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


        // POST:api/Movie
        
        /// <summary>
        /// Saves the  movie information.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id">The movie id, it will be unique. </param>
        /// <param age="title">Movie Title </param>
        /// <returns>True if successful, false otherwise</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Movie.Movie movie)
        {
            return Ok(_features.Save(movie));
        }
    }
}
