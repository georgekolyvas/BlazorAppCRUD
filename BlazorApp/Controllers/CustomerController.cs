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
        public async Task<List<ApiCustomer>> GetCustomers()
        {
            return await _customerService.GetCustomers();
        }

        /// <summary>
        /// Get a single customer matched by id
        /// </summary>
        // api/customer/{id}         
        [HttpGet("{id}")]
        public async Task<ApiCustomer> GetCustomerById(int id)
        {
            return await _customerService.GetCustomerById(id);
        }

        /// <summary>
        /// Update an existing customer
        /// </summary>         
        [HttpPut]
        public async Task<string> UpdateCustomer(ApiCustomer objCustomer)
        {
            return await _customerService.UpdateCustomer(objCustomer);
        }

        /// <summary>
        /// Create a new customer
        /// </summary>        
        [HttpPost]
        public async Task<string> CreateCustomer(ApiCustomer objCustomer)
        {
            return await _customerService.CreateCustomer(objCustomer);
        }

        /// <summary>
        /// Delete a customer
        /// </summary> 
        [HttpDelete]
        public async Task<string> DeleteCustomer(ApiCustomer objCustomer)
        {
            return await _customerService.DeleteCustomer(objCustomer);
        }
    }
}
