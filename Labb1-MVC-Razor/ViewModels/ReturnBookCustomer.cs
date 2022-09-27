using Labb1_MVC_Razor.Models;

namespace Labb1_MVC_Razor.ViewModels
{
    public class ReturnBookCustomer
    {
        public RentBookDetail RentedBooks { get; set; }
        public Customer CustomerWhoRented { get; set; }


    }
}
