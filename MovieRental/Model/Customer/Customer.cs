using System.ComponentModel.DataAnnotations;

namespace MovieRental.Customer
{
    public class Customer
    {
        [Key]
        
        /// <summary>
        /// Customer ID , primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer Name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Customer Age .
        /// </summary>
        public string Age { get; set; }
    }
}


