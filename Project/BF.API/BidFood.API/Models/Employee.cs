using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BF.API.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        
        [Required]
        [Range(1, 1000000)]
        public int Salary { get; set; }
        public string Department { get; set; }
    }
}
