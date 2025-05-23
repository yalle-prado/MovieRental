namespace MovieRental.Customer
{

    public interface ICustomerFeatures
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        List<Customer> GetCustomerByName(string name);
        Customer SaveCustomer(Customer customer);

    }


}