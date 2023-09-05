using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Services.FriendRequests
{
    public class FriendRequestService : IFriendRequestService
    {
        private readonly ApplicationDBContext _context;

        public FriendRequestService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<FriendRequest>> GetAllFriendRequests()
        {
            return await _context.FriendRequests.ToListAsync();
        }

        public async Task<FriendRequest> GetFriendRequestById(int id)
        {
            return await _context.FriendRequests.FirstOrDefaultAsync(request => request.FriendRequestId == id);
        }

        public async Task<FriendRequest> AddFriendRequest(FriendRequest friendRequest)
        {
            await _context.FriendRequests.AddAsync(friendRequest);
            await _context.SaveChangesAsync();
            return friendRequest;
        }

        public async Task<FriendRequest> UpdateFriendRequest(int id, FriendRequest friendRequest)
        {
            var existingRequest = await _context.FriendRequests.FirstOrDefaultAsync(request => request.FriendRequestId == id);
            if (existingRequest != null)
            {
                // Update properties of existingRequest with data from friendRequest
                await _context.SaveChangesAsync();
            }
            return existingRequest;
        }

        public async Task<FriendRequest> DeleteFriendRequest(int id)
        {
            var existingRequest = await _context.FriendRequests.FirstOrDefaultAsync(request => request.FriendRequestId == id);
            if (existingRequest != null)
            {
                _context.FriendRequests.Remove(existingRequest);
                await _context.SaveChangesAsync();
            }
            return existingRequest;
        }
    }
}
