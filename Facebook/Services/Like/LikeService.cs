using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Services.Likes
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDBContext _context;

        public LikeService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Like>> GetAllLikes()
        {
            return await _context.Likes.ToListAsync();
        }

        public async Task<Like> GetLikeById(int id)
        {
            return await _context.Likes.FirstOrDefaultAsync(like => like.LikeId == id);
        }

        public async Task<Like> AddLike(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task<Like> UpdateLike(int id, Like like)
        {
            var existingLike = await _context.Likes.FirstOrDefaultAsync(like => like.LikeId == id);
            if (existingLike != null)
            {
                await _context.SaveChangesAsync();
            }
            return existingLike;
        }

        public async Task<Like> DeleteLike(int id)
        {
            var existingLike = await _context.Likes.FirstOrDefaultAsync(like => like.LikeId == id);
            if (existingLike != null)
            {
                _context.Likes.Remove(existingLike);
                await _context.SaveChangesAsync();
            }
            return existingLike;
        }
    }
}
