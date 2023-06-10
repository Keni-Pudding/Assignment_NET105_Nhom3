using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class ComBosService : ICombosService
    {
        private readonly MyDbContext _context;
        public ComBosService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Combos> DeleteCombos(Guid Id)
        {
            var dte = await _context.Combos.FirstOrDefaultAsync(c => c.Id == Id);
            if (dte == null) return null;
            _context.Combos.Remove(dte);
            await _context.SaveChangesAsync();
            return dte;
        }

        public async Task<IEnumerable<Combos>> GetAllCombos()
        {
            return await _context.Combos.ToListAsync();
        }

        public async Task<Combos> GetCombosById(Guid Id)
        {
            return await _context.Combos.FindAsync(Id);
        }

        public Task<IEnumerable<Combos>> GetCombosByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<Combos> PostCombos(Combos combos)
        {
            _context.Combos.Add(combos);
            await _context.SaveChangesAsync();
            return combos;
        }

        public async Task<Combos> PutCombos(Combos combos)
        {
            var cb = await _context.Combos.FindAsync(combos.Id);
            if (cb == null) return null;
            cb.Name = combos.Name;
            cb.Image = combos.Image;
            cb.Price = combos.Price;
            cb.CategoryId = combos.CategoryId;
            cb.Status = combos.Status;
            await _context.SaveChangesAsync();
            return cb;
        }
    }
}
