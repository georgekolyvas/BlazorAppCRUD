using DataAccessLibrary.Models;
using DataAccessLibrary.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface ICustomerService
    {
        Task<string> DeleteCustomer(ApiCustomer objCustomer);
        Task<ApiCustomer> GetCustomerById(int id);
        Task<List<ApiCustomer>> GetCustomers();
        Task<string> CreateCustomer(ApiCustomer objCustomer);        
        Task<string> UpdateCustomer(ApiCustomer objCustomer);
        Task<PagedList<ApiCustomer>> GetPaginatedCustomers(int pageIndex, int pageSize);
    }
}