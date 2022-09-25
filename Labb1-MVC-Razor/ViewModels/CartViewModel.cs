using Labb1_MVC_Razor.Models;

namespace Labb1_MVC_Razor.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public RentBook RentBook { get; set; }
        public decimal CartTotal { get; set; }
        
    }
}
