using Microsoft.AspNetCore.Mvc;
using StatusApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatusApi.Services.Repositories;
using StatusApi.Services.RepositoriesImpl;
using Microsoft.AspNetCore.Authorization;

namespace StatusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userService;

        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
                RestaurantId = userDto.RestaurantId,
                RoleId = userDto.RoleId
            };

            await _userService.AddUserAsync(userDto);
            
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
           if (updatedUser == null || id != updatedUser.Id)
            {
                return BadRequest("Invalid data.");
            }

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            await _userService.UpdateUserAsync(updatedUser);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }


    }

}