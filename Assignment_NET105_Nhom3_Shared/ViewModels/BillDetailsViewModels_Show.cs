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
        public Guid? ProductDetailsId { get; set; }
        public Guid? ComboId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
