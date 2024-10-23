using BusinessObject.Entities;
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
        private readonly ICourseService _CourseService;
        private readonly IPaymentService _PaymentService;

        public  UserCourseController(IUserCourseService UserCourseService, ICourseService courseService, IPaymentService paymentService)
        {
            _UserCourseService = UserCourseService;
            _CourseService = courseService;
            _PaymentService = paymentService;
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

        [HttpGet("get-UserCourses-byUID")]
        public async Task<IActionResult> GetAllUserCourseByUIDAsync(string uid)
        {
            try
            {
                var UserCourses = await _UserCourseService.GetUserCoursesByUIdAsync(uid);
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

        [HttpPost("add-UserToCourse")]
        public async Task<IActionResult> AddUserToCourse(int Courseid,string UserID)
        {
            try
            {
                CourseViewModel course = await _CourseService.GetCourseByIdAsync(Courseid);
                UserCourseViewModel userCourse = new UserCourseViewModel()
                {
                    CourseId = course.CourseId,
                    UserId = UserID,
                    Certificate = true,
                    EnrollDate = DateTime.Now
                };
                PaymentViewModel payment = new PaymentViewModel()
                {
                    UserId = UserID,
                    Title = "Buy Course " + course.Name + " Successfully",
                    Date = DateTime.Now,
                    Money = (double)course.Money
                };
                var paymentResult = await _PaymentService.CreatePaymentAsync(payment);
                if (paymentResult)
                {
                    var result = await _UserCourseService.CreateUserCourseAsync(userCourse);
                    if (result == true)
                    {
                        return Ok("Successfully payment. Add User to Course Successfully");
                        
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-UserNewCourse")]
        public async Task<IActionResult> AddUserNewCourse(UserCourseViewModel UserCourse)
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
