using System.ComponentModel.DataAnnotations;

namespace MovieRental.Payment
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        /// <summary>
        /// Rental ID , used to identify which rent it is refers ( Foreign Key??).
        /// </summary>
        public int RentalId { get; set; }

        /// <summary>
        /// Customer Name to name which customer this payment belongs ( CustomerID?? ,  Foreign Key??).
        /// </summary>
        
        public string Customer { get; set; }
        
        /// <summary>
        /// Defines Payment Provider .
        /// </summary>
        public string Provider { get; set; }


        /// <summary>
        /// Rent payment value.
        /// </summary>
        public double Price { get; set; }

	}
}
