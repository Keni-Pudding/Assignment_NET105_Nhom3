using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105_Nhom3_Shared.ViewModels
{
    public class ComBoDetailsViewModel
    {
        public Guid Id { get; set; }
        public Guid ComboId { get; set; }
        public Guid ProductsDetailsId { get; set; }
        public int Quantity { get; set; }
    }
}
