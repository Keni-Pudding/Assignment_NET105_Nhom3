using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;
        public CustomerController(ICustomerService customer)
        {
                _customer = customer;   
        }
        [HttpGet]
        public async Task<ActionResult<Customer>> GetAllCustomer()
        {
            var customer = await _customer.GetAllCustomer();
            return Ok(customer);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<Customer>> GetCustomerById(Guid Id)
        {
            var customer = await _customer.GetCustomerById(Id);
            return Ok(customer);
        }
        [HttpPost("Add-Customer")]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerViewModel model)
        {
            Customer customer = new Customer();
            customer.Id = Guid.NewGuid();   
            customer.CustomerCode = model.CustomerCode;
            customer.Name = model.Name;
            customer.UserName = model.UserName;
            customer.Password = model.Password;
            customer.Email = model.Email;
            customer.NumberPhone = model.NumberPhone;
            customer.Address = model.Address;
            customer.Sex = model.Sex;
            customer.RoleId = model.RoleId;
            customer.Status = model.Status;
            await _customer.PostCustomer(customer);
            return Ok(customer);
        }
        [HttpPut("Update-Customer")]
        public async Task<ActionResult<Customer>> PutCustomer(CustomerViewModel model)
        {
            Customer customer = await _customer.GetCustomerById(model.Id);
            customer.CustomerCode = model.CustomerCode;
            customer.Name = model.Name;
            customer.UserName = model.UserName;
            customer.Password = model.Password;
            customer.Email = model.Email;
            customer.NumberPhone = model.NumberPhone;
            customer.Address = model.Address;
            customer.Sex = model.Sex;
            customer.RoleId = model.RoleId;
            customer.Status = model.Status;
            await _customer.PutCustomer(customer);
            return Ok(customer);
        }
        [HttpDelete("Id")]
        public async Task<ActionResult<Customer>> DeleteCus(Guid Id)
        {
            await _customer.DeleteCustomer(Id);
            return Ok();
        }
    }
}
