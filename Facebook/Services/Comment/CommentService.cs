using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDBContext _context;

        public CommentService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(comment => comment.CommentId == id);
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateComment(int id, Comment comment)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(comment => comment.CommentId == id);
            if (existingComment != null)
            {
                // Update properties of existingComment with data from comment
                await _context.SaveChangesAsync();
            }
            return existingComment;
        }

        public async Task<Comment> DeleteComment(int id)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(comment => comment.CommentId == id);
            if (existingComment != null)
            {
                _context.Comments.Remove(existingComment);
                await _context.SaveChangesAsync();
            }
            return existingComment;
        }
    }
}
