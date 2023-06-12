using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Microsoft.EntityFrameworkCore;
using Assignment_NET105_Nhom3_Shared.ViewModels;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class BillServices : IBillServices
    {
        private readonly MyDbContext _context;
        public BillServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Bill> AddBill(Bill bill)
        {
            try
            {
                await _context.Bill.AddAsync(bill);
                await _context.SaveChangesAsync();
                return bill;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Bill> Delete(Bill bill)
        {
            try
            {
                var a = await _context.Bill.FindAsync(bill.Id);
                _context.Bill.Remove(a);
                await _context.SaveChangesAsync();
                return a;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<Bill>> GetAllBill()
        {
            return await  _context.Bill.ToListAsync();
        }

        public async Task<Bill> GetBillById(Guid Id)
        {
            var a= await _context.Bill.FindAsync(Id);
            return a;
        }

        public async Task<List<Bill>> GetBillByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BillViewModel_Show>> GetBillViewShowModels()
        {
            var bd = await ( from a in _context.Bill
                     join b in _context.Customer on a.UserId equals b.Id
                     select new BillViewModel_Show()
                     {
                         Id = a.Id,
                         UserId= a.UserId,
                         UserName = b.UserName,
                         CreatedDate= a.CreatedDate,
                         Status= a.Status,

                     }).OrderByDescending(x => x.CreatedDate).ToListAsync();
            return bd;

        }

        public async Task<Bill> Update(Bill bill)
        {
            try
            {
                Bill a = await _context.Bill.FindAsync(bill.Id);
                a.Status = bill.Status;
                a.CreatedDate = bill.CreatedDate;
                _context.Bill.Update(a);
                await _context.SaveChangesAsync();
                return a;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
