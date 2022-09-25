using System.ComponentModel.DataAnnotations;

namespace Labb1_MVC_Razor.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public string CartId { get; set; }
        public Book Book { get; set; }
    }
}
