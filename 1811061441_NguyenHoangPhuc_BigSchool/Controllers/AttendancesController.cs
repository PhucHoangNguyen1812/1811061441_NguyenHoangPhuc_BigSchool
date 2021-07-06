using _1811061441_NguyenHoangPhuc_BigSchool.DTOs;
using _1811061441_NguyenHoangPhuc_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace _1811061441_NguyenHoangPhuc_BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            // test Api them dk Attendances
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists!");
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId

            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();

        }
    }
}
