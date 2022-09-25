namespace Labb1_MVC_Razor.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks { get; }
        IEnumerable<Book> GetAllBooksInStock { get; }
        Book GetBookById(int id);
    }
}
