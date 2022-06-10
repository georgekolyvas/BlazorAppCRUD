using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get all the customers
        /// </summary>
        // api/customer/getcustomers        
        [HttpGet("getcustomers")]
        public async Task<List<Customer>> GetCustomers()
        {
            return await _customerService.GetCustomers();
        }

        /// <summary>
        /// Get a single customer matched by id
        /// </summary>
        // api/customer/{id}         
        [HttpGet("{id}")]
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerService.GetCustomerById(id);
        }

        /// <summary>
        /// Update an existing customer
        /// </summary>         
        [HttpPut]
        public async Task<string> UpdateCustomer(Customer objCustomer)
        {
            return await _customerService.UpdateCustomer(objCustomer);
        }

        /// <summary>
        /// Create a new customer
        /// </summary>        
        [HttpPost]
        public async Task<string> CreateCustomer(Customer objCustomer)
        {
            return await _customerService.CreateCustomer(objCustomer);
        }

        /// <summary>
        /// Delete a customer
        /// </summary> 
        [HttpDelete("{id}")]        
        public async Task<string> DeleteCustomer(int id)
        {
            return await _customerService.DeleteCustomer(id);
        }
    }
}
