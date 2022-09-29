using Labb1_MVC_Razor.Models;
using Labb1_MVC_Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Labb1_MVC_Razor.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public ViewResult List(string IsInStock)
        {
            IEnumerable<Book> books;
            string currentIsInStock;
            if (string.IsNullOrEmpty(IsInStock))
            {
                books = _bookRepo.GetAllBooks.OrderBy(b => b.BookId);
                currentIsInStock = "All Books";
            }
            else
            {
                books = _bookRepo.GetAllBooks.Where(b => b.Amount > 0);
                currentIsInStock = _bookRepo.GetAllBooksInStock.FirstOrDefault(b => b.Title == IsInStock)?.Title;
            }

            return View(new BookListViewModel
            {
                Books = books,
                CurrentInStock = currentIsInStock
            });
        }

        public IActionResult Details(int Id)
        {
            var book = _bookRepo.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}