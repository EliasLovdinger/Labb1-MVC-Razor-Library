using System.Collections.Generic;

namespace Labb1_MVC_Razor.Models
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);

        IEnumerable<Customer> GetAllCustomers { get; }

        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer DeleteCustomer(int id);

        Customer SelectCustomer ();
    }
}
