using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class Customer
    {
        // (sql server) "Customer" table has an auto increment "Id" field. It only applies to type "int"
        //public string Id { get; set; }
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
