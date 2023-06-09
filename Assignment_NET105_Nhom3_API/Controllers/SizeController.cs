using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/Size")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        [HttpGet]
        public async Task<ActionResult<Size>> GetAllSize()
        {
            var size = await _sizeService.GetAllSize(); 
            return Ok(size);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<Size>> GetSizeById(Guid Id)
        {
            var x = await _sizeService.GetSizeById(Id);
            return Ok(x);
        }
        [HttpPost("add")]
        public async Task<ActionResult<Size>> PostSize (SizeViewModel szvm)
        {
            Size size = new Size();
            size.Id = Guid.NewGuid();
            size.Name = szvm.Name;
            size.Status = szvm.Status;
            await _sizeService.PostSize(size);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<ActionResult<Size>> PutSize (SizeViewModel szvmv)
        {
            Size size = await _sizeService.GetSizeById(szvmv.Id);
            size.Name = szvmv.Name;
            size.Status = szvmv.Status;
            await _sizeService.PutSize(size);
            return Ok();
        }
        [HttpDelete("Id")]
        public async Task<ActionResult<Size>> Delete(Guid id)
        {
            await _sizeService.DeleteSize(id);
            return Ok();
        }

    }
}
