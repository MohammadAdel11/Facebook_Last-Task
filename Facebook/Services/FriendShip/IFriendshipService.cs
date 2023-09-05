using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;

public interface IFriendshipService
{
    Task<List<FreindShip>> GetAllFriendships();
    Task<FreindShip> GetFriendshipById(int id);
    Task<FreindShip> AddFriendship(FreindShip friendship);
    Task<FreindShip> UpdateFriendship(int id, FreindShip friendship);
    Task<FreindShip> DeleteFriendship(int id);
}
