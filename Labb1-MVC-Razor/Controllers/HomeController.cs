using Labb1_MVC_Razor.Models;
using Labb1_MVC_Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Labb1_MVC_Razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                BookInstock = _bookRepository.GetAllBooksInStock
            };
            return View(homeViewModel);
        }
    }
}