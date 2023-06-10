using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/ComBoDetails")]
    [ApiController]
    public class ComBoDetailsController : ControllerBase
    {
        private readonly IComBoDetailsServices _combodt;
        public ComBoDetailsController(IComBoDetailsServices combodt)
        {
            _combodt = combodt;
        }
        [HttpGet]
        public async Task<ActionResult<ComboDetails>> GetAllCmDetails()
        {
            var a = await _combodt.GetAllComboDT();
            return Ok(a);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<ComboDetails>> GetAllComBoDT(Guid Id)
        {
            var c = await _combodt.GetComboDTById(Id);
            return Ok(c);
        }
        [HttpPost]
        public async Task<ActionResult<ComboDetails>> PostCBDT(ComBoDetailsViewModel cmvm)
        {
            ComboDetails cmdt = new ComboDetails();
            cmdt.Id = Guid.NewGuid();
            cmdt.ComboId = cmvm.ComboId;
            cmdt.ProductsDetailsId = cmvm.ProductsDetailsId;
            cmdt.Quantity = cmvm.Quantity;
            await _combodt.PostComboDT(cmdt);   
            return Ok(cmvm);
        }
        [HttpPut("Id")]
        public async Task<ActionResult<ComboDetails>> PutCBDT(ComBoDetailsViewModel cmvm)
        {
            ComboDetails cmdt = await _combodt.GetComboDTById(cmvm.Id);
            cmdt.ComboId = cmvm.ComboId;
            cmdt.ProductsDetailsId = cmvm.ProductsDetailsId;
            cmdt.Quantity = cmvm.Quantity;
            await _combodt.PutComboDT(cmdt);
            return Ok(cmdt);
        }
        [HttpDelete("Id")]
        public async Task<ActionResult<ComboDetails>> DeleteCMDT (Guid Id)
        {
            await _combodt.DeleteComboDT(Id);
            return Ok();
        }
    }
}
