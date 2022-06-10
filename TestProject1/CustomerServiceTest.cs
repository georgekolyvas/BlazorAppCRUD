using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class CustomerServiceTest : IDisposable
    {
        private readonly ApplicationDbContext _context;
        public CustomerServiceTest()
        {  
            // use Guid for db name for isolation
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())                 
                .Options;

            _context = new ApplicationDbContext(options);

            _context.Database.EnsureCreated();

            NewTestList(_context);
        }

        //Test: Database should return the right type of Customers
        [Fact]
        public async Task DbShouldReturnCorrectType()
        {
            // Arrange – creating the objects and setting them up  
            var customerService = new CustomerService(_context);

            // Act – this is where the method we are testing is executed
            var result = customerService.GetCustomers();

            // Assert – this is the final part of the test where we compare
            await Assert.IsAssignableFrom<Task<List<ApiCustomer>>>(result);
        }

        // Test: GetCustomers methods return all items from database
        [Fact]
        public async Task MethodsShouldReturnAllCustomers()
        {
            // Arrange
            var customerService = new CustomerService(_context);

            // Act
            var result = await customerService.GetCustomers();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task GetCustomer_ReturnsCustomer_GivenValidId()
        {
            var customerService = new CustomerService(_context);

            var result = customerService.GetCustomerById(1);

            var objectResult = Assert.IsType<Task<ApiCustomer>>(result);
            var customer = await Assert.IsAssignableFrom<Task<ApiCustomer>>(objectResult);
            Assert.Equal(1, customer.Id);
        }

        [Fact]
        public async Task CreateCustomer_ReturnsSuccessfullyMessage()
        {
            var customerService = new CustomerService(_context);

            var result = await customerService.CreateCustomer(new ApiCustomer
            {
                Id = 4,
                CompanyName = "aCompanyName4",
                ContactName = "aContactName4",
                Address = "anAddress4",
                City = "aCity4",
                Region = "aRegion4",
                PostalCode = "aPostalCode4",
                Country = "aCountry4",
                Phone = "aPhone4"
            });

            Assert.Equal("Save Successfully", result);
        }       

        [Fact]
        public async Task DeleteCustomer_ReturnsSuccessfullyMessage()
        {
            var customerService = new CustomerService(_context);

            // select a customer to be deleted
            var selectedObj = customerService.GetCustomerById(1);

            var customer = await Assert.IsAssignableFrom<Task<ApiCustomer>>(selectedObj);

            var result = await customerService.DeleteCustomer(customer);

            Assert.Equal("Delete Successfully", result);
        }

        private void NewTestList(ApplicationDbContext context)
        {
            var customers = new List<ApiCustomer>
            {
                new ApiCustomer{   
                    Id = 1,
                    CompanyName = "aCompanyName",
                    ContactName = "aContactName",
                    Address = "anAddress",
                    City = "aCity",
                    Region = "aRegion",
                    PostalCode = "aPostalCode",
                    Country = "aCountry",
                    Phone = "aPhone"
                },
                new ApiCustomer{
                    Id = 2,
                    CompanyName = "aCompanyName2",
                    ContactName = "aContactName2",
                    Address = "anAddress2",
                    City = "aCity2",
                    Region = "aRegion2",
                    PostalCode = "aPostalCode2",
                    Country = "aCountry2",
                    Phone = "aPhone2"
                },
                new ApiCustomer{
                    Id = 3,
                    CompanyName = "aCompanyName3",
                    ContactName = "aContactName3",
                    Address = "anAddress3",
                    City = "aCity3",
                    Region = "aRegion3",
                    PostalCode = "aPostalCode3",
                    Country = "aCountry3",
                    Phone = "aPhone3"
                }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

       // Dispose Db - release memomy from tests
       [Fact]
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
