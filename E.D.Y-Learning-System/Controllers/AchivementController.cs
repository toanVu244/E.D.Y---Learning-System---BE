using E.D.Y_Serivce.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchivementController : ControllerBase
    {
        private readonly IAchivementService _achivementService;

        public AchivementController(IAchivementService achivementService)
        {
            _achivementService = achivementService;
        }

        [HttpGet("get-all-Achivement")]
        public async Task<IActionResult> GetAllAchivementAsync()
        {
            try
            {
                var achivements = await _achivementService.GetAllAchivementAsync();
                if (achivements == null || achivements.Count == 0)
                {
                    return NotFound();
                }
                return Ok(achivements);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
