using Assignment_NET105_Nhom3.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IBillServices
    {
        public Task<bool> Add(Bill bill);
        public Task<bool> Update(Bill bill);
        public Task<bool> Delete(Bill bill);
        public Task<List<Bill>> GetAllBill();
        public Task<Bill> GetBillById(Guid Id);
        public Task<List<Bill>> GetBillByName(string Name);
    }
}
