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
                var BookRented = _appDbContext.Books.FirstOrDefault(b => b.BookId == RentBookDetails.BookId);
                BookRented.Amount = BookRented.Amount - 1;

                _appDbContext.Books.Update(BookRented);

                _appDbContext.RentBookDetails.Add(RentBookDetails);
            }
            
            _appDbContext.SaveChanges();

            return rentBook;
        }

        public RentBook ReturnABook(int rentBookId)
        {
            var rentBookToReturn = _appDbContext.RentBooks.FirstOrDefault(r => r.RentBookId == rentBookId);
            rentBookToReturn.ReturnDate = DateTime.Now;

            var rentBookDetails = _appDbContext.RentBookDetails.FirstOrDefault(r => r.RentBookId == rentBookId);

            var BookRented = _appDbContext.Books.FirstOrDefault(b => b.BookId == rentBookDetails.BookId);
            BookRented.Amount = BookRented.Amount + 1;


            _appDbContext.Books.Update(BookRented);

            _appDbContext.RentBooks.Update(rentBookToReturn);
            _appDbContext.SaveChanges();

            return rentBookToReturn;
        }

    }
}
