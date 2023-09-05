using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Facebook.Models;
using Facebook.Tables;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Services.Posts
{


    public class PostService : IPostService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public PostService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PostModel>> GetAllPosts()
        {
            var list = await _context.Posts
             .Include(p => p.User) 
             .Include(p => p.Likes) 
             .Include(p => p.Comments)
             .Include(p => p.SharedByUsers)
             .ToListAsync();
            var result = _mapper.Map<List<PostModel>>(list);
            return result;

        }

        public async Task<Post> GetPostById(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(post => post.PostId == id);
        }

        public async Task<Post> AddPost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePost(int id, Post post)
        {
            var existingPost = await _context.Posts.FirstOrDefaultAsync(post => post.PostId == id);
            if (existingPost != null)
            {
                await _context.SaveChangesAsync();
            }
            return existingPost;
        }

        public async Task<Post> DeletePost(int id)
        {
            var existingPost = await _context.Posts.FirstOrDefaultAsync(post => post.PostId == id);
            if (existingPost != null)
            {
                _context.Posts.Remove(existingPost);
                await _context.SaveChangesAsync();
            }
            return existingPost;
        }
    }
}
