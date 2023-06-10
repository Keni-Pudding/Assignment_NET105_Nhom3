using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/ComBos")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        private readonly ICombosService _combo;
        public CombosController(ICombosService combo)
        {
                _combo = combo;
        }
        [HttpGet]
        public async Task<ActionResult<Combos>> GetAll()
        {
            var ac = await _combo.GetAllCombos();
            return Ok(ac);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<Combos>> GetComboById(Guid Id)
        {
            var ac = await _combo.GetCombosById(Id);
            return Ok(ac);
        }
        [HttpPost("Add-Combos")]
        public async Task<ActionResult<Combos>> PostCombo(ComBosViewModel cmv)
        {
            Combos combo = new Combos();
            combo.Id = Guid.NewGuid();
            combo.Name = cmv.Name;
            combo.Image = cmv.Image;
            combo.Price = cmv.Price;
            combo.CategoryId = cmv.CategoryId;
            combo.Status = cmv.Status;
            await _combo.PostCombos(combo);
            return Ok(combo);
        }
        [HttpPut("Update-Combos")]
        public async Task<ActionResult<Combos>> PutCombo(ComBosViewModel cmv)
        {
            Combos combo = await _combo.GetCombosById(cmv.Id);
            combo.Name = cmv.Name;
            combo.Image = cmv.Image;
            combo.Price = cmv.Price;
            combo.CategoryId = cmv.CategoryId;
            combo.Status = cmv.Status;
            _combo.PutCombos(combo);
            return Ok(combo);
        }
        [HttpDelete("Id")]
        public async Task<ActionResult<Combos>> Delete(Guid Id)
        {
            await _combo.DeleteCombos(Id);    
            return Ok();
        }
    }
}
