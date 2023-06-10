using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _cate;
        public CategoryController(ICategoryServices category)
        {
            _cate = category;
        }
        [HttpGet]
        public async Task<ActionResult<Category>> GetAll()
        {
             var cte = await _cate.GetAllCategory();
             return Ok(cte);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<Category>> GetCateById(Guid Id)
        {
            var cte = await _cate.GetCategoryById(Id);
            return Ok(cte);
        }
        [HttpPost("Add-Category")]
        public async Task<ActionResult<Category>> PostCategory(CategoryViewModel catevm)
        {
            Category cate = new Category();
            cate.Id = Guid.NewGuid();
            cate.Name = catevm.Name;
            cate.Status = catevm.Status;
            await _cate.PostCategory(cate);
            return Ok(cate);
        }
        [HttpPut("Update-Category")]
        public async Task<ActionResult<Category>> PutCategory(CategoryViewModel catevm)
        {
            Category cate = await _cate.GetCategoryById(catevm.Id);
            cate.Name = catevm.Name;
            cate.Status = catevm.Status;
            await _cate.PutCategory(cate);
            return Ok();
        }
        [HttpDelete("Id")]
        public async Task<ActionResult<Category>> DeleteCate(Guid id)
        {
            await _cate.DeleteCategory(id);
            return Ok();
        }
    }
}
