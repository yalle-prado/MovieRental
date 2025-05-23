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
        /// </summary>
     
        public List<Customer> GetAllCustomers()
        {
            return _movieRentalDb.Customer.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _movieRentalDb.Customer.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Customer> GetCustomerByName(string name)
        {
             return _movieRentalDb.Customer.Where(x => x.Name == name).ToList();
        }

        public Customer SaveCustomer(Customer customer)
        {
			_movieRentalDb.Customer.Add(customer);
			_movieRentalDb.SaveChanges();
			return customer;
		}
    }
}
