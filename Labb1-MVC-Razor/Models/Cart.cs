using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb1_MVC_Razor.Models
{
    public class Cart
    {
        private readonly AppDbContext _appDbContext;

        public Cart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CartID { get; set; }
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartID")?? Guid.NewGuid().ToString();
            session.SetString("CartID", cartId);

            return new Cart(context) { CartID = cartId };
        }

        public void AddToCart(Book book) 
        {

            var CartItem =  _appDbContext.CartItems.SingleOrDefault(c => c.Book.BookId == book.BookId
            && c.CartId == CartID);

            if (CartItem == null)
            {
                CartItem = new CartItem
                {
                    CartId = CartID,
                    Book = book,
                };
                _appDbContext.CartItems.Add(CartItem);        
            }

            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var CartItem = _appDbContext.CartItems.SingleOrDefault(c => c.Book.BookId == book.BookId
            && c.CartId == CartID);

            var localAmount = 0;

            if (CartItem != null)
            {

                _appDbContext.CartItems.Remove(CartItem);
            }

            _appDbContext.SaveChanges();
            return localAmount;
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ?? (CartItems = _appDbContext.CartItems.
                Where(c => c.CartId == CartID).
                Include(b => b.Book).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.CartItems.Where(c => c.CartId == CartID);
            _appDbContext.CartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }
    }
}
