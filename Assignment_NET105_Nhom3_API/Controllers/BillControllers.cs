using Assignment_NET105_Nhom3.Models;
using Assignment_NET105_Nhom3_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/bill")]
    [ApiController]
    
    public class BillControllers : ControllerBase
    {
        private readonly IBillServices _billServices;
        public BillControllers(IBillServices billServices)
        {
            _billServices = billServices;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Bill>> GetAllBill()
        {
            var a= await _billServices.GetAllBill();
            return Ok(a);
        }

        [HttpPost("add_bill")]
        public async Task<ActionResult<Bill>> AddBill(Bill bill)
        {
            await _billServices.Add(bill);
            return Ok(bill);
        }
        [HttpPut("update_bill")]
        public async Task<ActionResult<Bill>> UpdateBill(Bill bill)
        {
            var a= await _billServices.GetBillById(bill.Id);
            await _billServices.Update(a);
            return Ok(bill);
        }
        [HttpDelete("delete_bill")]
        public async Task<ActionResult<Bill>> DeleteBill(Guid Id)
        {
            var a = await _billServices.GetBillById(Id);
            await _billServices.Delete(a);
            return Ok(a);
        }


    }
}
