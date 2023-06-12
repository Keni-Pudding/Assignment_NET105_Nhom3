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
                var a =await _context.BillDetails.AddAsync(billDetails);
                 var b=await _context.SaveChangesAsync();
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
            var a= await _context.BillDetails.FirstOrDefaultAsync(x=>x.Id==Id);
            return a;
        }

        public async Task<List<BillDetailsViewModels_Show>> GetBillDetailtByBill(Guid Id)
        {
            //var bds = await (from a in _context.BillDetails
            //                 join b in _context.Bill on a.BillId equals b.Id
            //                 join c in _context.Combos on a.ComboId equals c.Id
            //                 join cd in _context.ComboDetails on c.Id equals cd.ComboId
            //                 join pd in _context.ProductDetails on cd.ProductsDetailsId equals pd.Id into pdj
            //                 from pd in pdj.DefaultIfEmpty()
            //                 join p in _context.Products on pd.ProductId equals p.Id into pj
            //                 from p in pj.DefaultIfEmpty()
            //                 join s in _context.Size on pd.SizeId equals s.Id into sj
            //                 from s in sj.DefaultIfEmpty()
            //                 join cl in _context.Color on pd.ColorId equals cl.Id into clj
            //                 from cl in clj.DefaultIfEmpty()
            //                 select new BillDetailsViewModels_Show
            //                 {
            //                     Id = a.Id,
            //                     BillId = a.BillId,
            //                     ProductName = p.Name,
            //                     Image = p.Image,
            //                     ComboName = c.Name,
            //                     Size = s.Name,
            //                     Color = cl.Name,
            //                     Quantity = a.Quantity,
            //                     Price = p.Price * a.Quantity
            //                 }).Where(a => a.BillId == Id).ToListAsync();
            //return bds;

            var bds = await (from a in _context.BillDetails
                             join b in _context.Bill on a.BillId equals b.Id
                             join c in _context.ProductDetails on a.ProductDetailsId equals c.Id
                             join d in _context.Products on c.ProductId equals d.Id
                             join e in _context.Size on c.SizeId equals e.Id
                             join f in _context.Color on c.ColorId equals f.Id
                             select new BillDetailsViewModels_Show
                             {
                                 Id=a.Id,
                                 BillId=a.BillId,
                                 //UserId=b.UserId,
                                 ProductName=d.Name,
                                 Image=d.Image,
                                 Size=e.Name,
                                 Color=f.Name,
                                 Quantity=a.Quantity,
                                 Price=d.Price*a.Quantity,
                             }).Where(a => a.BillId == Id).ToListAsync();
            return bds;
        }

        public async Task<List<BillDetails>> GetBillDetailtByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<List<BillDetails>> GetBillDetailtByUser(Guid UserId)
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
