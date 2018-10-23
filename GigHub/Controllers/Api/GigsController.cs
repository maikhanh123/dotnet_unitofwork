using GigHub.Core;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _context = new ApplicationDbContext();
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitOfWork.Gigs.GetGigWithAttendings(id);
            
//            TODO: Bug - if gig == null
            if (gig == null)
                return NotFound();

            if (gig.IsCanceled)
                return NotFound();

            if (gig.ArtistId != userId)
            {
                return Unauthorized();
            }

            gig.Cancel();

            _context.SaveChanges();

            return Ok();
        }

        public string GetGigs()
        {
             
            return _unitOfWork.Gigs.GetGig();
        }
    }
}
