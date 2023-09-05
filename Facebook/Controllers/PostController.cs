using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.Posts;
using Facebook.Tables;
using Microsoft.AspNetCore.Authorization;

namespace Facebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(Post post)
        {
            var newPost = await _postService.AddPost(post);
            return CreatedAtAction(nameof(GetPostById), new { id = newPost.PostId }, newPost);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, Post post)
        {
            var updatedPost = await _postService.UpdatePost(id, post);
            if (updatedPost == null)
            {
                return NotFound();
            }
            return Ok(updatedPost);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var deletedPost = await _postService.DeletePost(id);
            if (deletedPost == null)
            {
                return NotFound();
            }
            return Ok(deletedPost);
        }
    }
}
