using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;

public interface ICommentService
{
    Task<List<Comment>> GetAllComments();
    Task<Comment> GetCommentById(int id);
    Task<Comment> AddComment(Comment comment);
    Task<Comment> UpdateComment(int id, Comment comment);
    Task<Comment> DeleteComment(int id);
}
