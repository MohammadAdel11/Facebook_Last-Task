using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Services.Friendships
{
    public class FriendshipService : IFriendshipService
    {
        private readonly ApplicationDBContext _context;

        public FriendshipService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<FreindShip>> GetAllFriendships()
        {
            return await _context.Friendships.ToListAsync();
        }

        public async Task<FreindShip> GetFriendshipById(int id)
        {
            return await _context.Friendships.FirstOrDefaultAsync(friendship => friendship.FriendshipId == id);
        }

        public async Task<FreindShip> AddFriendship(FreindShip friendship)
        {
            await _context.Friendships.AddAsync(friendship);
            await _context.SaveChangesAsync();
            return friendship;
        }

        public async Task<FreindShip> UpdateFriendship(int id, FreindShip friendship)
        {
            var existingFriendship = await _context.Friendships.FirstOrDefaultAsync(friendship => friendship.FriendshipId == id);
            if (existingFriendship != null)
            {
                await _context.SaveChangesAsync();
            }
            return existingFriendship;
        }

        public async Task<FreindShip> DeleteFriendship(int id)
        {
            var existingFriendship = await _context.Friendships.FirstOrDefaultAsync(friendship => friendship.FriendshipId == id);
            if (existingFriendship != null)
            {
                _context.Friendships.Remove(existingFriendship);
                await _context.SaveChangesAsync();
            }
            return existingFriendship;
        }
    }
}
