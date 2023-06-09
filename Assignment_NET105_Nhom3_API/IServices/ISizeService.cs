using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface ISizeService
    {
        public Task<IEnumerable<Size>> GetAllSize();
        public Task<Size> PostSize(Size size);
        public Task<Size> PutSize(Size size);
        public Task<Size> DeleteSize(Guid Id);
        public Task<Size> GetSizeById(Guid Id);
        public Task<IEnumerable<Size>> GetSizeByName(string Name);
    }
}
