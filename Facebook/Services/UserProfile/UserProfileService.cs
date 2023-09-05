using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Services.UserProfiles
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ApplicationDBContext _context;

        public UserProfileService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserProfile>> GetAllUserProfiles()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetUserProfileById(int id)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(userProfile => userProfile.UserProfileId == id);
        }

        public async Task<UserProfile> AddUserProfile(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }

        public async Task<UserProfile> UpdateUserProfile(int id, UserProfile userProfile)
        {
            var existingUserProfile = await _context.UserProfiles.FirstOrDefaultAsync(userProfile => userProfile.UserProfileId == id);
            if (existingUserProfile != null)
            {
                await _context.SaveChangesAsync();
            }
            return existingUserProfile;
        }

        public async Task<UserProfile> DeleteUserProfile(int id)
        {
            var existingUserProfile = await _context.UserProfiles.FirstOrDefaultAsync(userProfile => userProfile.UserProfileId == id);
            if (existingUserProfile != null)
            {
                _context.UserProfiles.Remove(existingUserProfile);
                await _context.SaveChangesAsync();
            }
            return existingUserProfile;
        }
    }
}
