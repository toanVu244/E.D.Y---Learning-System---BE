using BusinessObject.Entities;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
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

        [HttpPost("add-achivement")]
        public async Task<IActionResult> AddAchivement(AchivementViewModel achivement)
        {
            try
            {
                var result = await _achivementService.CreateAchivementAsync(achivement);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Create Achivement Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("edit-achivement")]
        public async Task<IActionResult> UpdateAchivement(AchivementViewModel achivement)
        {
            try
            {
                var result = await _achivementService.UpdateAchivementAsync(achivement);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Update Achivement Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete-achivement")]
        public async Task<IActionResult> DeleteAchivement(int id)
        {
            try
            {
                var result = await _achivementService.DeleteAchivementAsync(id);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Delete Achivement Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
