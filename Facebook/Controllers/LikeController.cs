using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.Likes;
using Facebook.Tables;
using Microsoft.AspNetCore.Authorization;

namespace Facebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]

    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Like>>> GetAllLikes()
        {
            var likes = await _likeService.GetAllLikes();
            return Ok(likes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Like>> GetLikeById(int id)
        {
            var like = await _likeService.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }
            return Ok(like);
        }

        [HttpPost]
        public async Task<ActionResult<Like>> AddLike(Like like)
        {
            var newLike = await _likeService.AddLike(like);
            return CreatedAtAction(nameof(GetLikeById), new { id = newLike.LikeId }, newLike);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Like>> UpdateLike(int id, Like like)
        {
            var updatedLike = await _likeService.UpdateLike(id, like);
            if (updatedLike == null)
            {
                return NotFound();
            }
            return Ok(updatedLike);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Like>> DeleteLike(int id)
        {
            var deletedLike = await _likeService.DeleteLike(id);
            if (deletedLike == null)
            {
                return NotFound();
            }
            return Ok(deletedLike);
        }
    }
}
