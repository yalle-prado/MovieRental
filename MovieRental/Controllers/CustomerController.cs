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
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
	        return Ok(_features.GetAll());
        }

        // GET: api/Customer/id/5
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

        /// <summary>
        /// POST:api/Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Customer.Customer customer)
        {
            return Ok(_features.Save(customer));
        }
    }
}
