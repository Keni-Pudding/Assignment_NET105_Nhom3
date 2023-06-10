using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IBillServices
    {
        public Task<Bill> AddBill(Bill bill);
        public Task<Bill> Update(Bill bill);
        public Task<Bill> Delete(Bill bill);
        public Task<List<Bill>> GetAllBill();
        public Task<Bill> GetBillById(Guid Id);
        public Task<List<Bill>> GetBillByName(string Name);
        public Task<List<BillViewModel_Show>> GetBillViewShowModels();

    }
}
