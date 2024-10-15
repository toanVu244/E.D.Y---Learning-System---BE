using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        // GET: api/Lesson
        [HttpGet]
        public async Task<IActionResult> GetLessons()
        {
            var lessons = await _lessonService.GetAllLessonsAsync();
            if (lessons == null)
                return NotFound();

            return Ok(lessons);
        }

        // GET: api/Lesson/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonByID(int id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null)
                return NotFound();

            return Ok(lesson);
        }

        // POST: api/Lesson
        [HttpPost]
        public async Task<IActionResult> AddLesson(LessonViewModel lesson)
        {
            var result = await _lessonService.CreateLessonAsync(lesson);
            if (!result)
                return BadRequest("Failed to create lesson");

            return Ok("Lesson created successfully");
        }

        // PUT: api/Lesson/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(LessonViewModel lesson)
        {
            var result = await _lessonService.UpdateLessonAsync(lesson);
            if (!result)
                return NotFound("Lesson not found");

            return Ok("Lesson updated successfully");
        }

        // DELETE: api/Lesson/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var result = await _lessonService.DeleteLessonAsync(id);
            if (!result)
                return NotFound("Lesson not found");

            return Ok("Lesson deleted successfully");
        }
    }
}
