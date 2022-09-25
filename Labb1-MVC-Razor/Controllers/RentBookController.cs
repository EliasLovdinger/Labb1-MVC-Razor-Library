using Labb1_MVC_Razor.Models;
using Labb1_MVC_Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.Drawing.Text;

namespace Labb1_MVC_Razor.Controllers
{
    public class RentBookController : Controller
    {
        private readonly IRentBookRepository _RentBookRepository;
        private readonly AppDbContext _appDbContext;

        public RentBookController(IRentBookRepository rentBookRepository)
        {
            _RentBookRepository = rentBookRepository;
        }


        public IActionResult ReturnABook()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ReturnABook(RentBook rentBook)
        {
            return View();
        }


    }
}
