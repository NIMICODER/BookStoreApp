using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

       
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
