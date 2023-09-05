using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.UserProfiles;
using Facebook.Tables;
using Microsoft.AspNetCore.Authorization;

namespace Facebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]

    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserProfile>>> GetAllUserProfiles()
        {
            var userProfiles = await _userProfileService.GetAllUserProfiles();
            return Ok(userProfiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetUserProfileById(int id)
        {
            var userProfile = await _userProfileService.GetUserProfileById(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPost]
        public async Task<ActionResult<UserProfile>> AddUserProfile(UserProfile userProfile)
        {
            var newUserProfile = await _userProfileService.AddUserProfile(userProfile);
            return CreatedAtAction(nameof(GetUserProfileById), new { id = newUserProfile.UserProfileId }, newUserProfile);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserProfile>> UpdateUserProfile(int id, UserProfile userProfile)
        {
            var updatedUserProfile = await _userProfileService.UpdateUserProfile(id, userProfile);
            if (updatedUserProfile == null)
            {
                return NotFound();
            }
            return Ok(updatedUserProfile);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserProfile>> DeleteUserProfile(int id)
        {
            var deletedUserProfile = await _userProfileService.DeleteUserProfile(id);
            if (deletedUserProfile == null)
            {
                return NotFound();
            }
            return Ok(deletedUserProfile);
        }
    }
}
