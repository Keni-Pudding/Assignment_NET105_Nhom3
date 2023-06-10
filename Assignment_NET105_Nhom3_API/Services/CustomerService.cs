using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MyDbContext _context;
        public CustomerService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> DeleteCustomer(Guid Id)
        {
            var a = await _context.Customer.FirstOrDefaultAsync(x =>x.Id == Id);
            if (a == null) return null;
            _context.Customer.Remove(a);    
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid Id)
        {
            return await _context.Customer.FindAsync(Id);
        }

        public Task<IEnumerable<Customer>> GetCustomerByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> PutCustomer(Customer customer)
        {
            var a = await _context.Customer.FindAsync(customer.Id);
            if (a == null) return null;
            a.CustomerCode = customer.CustomerCode;
            a.Name = customer.Name;
            a.UserName = customer.UserName;
            a.Password = customer.Password;
            a.NumberPhone = customer.NumberPhone;
            a.Email = customer.Email;
            a.Address = customer.Address;
            a.Sex = customer.Sex;
            a.RoleId = customer.RoleId;
            a.Status = customer.Status;
            _context.Customer.Update(a);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
