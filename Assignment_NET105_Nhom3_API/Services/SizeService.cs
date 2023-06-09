using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class SizeService : ISizeService
    {
        private readonly MyDbContext _context;
        public SizeService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Size> DeleteSize(Guid Id)
        {
            var a = await _context.Size.FirstOrDefaultAsync(x => x.Id == Id);
            if (a == null) return a;
             _context.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<IEnumerable<Size>> GetAllSize()
        {
            return await _context.Size.ToListAsync();
        }

        public async Task<Size> GetSizeById(Guid Id)
        {
            return await _context.Size.FindAsync(Id);
        }

        public Task<IEnumerable<Size>> GetSizeByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<Size> PostSize(Size size)
        {
            _context.Size.Add(size);
            await _context.SaveChangesAsync();
            return size;
        }

        public async Task<Size> PutSize(Size size)
        {
            var a = await _context.Size.FindAsync(size.Id);
            if (a == null) return null;
            a.Name = size.Name;
            a.Status = size.Status;
            //_context.Color.Update(a);
            await _context.SaveChangesAsync();
            return a;
        }
    }
    
}
