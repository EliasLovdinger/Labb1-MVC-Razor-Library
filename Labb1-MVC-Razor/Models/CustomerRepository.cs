using Labb1_MVC_Razor.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labb1_MVC_Razor.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Customer> GetAllCustomers => _appDbContext.Customers;

        public Customer AddCustomer(Customer customer)
        {
            _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();

            return customer;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            var customerToUpdate = _appDbContext.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

            _appDbContext.Customers.Update(customerToUpdate);
            _appDbContext.SaveChanges();

            return customerToUpdate;
        }

        public Customer DeleteCustomer(int id)
        {
            var customerToDelete = _appDbContext.Customers.Find(id);
            _appDbContext.Customers.Remove(customerToDelete);
            _appDbContext.SaveChanges();
            return customerToDelete;
        }

        public Customer GetCustomerById(int id)
        {
            return _appDbContext.Customers.Include(c => c.RentBook).ThenInclude(r => r.RentBookDetails).ThenInclude(r => r.Book).FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer SelectCustomer()
        {

            //Försök till sök till customer
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

            return customer;
        }
    }
}
