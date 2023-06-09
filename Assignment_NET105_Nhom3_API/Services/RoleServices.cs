using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly MyDbContext _context;
        public RoleServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Role> DeleteRole(Guid Id)
        {
            var dte = await _context.Role.FirstOrDefaultAsync(p => p.Id == Id);
            if (dte == null) return null;
            _context.Remove(dte);
            _context.SaveChangesAsync();
            return dte;
        }

        public async Task<IEnumerable<Role>> GetAllRole()
        {
            return await _context.Role.ToListAsync();
        }

        public async Task<Role> GetRoleById(Guid Id)
        {
            return await _context.Role.FindAsync(Id);
        }

        public Task<IEnumerable<Role>> GetRoleByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> PostRole(Role role)
        {
            _context.Role.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> PutRole(Role role)
        {
            var a = await _context.Role.FindAsync(role.Id);
            if (a == null) return null;
            a.RoleName = role.RoleName;
            a.Status = role.Status;
            //_context.Color.Update(a);
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
