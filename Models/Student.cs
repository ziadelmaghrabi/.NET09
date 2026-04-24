 
using System.ComponentModel.DataAnnotations;
namespace Sessions.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [Range(16, 60, ErrorMessage = "Age must be between 16 and 60")]
        public int Age { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        public string Major { get; set; }
    }
}