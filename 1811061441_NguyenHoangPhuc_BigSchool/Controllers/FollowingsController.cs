using _1811061441_NguyenHoangPhuc_BigSchool.DTOs;
using _1811061441_NguyenHoangPhuc_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace _1811061441_NguyenHoangPhuc_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {

            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");
            var following = new Following
            {
                FolloweeId = followingDto.FolloweeId,
                FollowerId = userId

            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();

        }

        [HttpDelete]

        public IHttpActionResult DeleteFollow(string Id)
        {
            var userId = User.Identity.GetUserId();
            var following = _dbContext.Followings.SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == Id);
            if (following == null)
            {
                return NotFound();
            }

            _dbContext.Followings.Remove(following);
            _dbContext.SaveChanges();
            return Ok(Id);
        }
        //bo tham gia dang ky khoa hoc
    }
}
