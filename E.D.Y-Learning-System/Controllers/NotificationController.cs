using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/<NotificationController>
        [HttpGet("all-Notification")]
        public async Task<IActionResult> GetNotifications()
        {
            var users = await _notificationService.GetAllNotificationAsync();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        // GET api/<NotificationController>/5
        [HttpGet("get-Notification-by-id")]
        public async Task<IActionResult> GetNotificationByID(int id)
        {
            try
            {
                var users = await _notificationService.GetNotificationByIdAsync(id);
                if (users == null)
                    return NotFound();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<NotificationController>
        [HttpPost("add-Notification")]
        public async Task<IActionResult> AddNotification(NotificationViewModel Notification)
        {
            try
            {
                var result = await _notificationService.CreateNotificationAsync(Notification);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Create Notification Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<NotificationController>/5
        [HttpPut("update-Notification")]
        public async Task<IActionResult> UpdateNotification(NotificationViewModel Notification)
        {
            try
            {
                var result = await _notificationService.UpdateNotificationAsync(Notification);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Update Notification Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("delete-Notification")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            try
            {
                var result = await _notificationService.GetNotificationByIdAsync(id);
                return Ok("Delete Notification Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
