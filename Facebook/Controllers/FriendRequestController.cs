using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.FriendRequests;
using Facebook.Tables;
using Microsoft.AspNetCore.Authorization;


namespace Facebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]

    public class FriendRequestController : ControllerBase
    {
        private readonly IFriendRequestService _friendRequestService;

        public FriendRequestController(IFriendRequestService friendRequestService)
        {
            _friendRequestService = friendRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FriendRequest>>> GetAllFriendRequests()
        {
            var friendRequests = await _friendRequestService.GetAllFriendRequests();
            return Ok(friendRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FriendRequest>> GetFriendRequestById(int id)
        {
            var friendRequest = await _friendRequestService.GetFriendRequestById(id);
            if (friendRequest == null)
            {
                return NotFound();
            }
            return Ok(friendRequest);
        }

        [HttpPost]
        public async Task<ActionResult<FriendRequest>> AddFriendRequest(FriendRequest friendRequest)
        {
            var newFriendRequest = await _friendRequestService.AddFriendRequest(friendRequest);
            return CreatedAtAction(nameof(GetFriendRequestById), new { id = newFriendRequest.FriendRequestId }, newFriendRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FriendRequest>> UpdateFriendRequest(int id, FriendRequest friendRequest)
        {
            var updatedFriendRequest = await _friendRequestService.UpdateFriendRequest(id, friendRequest);
            if (updatedFriendRequest == null)
            {
                return NotFound();
            }
            return Ok(updatedFriendRequest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FriendRequest>> DeleteFriendRequest(int id)
        {
            var deletedFriendRequest = await _friendRequestService.DeleteFriendRequest(id);
            if (deletedFriendRequest == null)
            {
                return NotFound();
            }
            return Ok(deletedFriendRequest);
        }
    }
}
