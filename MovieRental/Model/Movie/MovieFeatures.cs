using MovieRental.Data;

namespace MovieRental.Movie
{
	public class MovieFeatures : IMovieFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public MovieFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}
		
		public Movie Save(Movie movie)
		{
			_movieRentalDb.Movies.Add(movie);
			_movieRentalDb.SaveChanges();
			return movie;
		}

		// TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?
		/// <summary>
		/// It returns a list of object, it doesn't have a list of values, but object that can't be render
		/// </summary>
		/// <returns>
		/// Alternatively I would create something like return _movieRentalDb.Movies.AsQueryable().ToList();
		/// or evan create a pagination to limit the amount of registers to list.
		/// </returns>
		public List<Movie> GetAll()
		{
			return _movieRentalDb.Movies.AsQueryable().ToList();
		}


	}
}
