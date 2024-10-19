using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _UserCourseService;

        public  UserCourseController(IUserCourseService UserCourseService)
        {
            _UserCourseService = UserCourseService;
        }

        [HttpGet("get-all-UserCourse")]
        public async Task<IActionResult> GetAllUserCourseAsync()
        {
            try
            {
                var UserCourses = await _UserCourseService.GetAllUserCoursesAsync();
                if (UserCourses == null || UserCourses.Count == 0)
                {
                    return NotFound();
                }
                return Ok(UserCourses);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-UserCourse")]
        public async Task<IActionResult> AddUserCourse(UserCourseViewModel UserCourse)
        {
            try
            {
                var result = await _UserCourseService.CreateUserCourseAsync(UserCourse);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Create UserCourse Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("edit-UserCourse")]
        public async Task<IActionResult> UpdateUserCourse(UserCourseViewModel UserCourse)
        {
            try
            {
                var result = await _UserCourseService.UpdateUserCourseAsync(UserCourse);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Update UserCourse Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete-UserCourse")]
        public async Task<IActionResult> DeleteUserCourse(int id)
        {
            try
            {
                var result = await _UserCourseService.DeleteUserCourseAsync(id);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Delete UserCourse Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
