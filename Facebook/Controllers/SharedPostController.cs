using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.SharedPosts;
using Facebook.Tables;
using Microsoft.AspNetCore.Authorization;

namespace Facebook.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]

    public class SharedPostController : ControllerBase
    {
        private readonly ISharedPostService _sharedPostService;

        public SharedPostController(ISharedPostService sharedPostService)
        {
            _sharedPostService = sharedPostService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SharedPost>>> GetAllSharedPosts()
        {
            var sharedPosts = await _sharedPostService.GetAllSharedPosts();
            return Ok(sharedPosts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SharedPost>> GetSharedPostById(int id)
        {
            var sharedPost = await _sharedPostService.GetSharedPostById(id);
            if (sharedPost == null)
            {
                return NotFound();
            }
            return Ok(sharedPost);
        }

        [HttpPost]
        public async Task<ActionResult<SharedPost>> AddSharedPost(SharedPost sharedPost)
        {
            var newSharedPost = await _sharedPostService.AddSharedPost(sharedPost);
            return CreatedAtAction(nameof(GetSharedPostById), new { id = newSharedPost.SharedPostId }, newSharedPost);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SharedPost>> UpdateSharedPost(int id, SharedPost sharedPost)
        {
            var updatedSharedPost = await _sharedPostService.UpdateSharedPost(id, sharedPost);
            if (updatedSharedPost == null)
            {
                return NotFound();
            }
            return Ok(updatedSharedPost);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SharedPost>> DeleteSharedPost(int id)
        {
            var deletedSharedPost = await _sharedPostService.DeleteSharedPost(id);
            if (deletedSharedPost == null)
            {
                return NotFound();
            }
            return Ok(deletedSharedPost);
        }
    }
}
