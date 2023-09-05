using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.Friendships;
using Facebook.Tables;
using Microsoft.AspNetCore.Authorization;

namespace Facebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]

    public class FriendshipController : ControllerBase
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipController(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FreindShip>>> GetAllFriendships()
        {
            var friendships = await _friendshipService.GetAllFriendships();
            return Ok(friendships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FreindShip>> GetFriendshipById(int id)
        {
            var friendship = await _friendshipService.GetFriendshipById(id);
            if (friendship == null)
            {
                return NotFound();
            }
            return Ok(friendship);
        }

        [HttpPost]
        public async Task<ActionResult<FreindShip>> AddFriendship(FreindShip friendship)
        {
            var newFriendship = await _friendshipService.AddFriendship(friendship);
            return CreatedAtAction(nameof(GetFriendshipById), new { id = newFriendship.FriendshipId }, newFriendship);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FreindShip>> UpdateFriendship(int id, FreindShip friendship)
        {
            var updatedFriendship = await _friendshipService.UpdateFriendship(id, friendship);
            if (updatedFriendship == null)
            {
                return NotFound();
            }
            return Ok(updatedFriendship);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FreindShip>> DeleteFriendship(int id)
        {
            var deletedFriendship = await _friendshipService.DeleteFriendship(id);
            if (deletedFriendship == null)
            {
                return NotFound();
            }
            return Ok(deletedFriendship);
        }
    }
}
