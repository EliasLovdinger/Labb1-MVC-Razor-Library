using Labb1_MVC_Razor.Models;
using Labb1_MVC_Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Labb1_MVC_Razor.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customer;
        private readonly AppDbContext _appDbContext;
        private readonly IRentBookRepository _RentBookRepository;
        private readonly Cart _cart;

        public CustomerController(ICustomerRepository customer, AppDbContext appDbContext, IRentBookRepository rentBookRepository, Cart cart)
        {
            _customer = customer;
            _appDbContext = appDbContext;
            _RentBookRepository = rentBookRepository;
            _cart = cart;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _appDbContext.Customers.ToListAsync());
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
