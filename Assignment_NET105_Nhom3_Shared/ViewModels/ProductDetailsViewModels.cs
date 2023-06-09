using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105_Nhom3_Shared.ViewModels
{
    public class ProductDetailsViewModels
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? SizeId { get; set; }
        public Guid? ColorId { get; set; }
        public int AvaiableQuatity { get; set; }
        public int Status { get; set; }
    }
}
