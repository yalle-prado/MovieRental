using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.PaymentProviders;

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
		public async Task<Rental> SavRental(Rental rental)
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
		public List<Rental> GetRentalsByCustomerName(string customerName)
		{
			return _movieRentalDb.Rentals.Where(rental => rental.CustomerName == customerName).ToList();
		}

		public bool SavePayment(double price, string CustomerName, string PaymentMethod)
		{

			if (price > 0)
			{
				if (PaymentMethod = "MBWay")
				{
					Rent
				}
			}
		}
	}
}
	bool SavePayment(int Price, string CustomerName, string PaymentMethod);