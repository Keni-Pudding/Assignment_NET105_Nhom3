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
        private readonly ICustomerService _customerService;
        public BillControllers(IBillServices billServices, IBillDetailServices billDetailServices, ICustomerService customerService)
        {
            _billServices = billServices;
            _billDetailServices = billDetailServices;
            _customerService = customerService;
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
            bill1.Id=bill.Id;
            bill1.Status = bill.Status;
            bill1.CreatedDate= DateTime.Now;
            bill1.UserId = bill.UserId;

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

            bill1.Id = bill.Id;
            bill1.BillId = bill.BillId;
            //bill1.BillId = Guid.Parse("47620022-9139-4A6A-A10F-1669013817F2");                  
            bill1.ProductDetailsId = bill.ProductDetailsId;
            bill1.ComboId = Guid.Parse("1C43986F-8438-4D0E-81CC-7DFE1434DC12");
            bill1.Price = bill.Price;
            bill1.Quantity  = bill.Quantity;
            var result = await _billDetailServices.Add(bill1);
            return Ok(result);
        }

        [HttpPut("update-billdetails")]
        public async Task<ActionResult<BillDetailsViewModels>> UpdateBillDetails(BillDetailsViewModels bill)
        {
            var a= await _billDetailServices.GetBillDetailById(bill.Id);         
            
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


        [HttpGet("get_all_Customer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var a= await _customerService.GetAllCustomer();
            return Ok(a);
        }


    }
}
