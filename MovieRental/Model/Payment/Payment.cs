using System.ComponentModel.DataAnnotations;

namespace MovieRental.Payment
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RentalId { get; set; } = 0;

        public string Customer { get; set; }
        public string Provider { get; set; }

        public double Price { get; set; }

	}
}
