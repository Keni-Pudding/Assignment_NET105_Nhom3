using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105_Nhom3_Shared.ViewModels
{
    public class CartDetailsViewModels
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? ProductDetailId { get; set; }
        public Guid? ComboId { get; set; }
       


        public string ProductName { get; set; }
        public string SizeName { get; set; }
        public string Image { get; set; }
        public string ColorName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
