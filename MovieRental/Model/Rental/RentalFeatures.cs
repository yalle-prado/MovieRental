using System.Threading.Tasks;
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
		public async Task<Rental> SaveRental(Rental rental)
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


	
		/// <summary>
		/// Here the Method will search into Database the rental by Customer ID.  It is more functional to find the specific customer
		/// </summary>
		/// <param name="customerName"></param>
		/// <returns></returns>
		public List<Rental> GetRentalsByCustomerID(int customerID)
		{
			return _movieRentalDb.Rentals.Where(rental => rental.CustomerId == customerID).ToList();
		}

		public async Task<bool> SavePayment(double price, string CustomerName, int RentalId, string PaymentMethod)
		{

			if (price > 0)
			{
				if (PaymentMethod == "MBWay")
				{
					var mbWayProvider = new MbWayProvider();
					bool paymentSucess = await mbWayProvider.Pay(price);

					if (paymentSucess)
					{
						return true;
					}

				}
				else if (PaymentMethod == "PayPalProvider")
				{
					var payPalProvider = new PayPalProvider();
					bool paymentSucess = await payPalProvider.Pay(price);

					if (paymentSucess)
					{
						return true;
					}

				}

				else
				{
					throw new ArgumentException("PaymentMethod must be 'MBWay' or 'PayPalProvider'");
				}
			}
			return false;
		}
	}
}
