using DataAccessLibrary.Models;
using DataAccessLibrary.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;

        public CustomerService(ApplicationDbContext db)
        {
            _db = db;
        }

        // CRUD Operations
        // Get all customers      
        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                var customerList = await _db.Customers.ToListAsync();

                return customerList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // Create a customer
        public async Task<string> CreateCustomer(Customer objCustomer)
        {

            if (!CustomerExists(objCustomer.Id))
            {
                try
                {
                    _db.Customers.Add(objCustomer);
                    await _db.SaveChangesAsync();
                    return "Save Successfully";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                return "Customer Already Exists";
        }

        // Get customer by id
        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                Customer customer = await _db.Customers.FirstOrDefaultAsync(q => q.Id == id);
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Update customer
        public async Task<string> UpdateCustomer(Customer objCustomer)
        {
            try
            {
                _db.Customers.Update(objCustomer);
                await _db.SaveChangesAsync();
                return "Update Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Delete customer        
        public async Task<string> DeleteCustomer(int id)
        {
            try
            {                
                var customer = await _db.Customers.FindAsync(id);
                if (customer != null)
                {
                    _db.Remove(customer);
                    await _db.SaveChangesAsync();
                    return "Delete Successfully";
                }
                else
                    return "Not Customer Found";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // check if customer exists
        private bool CustomerExists(int id)
        {
            try
            {
                return _db.Customers.Any(q => q.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // paginated list of customers
        public async Task<PagedList<Customer>> GetPaginatedCustomers(int pageIndex, int pageSize)
        {
            try
            {
                IQueryable<Customer> customerQuery;
                int itemsToSkip = (pageIndex - 1) * pageSize;
                int itemsToTake = pageSize;

                customerQuery = _db.Customers.AsQueryable();
                var newCustomerlist = await PagedList<Customer>.CreateAsync(customerQuery, pageIndex, pageSize);                

                return newCustomerlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
