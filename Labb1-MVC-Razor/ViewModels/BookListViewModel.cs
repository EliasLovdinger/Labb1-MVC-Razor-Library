using Labb1_MVC_Razor.Models;

namespace Labb1_MVC_Razor.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        public string CurrentIsInStock { get; set; }

    }
}
