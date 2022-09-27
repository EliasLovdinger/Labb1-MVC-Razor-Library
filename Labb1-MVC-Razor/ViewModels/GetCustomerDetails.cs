using Labb1_MVC_Razor.Models;

namespace Labb1_MVC_Razor.ViewModels
{
    public class GetCustomerDetails
    {
        public List<RentBook> ListOfBooks { get; set; }

        public Customer customerDetails { get; set; }
    }
}
