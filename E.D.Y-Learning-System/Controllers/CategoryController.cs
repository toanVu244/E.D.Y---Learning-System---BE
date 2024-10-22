using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet("all-Category")]
        public async Task<IActionResult> GetCategorys()
        {
            var users = await _CategoryService.GetAllCategoryAsync();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        // GET api/<CategoryController>/5
        [HttpGet("get-Category-by-id")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            try
            {
                var users = await _CategoryService.GetCategoryByIdAsync(id);
                if (users == null)
                    return NotFound();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CategoryController>
        [HttpPost("add-Category")]
        public async Task<IActionResult> AddCategory(CategoryViewModel Category)
        {
            try
            {
                var result = await _CategoryService.CreateCategoryAsync(Category);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Create Category Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("update-Category")]
        public async Task<IActionResult> UpdateCategory(CategoryViewModel Category)
        {
            try
            {
                var result = await _CategoryService.UpdateCategoryAsync(Category);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Update Category Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("delete-Category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var result = await _CategoryService.GetCategoryByIdAsync(id);
                return Ok("Delete Category Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
