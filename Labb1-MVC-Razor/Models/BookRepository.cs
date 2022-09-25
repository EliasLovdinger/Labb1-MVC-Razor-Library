namespace Labb1_MVC_Razor.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public IEnumerable<Book> GetAllBooks => _appDbContext.Books;

        public IEnumerable<Book> GetAllBooksInStock => _appDbContext.Books.Where(b => b.Amount > 0);

        public Book GetBookById(int id) => GetAllBooks.FirstOrDefault(b => b.BookId == id);
    }
}
