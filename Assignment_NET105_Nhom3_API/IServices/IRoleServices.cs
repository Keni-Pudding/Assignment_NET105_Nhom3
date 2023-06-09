using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IRoleServices
    {
        public Task<IEnumerable<Role>> GetAllRole();
        public Task<Role> PostRole(Role role);
        public Task<Role> PutRole(Role role);
        public Task<Role> DeleteRole(Guid Id);
        public Task<Role> GetRoleById(Guid Id);
        public Task<IEnumerable<Role>> GetRoleByName(string Name);
    }
}
