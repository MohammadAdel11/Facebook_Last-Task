using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;

public interface ILikeService
{
    Task<List<Like>> GetAllLikes();
    Task<Like> GetLikeById(int id);
    Task<Like> AddLike(Like like);
    Task<Like> UpdateLike(int id, Like like);
    Task<Like> DeleteLike(int id);
}
