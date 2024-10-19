using BusinessObject.Models;
using E.D.Y_Serivce.Implementations;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUserAsync();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRegister newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.CreateUserAsync(newUser);
            if (!result)
                return StatusCode(500, "An error occurred while creating the user.");

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.FullName }, newUser);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("User not found");

            updatedUser.UserId = user.UserId; // Ensure ID consistency
            var result = await _userService.UpdateUserAsync(updatedUser);

            if (!result)
                return StatusCode(500, "An error occurred while updating the user.");

            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return StatusCode(500, "An error occurred while deleting the user.");

            return NoContent();
        }
    }
}
