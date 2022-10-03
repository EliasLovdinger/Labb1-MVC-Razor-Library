using Labb1_MVC_Razor.Models;
using Labb1_MVC_Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Labb1_MVC_Razor.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IRentBookRepository _RentBookRepository;
        private readonly Cart _cart;

        public CustomerController(ICustomerRepository customerRepository, AppDbContext appDbContext, IRentBookRepository rentBookRepository, Cart cart)
        {
            _customerRepository = customerRepository;
            _appDbContext = appDbContext;
            _RentBookRepository = rentBookRepository;
            _cart = cart;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _appDbContext.Customers.ToListAsync());
        }

        public IActionResult GetCustomerDetails(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);

            var listOfRentBooks = _appDbContext.RentBooks.Include(b => b.RentBookDetails).ThenInclude(c => c.Book)
                .Where(r => r.CustomerId == customerId);


            var viewModel = new GetCustomerDetails
            {
                ListOfBooks = listOfRentBooks.ToList(),
                customerDetails = customer
            };

            return View(viewModel);
        }
        public IActionResult ReturnBook(int id)
        {
            //var BookReturned = _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
            //var Amount = BookReturned.Amount;
            //Amount++;
            //BookReturned.Amount = Amount;
            //_appDbContext.Books.Update(BookReturned);

            _RentBookRepository.ReturnABook(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Customer());
            }
            else
            {
                return View(_appDbContext.Customers.Find(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    _appDbContext.Add(customer);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _appDbContext.Update(customer);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CustomerToDelete = await _appDbContext.Customers.FindAsync(id);

            _appDbContext.Customers.Remove(CustomerToDelete);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SelectCustomer()
        {
            Customer customer = new Customer();
            customer.CustomerList = new List<SelectListItem>();

            var data = _appDbContext.Customers.ToList();
            customer.CustomerList.Add(new SelectListItem
            {
                Text = "Select Customer",
                Value = ""
            });

            foreach (var item in data)
            {
                customer.CustomerList.Add(new SelectListItem
                {
                    Text = item.FirstName,
                    Value = Convert.ToString(item.CustomerId),
                });
            }

            //var customerData = _customer.SelectCustomer();

            var ViewModel = new SelectCustomerViewModel
            {
                CustomerList = customer
            };

            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult SelectCustomer(Customer customer)
        {
            
            customer.CustomerList = new List<SelectListItem>();

            var data = _appDbContext.Customers.ToList();
            customer.CustomerList.Add(new SelectListItem
            {
                Text = "Select Customer",
                Value = ""
            });

            foreach (var item in data)
            {
                customer.CustomerList.Add(new SelectListItem
                {
                    Text = item.FirstName,
                    Value = Convert.ToString(item.CustomerId),
                });
            }

            RentBook rentBook = new RentBook();

            var CustomerToAdd = _appDbContext.Customers.FirstOrDefault(c => c.FirstName == customer.FirstName).CustomerId;

            rentBook.CustomerId = CustomerToAdd;

            _cart.CartItems = _cart.GetCartItems();

                if (_cart.CartItems.Count == 0)
                {
                    ModelState.AddModelError("", "Your cart is empty");
                }
                else
                {
                    _RentBookRepository.RentABook(rentBook);
                    _cart.ClearCart();

                    return RedirectToAction("Index","Home");
                }


            var ViewModel = new SelectCustomerViewModel
            {
                CustomerList = customer,
            };
            return View(ViewModel);
        }
    }
}
