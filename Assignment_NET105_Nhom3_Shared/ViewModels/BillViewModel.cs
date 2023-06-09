using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105_Nhom3_Shared.ViewModels
{
    public class BillViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Status { get; set; }
    }
}
