using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;

public interface IUserProfileService
{
    Task<List<UserProfile>> GetAllUserProfiles();
    Task<UserProfile> GetUserProfileById(int id);
    Task<UserProfile> AddUserProfile(UserProfile userProfile);
    Task<UserProfile> UpdateUserProfile(int id, UserProfile userProfile);
    Task<UserProfile> DeleteUserProfile(int id);
}
