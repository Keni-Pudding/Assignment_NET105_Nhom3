using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IBillDetailServices
    {
        public Task<bool> Add(BillDetails billDetails);
        public Task<bool> Update(BillDetails billDetails);
        public Task<bool> Delete(Guid Id);
        public Task<List<BillDetails>> GetAllBillDetail();
        public Task<BillDetails> GetBillDetailById(Guid Id);
        public Task<List<BillDetails>> GetBillDetailtByUser(Guid UserId);
        public Task<List<BillDetailsViewModels_Show>> GetBillDetailtByBill(Guid Id);


    }
}
