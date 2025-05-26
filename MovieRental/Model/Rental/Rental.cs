using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRental.Rental
{
	public class Rental
	{
		[Key]
		public int Id { get; set; }
		public int DaysRented { get; set; }
		public Movie.Movie? Movie { get; set; }

		[ForeignKey("Movie")]
		public int MovieId { get; set; }

		private string _paymethod;
		public string PaymentMethod
		{
			get => _paymethod;
			set
			{
				if (value != "MBway" && value != "PayProvider")
				{
					throw new ArgumentException("PaymentMethod must be 'MBWay' or 'PayProvider'");

				}
				_paymethod = value;
			}	
		} 


		// TODO: we should have a table for the customers
		public string CustomerName { get; set; }
	}
}
