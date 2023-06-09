using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _role;
        public RoleController(IRoleServices role)
        {
            _role = role; 
        }

        [HttpGet]
        public async Task<ActionResult<Role>> GetAllRole()
        {
            var role = await _role.GetAllRole();
            return Ok(role);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<Role>> GetRoleById(Guid Id)
        {
            var x = await _role.GetRoleById(Id);
            return Ok(x);
        }
        [HttpPost("add")]
        public async Task<ActionResult<Role>> PostRole(RoleViewModel rvm)
        {
            Role role = new Role();
            role.Id = Guid.NewGuid();
            role.RoleName = rvm.RoleName;
            role.Status = rvm.Status;
            await _role.PostRole(role);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<ActionResult<Role>> PutRole(RoleViewModel rvm)
        {
            Role role = await _role.GetRoleById(rvm.Id);
            role.RoleName = rvm.RoleName;
            role.Status = rvm.Status;
            await _role.PutRole(role);
            return Ok();
        }
        [HttpDelete("Id")]
        public async Task<ActionResult<Role>> Delete(Guid id)
        {
            await _role.DeleteRole(id);
            return Ok();
        }
    }
}
