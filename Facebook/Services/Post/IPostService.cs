using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Models;
using Facebook.Tables;

public interface IPostService
{
    Task<List<PostModel>> GetAllPosts();
    Task<Post> GetPostById(int id);
    Task<Post> AddPost(Post post);
    Task<Post> UpdatePost(int id, Post post);
    Task<Post> DeletePost(int id);
}
