namespace MovieRental.Rental;


public interface IRentalFeatures
{
	/// <summary>
	/// /Chnage Interface to accept async command
	/// 
	/// </summary>
	/// <param name="rental"></param>
	/// <returns></returns>
	Task<Rental> Save(Rental rental);
	List<Rental> GetRentalsByCustomerName(string customerName);
	
	Task<bool> SavePayment(double Price, string CustomerName, string PaymentMethod);
}