using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Customer
{
    public class CustomerFeatures : ICustomerFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public CustomerFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }


        // TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?
        /// <summary>
        /// It is bringing all the date to the memory what is not recommended.
        /// Should create a pagination or define limit. 
        /// 
        /// Also in case it doesn't have content shoudl throw a error or warning.
        /// </summary>

        public List<Customer>? GetAll()
        {
            return _movieRentalDb.Customers.ToList() ?? new List<Customer>();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _movieRentalDb.Customers.FirstOrDefault(x => x.Id == id);
            return customer ?? throw new InvalidOperationException($"This customer with ID {id} not found.");
        }

        public Customer? GetCustomerByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException($"This customer with Name {name} not found.");
            }
            
             return _movieRentalDb.Customers.SingleOrDefault(x => x.Name == name);
        }

        public Customer Save(Customer customer)
        {
            
			_movieRentalDb.Customers.Add(customer);
			_movieRentalDb.SaveChanges();
			return customer;
		}
    }
}
