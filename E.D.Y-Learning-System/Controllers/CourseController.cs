using BusinessObject.Models;
using E.D.Y_Serivce.Implementations;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        // GET: api/<CourseController>
        [HttpGet("all-course")]
        public async Task<IActionResult> GetCourses()
        {
            var users = await _courseService.GetAllCourseAsync();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        // GET api/<CourseController>/5
        [HttpGet("get-course-by-id")]
        public async Task<IActionResult> GetCourseByID(int id)
        {
            try
            {
                var users = await _courseService.GetCourseByIdAsync(id);
                if (users == null)
                    return NotFound();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CourseController>
        [HttpPost("add-course")]
        public async Task<IActionResult> AddCourse(CourseViewModel course)
        {
            try
            {
                var result = await _courseService.CreateCourseAsync(course);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Create Course Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CourseController>/5
        [HttpPut("update-course")]
        public async Task<IActionResult> UpdateCourse(CourseViewModel Course)
        {
            try
            {
                var result = await _courseService.UpdateCourseAsync(Course);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Update Course Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("delete-course")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var result = await _courseService.GetCourseByIdAsync(id);
                return Ok("Delete Course Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
