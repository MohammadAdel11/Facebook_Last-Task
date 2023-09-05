using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.Comments;
using Facebook.Tables;
using Microsoft.AspNetCore.Authorization;

namespace Facebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]

    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            var comments = await _commentService.GetAllComments();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            var newComment = await _commentService.AddComment(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = newComment.CommentId }, newComment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Comment>> UpdateComment(int id, Comment comment)
        {
            var updatedComment = await _commentService.UpdateComment(id, comment);
            if (updatedComment == null)
            {
                return NotFound();
            }
            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var deletedComment = await _commentService.DeleteComment(id);
            if (deletedComment == null)
            {
                return NotFound();
            }
            return Ok(deletedComment);
        }
    }
}
