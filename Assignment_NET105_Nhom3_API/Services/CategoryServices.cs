using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly MyDbContext _context;
        public CategoryServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Category> DeleteCategory(Guid Id)
        {
            var dte = await _context.Category.FirstOrDefaultAsync(c => c.Id == Id);
            if (dte == null) return null;
            _context.Category.Remove(dte);  
            await _context.SaveChangesAsync();
            return dte;

        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _context.Category.ToListAsync();   
        }

        public async Task<Category> GetCategoryById(Guid Id)
        {
            return await _context.Category.FindAsync(Id);
        }

        public Task<IEnumerable<Category>> GetCategoryByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> PostCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> PutCategory(Category category)
        {
            var a = await _context.Category.FindAsync(category.Id);
            if (a == null) return null;
            a.Name = category.Name;
            a.Status = category.Status;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
