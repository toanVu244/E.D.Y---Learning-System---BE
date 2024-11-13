using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _FeedbackService;
        public FeedbackController(IFeedbackService FeedbackService)
        {
            _FeedbackService = FeedbackService;
        }

        // GET: api/<FeedbackController>
        [HttpGet("all-Feedback")]
        public async Task<IActionResult> GetFeedbacks()
        {
            var users = await _FeedbackService.GetAllFeedbackAsync();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        // GET api/<FeedbackController>/5
        [HttpGet("get-Feedback-by-id")]
        public async Task<IActionResult> GetFeedbackByID(int id)
        {
            try
            {
                var users = await _FeedbackService.GetFeedbackByIdAsync(id);
                if (users == null)
                    return NotFound();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<FeedbackController>
        [HttpPost("add-Feedback")]
        public async Task<IActionResult> AddFeedback(FeedbackViewModel Feedback)
        {
            try
            {
                var result = await _FeedbackService.CreateFeedbackAsync(Feedback);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Create Feedback Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FeedbackController>/5
        [HttpPut("update-Feedback")]
        public async Task<IActionResult> UpdateFeedback(FeedbackViewModel Feedback)
        {
            try
            {
                var result = await _FeedbackService.UpdateFeedbackAsync(Feedback);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Update Feedback Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FeedbackController>/5
        [HttpDelete("delete-Feedback")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                var result = await _FeedbackService.GetFeedbackByIdAsync(id);
                return Ok("Delete Feedback Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
