using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        void Add(Gig gig);
        Gig GetGigById(int id);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithArtitsGenre(int id);
        Gig GetGigWithAttendings(int id);
        IEnumerable<Gig> GetGigWithUserId(string userId);
        string GetGig();
    }
}