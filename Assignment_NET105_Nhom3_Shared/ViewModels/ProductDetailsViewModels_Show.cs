using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105_Nhom3_Shared.ViewModels
{
    public class ProductDetailsViewModels_Show
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? SizeId { get; set; }
        public Guid? ColorId { get; set; }
        public int AvaiableQuatity { get; set; }
        public int Status { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
