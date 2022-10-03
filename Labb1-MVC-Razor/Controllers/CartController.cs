using Labb1_MVC_Razor.Models;
using Labb1_MVC_Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Labb1_MVC_Razor.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly Cart _cart;

        public CartController(IBookRepository bookRepository, Cart cart)
        {
            _bookRepository = bookRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            _cart.CartItems = _cart.GetCartItems();
            var CartViewModels = new CartViewModel
            {
                Cart = _cart,
            };
            return View(CartViewModels);
        }

        public RedirectToActionResult AddToCart(int bookId)
        {
            var selectedBook = _bookRepository.GetAllBooks.FirstOrDefault(b => b.BookId == bookId);

            if (selectedBook != null)
            {
                _cart.AddToCart(selectedBook);
            }
            return RedirectToAction("Index", "Home");
        }

        public RedirectToActionResult RemoveFromCart(int bookId)
        {
            var selectedBook = _bookRepository.GetAllBooks.FirstOrDefault(b => b.BookId == bookId);

            if (selectedBook != null)
            {
                _cart.RemoveFromCart(selectedBook);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart()
        {
            _cart.ClearCart();
            return RedirectToAction("Index");
        }

    }
}
