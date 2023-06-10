using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetAllCustomer();
        public Task<Customer> PostCustomer(Customer customer);
        public Task<Customer> PutCustomer(Customer customer);
        public Task<Customer> DeleteCustomer(Guid Id);
        public Task<Customer> GetCustomerById(Guid Id);
        public Task<IEnumerable<Customer>> GetCustomerByName(string Name);
    }
}
