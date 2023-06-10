using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IComBoDetailsServices
    {
        public Task<IEnumerable<ComboDetails>> GetAllComboDT();
        public Task<ComboDetails> PostComboDT(ComboDetails combodt);
        public Task<ComboDetails> PutComboDT(ComboDetails combodt);
        public Task<ComboDetails> DeleteComboDT(Guid Id);
        public Task<ComboDetails> GetComboDTById(Guid Id);
        public Task<IEnumerable<ComboDetails>> GetComboDTByName(string Name);
    }
}
