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
        private readonly MyDbContext _context = new MyDbContext();
        private readonly IBillServices _billServices;
        public BillControllers(IBillServices billServices)
        {
            _billServices = billServices;
        }

        [HttpGet("get-all")]
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
            _context.Bill.Add(bill1);
            await _context.SaveChangesAsync();
            return Ok(bill);
        }
        [HttpPut("update_bill")]
        public async Task<ActionResult<Bill>> UpdateBill(Bill bill)
        {
            var a = await _billServices.GetBillById(bill.Id);
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

        [HttpPost]
        public async Task<ActionResult> AddCombo([FromBody] Color color)
        {
            _context.Color.Add(color);
            await _context.SaveChangesAsync();
            return Ok("ối dồi ôi ");
        }


    }
}
