using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;

public interface IFriendRequestService
{
    Task<List<FriendRequest>> GetAllFriendRequests();
    Task<FriendRequest> GetFriendRequestById(int id);
    Task<FriendRequest> AddFriendRequest(FriendRequest friendRequest);
    Task<FriendRequest> UpdateFriendRequest(int id, FriendRequest friendRequest);
    Task<FriendRequest> DeleteFriendRequest(int id);
}
