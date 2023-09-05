using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;

public interface ISharedPostService
{
    Task<List<SharedPost>> GetAllSharedPosts();
    Task<SharedPost> GetSharedPostById(int id);
    Task<SharedPost> AddSharedPost(SharedPost sharedPost);
    Task<SharedPost> UpdateSharedPost(int id, SharedPost sharedPost);
    Task<SharedPost> DeleteSharedPost(int id);
}
