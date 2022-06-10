using DataAccessLibrary.Models;
using DataAccessLibrary.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface ICustomerService
    {        
        Task<string> DeleteCustomer(int id);
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetCustomers();
        Task<string> CreateCustomer(Customer objCustomer);        
        Task<string> UpdateCustomer(Customer objCustomer);
        Task<PagedList<Customer>> GetPaginatedCustomers(int pageIndex, int pageSize);
    }
}