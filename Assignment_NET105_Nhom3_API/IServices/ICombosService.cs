using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface ICombosService
    {
        public Task<IEnumerable<Combos>> GetAllCombos();
        public Task<Combos> PostCombos(Combos combos);
        public Task<Combos> PutCombos(Combos combos);
        public Task<Combos> DeleteCombos(Guid Id);
        public Task<Combos> GetCombosById(Guid Id);
        public Task<IEnumerable<Combos>> GetCombosByName(string Name);
    }
}
