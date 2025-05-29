using System.ComponentModel.DataAnnotations;

namespace MovieRental.Movie
{
	public class Movie
	{
		[Key]

        /// <summary>
        /// Movie ID , primary key.
        /// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Movie Title.
        /// </summary>
		public string Title { get; set; }
	}
}
