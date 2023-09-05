using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.Users;
using Facebook.Tables;
using FirstApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Facebook.Controllers
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

        [HttpPost("Register")]
        public async Task<IActionResult> Post(UserRequestModel m)
        {
            if (m.Password != m.ConfirmPassword)
                return BadRequest("Password Not Matched");

            var user = await _userService.AddUser(m);
            return Ok(user);
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> Auth(AuthModel m)
        {
            var user = await _userService.GetUser(m);
            if (user == null)
                return BadRequest("User Not Found");

            if (!BCrypt.Net.BCrypt.Verify(m.Password, user.Password))
            {
                return BadRequest("Wrong password.");
            }
            var token = _userService.CreateToken(user);
            return Ok(token);

        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            var updatedUser = await _userService.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var deletedUser = await _userService.DeleteUser(id);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser);
        }
    }
}
