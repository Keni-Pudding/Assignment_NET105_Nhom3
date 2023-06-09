using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;


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

        public async Task<BillDetails> GetBillDetailById(Guid Id)
        {
            return await _context.BillDetails.FindAsync(Id);
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
