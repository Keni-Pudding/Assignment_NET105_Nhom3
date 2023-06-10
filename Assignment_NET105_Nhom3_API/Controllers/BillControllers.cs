using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using System.Web.Http.OData;

namespace Assignment_NET105_Nhom3_API.Controllers  /// ở đây có bill và bill details
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
        [EnableQuery]
        [HttpGet("get-all-bill")]
        public async Task<IActionResult> GetAllBill()
        {
            var a = await _billServices.GetBillViewShowModels();
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
        [HttpGet("get-all-billdetails/{id}")]
        public async Task<IActionResult> GetAllBillDetailsByBill(Guid Id)
        {
            var a = await _billDetailServices.GetBillDetailtByBill(Id);
            return Ok(a);
        }

        [HttpPost("add-billdetails")]
        public async Task<IActionResult> AddBillDetails(BillDetailsViewModels bill)
        {
            BillDetails bill1 = new BillDetails();
            bill1.Id = Guid.NewGuid();
            bill1.BillId = bill.BillId;
            if (bill.ComboId == Guid.Empty || bill.ComboId==null)
            {
                bill1.ProductDetailsId = bill.ProductDetailsId;
                bill1.ComboId = null;
            }
            else
            {
                bill1.ComboId = bill.ComboId;
                bill1.ProductDetailsId = null;
            }                  
            bill1.Price = bill.Price;
            bill1.Quantity  = bill.Quantity;
            var result = await _billDetailServices.Add(bill1);
            return Ok(result);
        }

        [HttpPut("update-billdetails")]
        public async Task<ActionResult<BillDetailsViewModels>> UpdateBillDetails(BillDetailsViewModels bill)
        {
            var a= await _billDetailServices.GetBillDetailById(bill.Id);         
            a.BillId = bill.Id;
            if (bill.ComboId == Guid.Empty)
            {
                a.ProductDetailsId = bill.ProductDetailsId;
            }
            else
            {
                a.ComboId = bill.ComboId;
            }
            a.Price = bill.Price;
            a.Quantity = bill.Quantity;
            await _billDetailServices.Update(a);
            return Ok(a);
        }

        [HttpDelete("delete-billdetails")]
        public async Task<ActionResult> DeleteBillDetails(Guid Id)
        {
            var a = await _billDetailServices.GetBillDetailById(Id);
            await _billDetailServices.Delete(a.Id);          
            return Ok();
        }



    }
}
