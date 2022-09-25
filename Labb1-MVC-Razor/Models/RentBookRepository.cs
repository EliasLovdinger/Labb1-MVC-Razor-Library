namespace Labb1_MVC_Razor.Models
{
    public class RentBookRepository : IRentBookRepository
    {
        private readonly AppDbContext  _appDbContext;
        private readonly Cart _cart;

        public RentBookRepository(AppDbContext appDbContext, Cart cart)
        {
            _appDbContext = appDbContext;
            _cart = cart;
        }

        public IEnumerable<RentBook> GetAllRentBooks() => _appDbContext.RentBooks;

        public RentBook RentABook(RentBook rentBook)
        {
            rentBook.RentedDate = DateTime.Now;

            _appDbContext.RentBooks.Add(rentBook);
            _appDbContext.SaveChanges();

            var CartItems = _cart.GetCartItems();

            foreach (var cartItem in CartItems)
            {
                var RentBookDetails = new RentBookDetail
                {
                    Book = cartItem.Book,
                    BookId = cartItem.Book.BookId,
                    RentBookId = rentBook.RentBookId, 
                };
                _appDbContext.RentBookDetails.Add(RentBookDetails);
            }
            
            _appDbContext.SaveChanges();

            return rentBook;
        }

        public RentBook ReturnABook(RentBook rentbook)
        {
            rentbook.ReturnDate = DateTime.Now;
            return rentbook;
        }

    }
}
