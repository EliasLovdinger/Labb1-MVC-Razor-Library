using Labb1_MVC_Razor.Models;

namespace Labb1_MVC_Razor.ViewModels
{
    public class RentBookCustomer
    {
        public RentBook RentedBooks { get; set; }
        public Customer CustomerWhoRented { get; set; }


    }
}
