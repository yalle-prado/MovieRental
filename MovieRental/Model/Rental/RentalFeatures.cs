using Microsoft.EntityFrameworkCore;
using MovieRental.Data; 

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public RentalFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		//TODO: make me async :(
		/// <summary>
		/// Add async syntaxe, here it will call the method SaveChangeAsync 
		/// </summary>
		/// <param name="rental"></param>
		/// <returns></returns>
		public async Task<Rental> Save(Rental rental)
		{
			_movieRentalDb.Rentals.Add(rental);
			await _movieRentalDb.SaveChangesAsync();
			return rental;
		}

		//TODO: finish this method and create an endpoint for it

		/// <summary>
		/// Here the Method will search into Database the rental by Customer Name.
		/// </summary>
		/// <param name="customerName"></param>
		/// <returns></returns>
		public IEnumerable<Rental> GetRentalsByCustomerName(string customerName)
		{
			return _movieRentalDb.Rentals.Where(r => r.CustomerName == customerName);
		}

	}
}
