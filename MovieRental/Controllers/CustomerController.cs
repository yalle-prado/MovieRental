using Microsoft.AspNetCore.Mvc;
using MovieRental.Customer;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerFeatures _features;

        public CustomerController(ICustomerFeatures features)
        {
            _features = features;
        }

        //GET: api/Customer
        /// <summary>
        /// Gets all customers list
        /// </summary>
        /// <returns>Returns json with all customers informations </returns>
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
	        return Ok(_features.GetAll());
        }


        // GET: api/Customer/id/5

        /// <summary>
        /// Gets specifc customer by id.
        /// </summary>
        /// <param name="id">The customer name</param>
        /// <returns>Returns json with all customers informations </returns>
        [HttpGet("id/{id:int}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _features.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        //GET: api/Customer/name/Yalle
        // GET: api/Customer/id/5

        /// <summary>
        /// Gets specifc customer by Name.
        /// </summary>
        /// <remarks>
        /// This method has to be improved to consider Surname or part of the name, also prevent erros and bad requests, anyways, many improviments possible
        /// </remarks>
        /// <param name="name">The customer name. (It has to be improved to find by part of name, by instance, surname mistyped name,etc)  </param>
        /// <returns>Returns json with specific customer informations </returns>
        [HttpGet("name/{name}")]
        public IActionResult GetCustomerByName(string name)
        {
            var customers= _features.GetCustomerByName(name);
            if (customers == null)
            {
                return NotFound();
            }

	        return Ok(customers);
        }


        // POST:api/Customer

        /// <summary>
        /// Saves the specifc customer.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id">The customer id. </param>
        /// <param name="name">The customer name. </param>
        /// <param age="age">Customer age. Used to verify the age restricitons, by instance </param>
        /// <returns>True if successful, false otherwise</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Customer.Customer customer)
        {
            return Ok(_features.Save(customer));
        }
    }
}
