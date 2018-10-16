using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string gigArtistId, string userId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == gigArtistId && f.FollowerId == userId);
        }
    }
}