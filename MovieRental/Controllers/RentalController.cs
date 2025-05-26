using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;
using MovieRental.Rental;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }


        /// POST:api/Rental
        /// <summary>
        /// Saves the rental register information.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="Id">The movie id, int number, generated automaticlly.. </param>
        /// <param daysrented="DaysRented">How many days it will be rented, type int  </param>
        /// <param movie="Movie"> It is object type movie, where it contains movie information about movie  </param>
        /// <param movieId="Movie ID"> Movie Id to identify which movie this rent it refers  </param>
        /// <param PaymmentMethod="Payment Method"> Idenfify which payment method the customer is using for this rent </param>
        /// <param CustomerID="Customer Id"> Idenfify customer by Id </param>
        /// <param CustomerName="Customer Name"> Save the customer name </param>
        /// <returns>True if successful, false otherwise</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Rental.Rental rental)
        {
            return Ok(_features.SaveRental(rental));
        }

	}
}

