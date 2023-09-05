using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Services.SharedPosts
{
    public class SharedPostService : ISharedPostService
    {
        private readonly ApplicationDBContext _context;

        public SharedPostService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<SharedPost>> GetAllSharedPosts()
        {
            return await _context.SharedPosts.ToListAsync();
        }

        public async Task<SharedPost> GetSharedPostById(int id)
        {
            return await _context.SharedPosts.FirstOrDefaultAsync(sharedPost => sharedPost.SharedPostId == id);
        }

        public async Task<SharedPost> AddSharedPost(SharedPost sharedPost)
        {
            await _context.SharedPosts.AddAsync(sharedPost);
            await _context.SaveChangesAsync();
            return sharedPost;
        }

        public async Task<SharedPost> UpdateSharedPost(int id, SharedPost sharedPost)
        {
            var existingSharedPost = await _context.SharedPosts.FirstOrDefaultAsync(sharedPost => sharedPost.SharedPostId == id);
            if (existingSharedPost != null)
            {
                await _context.SaveChangesAsync();
            }
            return existingSharedPost;
        }

        public async Task<SharedPost> DeleteSharedPost(int id)
        {
            var existingSharedPost = await _context.SharedPosts.FirstOrDefaultAsync(sharedPost => sharedPost.SharedPostId == id);
            if (existingSharedPost != null)
            {
                _context.SharedPosts.Remove(existingSharedPost);
                await _context.SaveChangesAsync();
            }
            return existingSharedPost;
        }
    }
}
