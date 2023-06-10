using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class ComboDetailsServices : IComBoDetailsServices
    {
        private readonly MyDbContext _context;
        public ComboDetailsServices(MyDbContext context)
        {
                _context = context; 
        }
        public async Task<ComboDetails> DeleteComboDT(Guid Id)
        {
            var a = await _context.ComboDetails.FirstOrDefaultAsync(x=>x.Id == Id);
            if (a == null) return null;
            _context.ComboDetails.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<IEnumerable<ComboDetails>> GetAllComboDT()
        {
            return await _context.ComboDetails.ToListAsync();
        }

        public async Task<ComboDetails> GetComboDTById(Guid Id)
        {
            return await _context.ComboDetails.FindAsync(Id);
        }

        public Task<IEnumerable<ComboDetails>> GetComboDTByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<ComboDetails> PostComboDT(ComboDetails combodt)
        {
            _context.ComboDetails.Add(combodt);
            await _context.SaveChangesAsync();
            return combodt;
        }

        public async Task<ComboDetails> PutComboDT(ComboDetails combodt)
        {
            var s = await _context.ComboDetails.FindAsync(combodt.Id);
            if (s == null) return s;
            s.ComboId = combodt.ComboId;
            s.ProductsDetailsId = combodt.ProductsDetailsId;    
            s.Quantity = combodt.Quantity;
            _context.ComboDetails.Update(s);
            await _context.SaveChangesAsync();  
            return combodt;

        }
    }
}
