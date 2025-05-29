namespace MovieRental.Customer
{

    public interface ICustomerFeatures
    {
        List<Customer>? GetAll();
        Customer? GetCustomerById(int id);
        Customer? GetCustomerByName(string name);
        Customer Save(Customer customer);

    }


}