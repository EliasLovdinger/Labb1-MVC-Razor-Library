using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Labb1_MVC_Razor.Models
{
    public class RentBook
    {
        [BindNever]
        public int RentBookId { get; set; }

        public DateTime RentedDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<RentBookDetail> RentBookDetails { get; set; }


    }
}
