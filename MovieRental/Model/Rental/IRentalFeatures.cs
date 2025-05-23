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
	IEnumerable<Rental> GetRentalsByCustomerName(string customerName);
}