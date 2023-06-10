using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105_Nhom3_Shared.ViewModels
{
    public class BillDetailsViewModels_Show
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public string? ProductName { get; set; }
        public string? ComboName { get; set; }
        public string? Image { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
