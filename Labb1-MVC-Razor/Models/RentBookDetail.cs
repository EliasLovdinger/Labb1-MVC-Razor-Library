using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Labb1_MVC_Razor.Models
{
    public class RentBookDetail
    {
        [Key]
        public int RentBookDetailId { get; set; }
        public int RentBookId { get; set; }
        public RentBook RentBook { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
