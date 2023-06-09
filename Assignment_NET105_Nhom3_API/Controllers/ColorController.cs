using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/color")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly MyDbContext _context = new MyDbContext();
        private readonly IColorServices _color;
        public ColorController(IColorServices color)
        {
            _color = color;
        }
        [HttpGet]
        public async Task<ActionResult<Color>> GetAllColor()
        {
            var color = await _color.GetAllColor();
            return Ok(color);
        }
        [HttpPost("add-Color")]
        public async Task<ActionResult<Color>> AddColor(ColorViewModel cl)
        {
            Color color = new Color();
            color.Id = Guid.NewGuid();
            color.Name = cl.Name;
            color.Status = cl.Status;
            await _color.Add(color);
            //await _context.Color.AddAsync(color);
            //_context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("update")]
        public async Task<ActionResult<Color>> Update(ColorViewModel colormd)
        {
            Color color = await _color.GetColorById(colormd.Id);    
            color.Name = colormd.Name;
            color.Status = colormd.Status;
            await _color.Update(color);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Color>> Delete(Guid Id)
        {
            await _color.Delete(Id);
            return Ok();
        }
    }
}
