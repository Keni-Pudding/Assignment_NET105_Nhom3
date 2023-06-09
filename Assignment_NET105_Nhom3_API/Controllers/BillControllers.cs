using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_Shared.ViewModels;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/bill")]
    [ApiController]

    public class BillControllers : ControllerBase
    {
        private readonly IBillServices _billServices;
        private readonly IBillDetailServices _billDetailServices;   
        public BillControllers(IBillServices billServices, IBillDetailServices billDetailServices)
        {
            _billServices = billServices;
            _billDetailServices = billDetailServices;
        }

        [HttpGet("get-all-bill")]
        public async Task<IActionResult> GetAllBill()
        {
            var a = await _billServices.GetAllBill();
            return Ok(a);
        }

        [HttpPost("add_bill")]
        public async Task<ActionResult<BillViewModel>> AddBill(BillViewModel bill)
        {
            Bill bill1 =new Bill();
            bill1.Id=Guid.NewGuid(); 
            bill1.Status = bill.Status;
            bill1.CreatedDate= DateTime.Now;
            bill1.UserId = Guid.Parse("f9a991b2-c9cf-4ef6-9aec-90235617bce6");

            await _billServices.AddBill(bill1);
            return Ok(bill1);
        }
        [HttpPut("update_bill")]
        public async Task<ActionResult<BillViewModel>> UpdateBill(BillViewModel bill)
        {
            var a = await _billServices.GetBillById(bill.Id); 
            a.Status = bill.Status;
            a.CreatedDate = DateTime.Now;
            await _billServices.Update(a);
            return Ok(a);
        }
        [HttpDelete("delete_bill")]
        public async Task<ActionResult<Bill>> DeleteBill(Guid Id)
        {
            var a = await _billServices.GetBillById(Id);
            await _billServices.Delete(a);
            return Ok(a);
        }







        [HttpGet("get-all-billdetails")]
        public async Task<IActionResult> GetAllBillDetails()
        {
            var a = await _billDetailServices.GetAllBillDetail();
            return Ok(a);
        }

        [HttpPost("add-billdetails")]
        public async Task<ActionResult<BillDetailsViewModels>> AddBillDetails(BillDetailsViewModels bill)
        {
            BillDetails bill1 = new BillDetails();
            bill1.Id = Guid.NewGuid();
            bill1.BillId = bill.Id;
            if (bill.ComboId == Guid.Empty)
            {
                bill1.ProductDetailsId = bill.ProductDetailsId;
            }
            else
            {
                bill1.ComboId = bill.ComboId;
            }                  
            bill1.Price = bill.Price;
            bill1.Quantity  = bill.Quantity;
            await _billDetailServices.Add(bill1);
            return Ok(bill1);
        }

        [HttpPost("update-billdetails")]
        public async Task<ActionResult<BillDetailsViewModels>> UpdateBillDetails(BillDetailsViewModels bill)
        {
            BillDetails bill1 = new BillDetails();
            bill1.Id = Guid.NewGuid();
            bill1.BillId = bill.Id;
            if (bill.ComboId == Guid.Empty)
            {
                bill1.ProductDetailsId = bill.ProductDetailsId;
            }
            else
            {
                bill1.ComboId = bill.ComboId;
            }
            bill1.Price = bill.Price;
            bill1.Quantity = bill.Quantity;
            await _billDetailServices.Add(bill1);
            return Ok(bill1);
        }




    }
}
