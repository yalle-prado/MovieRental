using Microsoft.AspNetCore.Http.HttpResults;
using MovieRental.Data;

namespace MovieRental.Payment
{
	public class PaymentFeatures : IPaymentFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public PaymentFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		public Payment Save(Payment payment)
		{
			_movieRentalDb.Payments.Add(payment);
			_movieRentalDb.SaveChanges();
			return payment;
		}

		// TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?
		/// <summary>
		/// It returns a list of object, it doesn't have a list of values, but object that can't be render
		/// </summary>
		/// <returns>
		/// Alternatively I would create something like return _movieRentalDb.Movies.AsQueryable().ToList();
		/// or evan create a pagination to limit the amount of registers to list.
		/// </returns>

		public Payment Cancel(Payment payment, int id)
		{
			throw new NotImplementedException();
		}
		
    }
}
