using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string gigArtistId, string userId);
    }
}