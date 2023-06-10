using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface ICategoryServices
    {
        public Task<IEnumerable<Category>> GetAllCategory();
        public Task<Category> PostCategory(Category category);
        public Task<Category> PutCategory(Category category);
        public Task<Category> DeleteCategory(Guid Id);
        public Task<Category> GetCategoryById(Guid Id);
        public Task<IEnumerable<Category>> GetCategoryByName(string Name);
    }
}
