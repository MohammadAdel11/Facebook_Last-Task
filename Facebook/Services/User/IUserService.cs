using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;
using FirstApi.Models;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<User> AddUser(UserRequestModel m);
    Task<User> UpdateUser(int id, User user);
    Task<User> DeleteUser(int id);
    Task<User?> GetUser(AuthModel m);
    string CreateToken(User m);
    string GetCurrentLoggedIn();
}
