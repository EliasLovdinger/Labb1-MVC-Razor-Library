using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Labb1_MVC_Razor.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Enter Your First Name")]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [Display(Name = "Email")]
        [StringLength(40)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phonenumber")]
        public string Phone { get; set; }

        public List<RentBook> RentBook { get; set; }

        [NotMapped]
        public List<SelectListItem> CustomerList { get; set; }

        public static implicit operator Customer(DbSet<Customer> v)
        {
            throw new NotImplementedException();
        }
    }
}
