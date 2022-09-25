using System.ComponentModel.DataAnnotations;

namespace Labb1_MVC_Razor.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int Amount { get; set; }
    }
}
