using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class ColorServices : IColorServices
    {
        private readonly MyDbContext _context;
        public ColorServices(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Color> Add(Color color)
        {
             _context.Color.Add(color);
            await _context.SaveChangesAsync();
            return color;
        }

        public async Task<Color> Delete(Guid Id)
        {
            var dte = await _context.Color.FirstOrDefaultAsync(p => p.Id == Id);
            if (dte == null) return null;
            _context.Remove(dte);
            _context.SaveChangesAsync();
            return dte;
        }

        public async Task<IEnumerable<Color>> GetAllColor()
        {
            return await _context.Color.ToListAsync();
        }

        public async Task<Color> GetColorById(Guid Id)
        {
            return await _context.Color.FindAsync(Id);
        }

        public Task<IEnumerable<Color>> GetColorByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<Color> Update(Color color)
        {
            var a = await _context.Color.FindAsync(color.Id);
            if (a == null) return null;
            a.Name = color.Name;
            a.Status = color.Status;
            //_context.Color.Update(a);
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
