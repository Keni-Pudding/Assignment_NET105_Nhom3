using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class BillDetailServices : IBillDetailServices
    {
        private readonly MyDbContext _context;
        public BillDetailServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(BillDetails billDetails)
        {
            try
            {
                _context.BillDetails.Add(billDetails);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var a = await _context.BillDetails.FindAsync(Id);
                _context.BillDetails.Remove(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<BillDetails>> GetAllBillDetail()
        {
            return _context.BillDetails.ToList();
        }

        public Task<List<BillDetails>> GetAllBillDetail(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BillDetails> GetBillDetailById(Guid Id)
        {
            return await _context.BillDetails.FindAsync(Id);
        }

        public async Task<List<BillDetailsViewModels_Show>> GetBillDetailtByBill(Guid Id)
        {
            var bds = await (from a in _context.BillDetails
                       join b in _context.Bill on a.BillId equals b.Id
                       join c in _context.ProductDetails on a.ProductDetailsId equals c.Id
                       join d in _context.Combos on a.ComboId equals d.Id
                       join e in _context.Products on c.ProductId equals e.Id
                             join f in _context.Size on c.SizeId equals f.Id
                             join g in _context.Color on c.ColorId equals g.Id
                             select new BillDetailsViewModels_Show
                       {
                           Id=a.Id,
                           BillId=a.BillId,
                           ProductName=e.Name,
                           Image = e.Image,
                           ComboName = d.Name,
                           Size = e.Name,
                           Color = g.Name,
                           Quantity = a.Quantity,
                           Price = e.Price * a.Quantity,
                       }).ToListAsync();
            return bds;
        }

        public async Task<List<BillDetails>> GetBillDetailtByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(BillDetails billDetails)
        {
            try
            {
                var a = await _context.BillDetails.FindAsync(billDetails.Id);
                a.Quantity = billDetails.Quantity;
                a.Price = billDetails.Price;
                _context.BillDetails.Update(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
