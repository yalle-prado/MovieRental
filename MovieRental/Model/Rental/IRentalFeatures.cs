namespace MovieRental.Rental;


public interface IRentalFeatures
{
	/// <summary>
	/// /Chnage Interface to accept async command
	/// 
	/// </summary>
	/// <param name="rental"></param>
	/// <returns></returns>
	Task<Rental> SaveRental(Rental rental);
	List<Rental> GetRentalsByCustomerName(string customerName);
	
	Task<bool> SavePayment(double Price, string CustomerName, int rentalId, string PaymentMethod);
}