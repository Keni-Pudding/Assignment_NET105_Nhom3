
using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IColorServices
    {
        public Task<Color> Add(Color color);
        public Task<Color> Update(Color color);
        public Task<Color> Delete(Guid Id);
        public Task<IEnumerable<Color>> GetAllColor();
        public Task<Color> GetColorById(Guid Id);
        public Task<IEnumerable<Color>> GetColorByName(string Name);
    }
}
