using Labb1_MVC_Razor.Models;

namespace Labb1_MVC_Razor.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> BookInstock { get; set; }
    }
}
