using _1811061441_NguyenHoangPhuc_BigSchool.Models;
using _1811061441_NguyenHoangPhuc_BigSchool.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace _1811061441_NguyenHoangPhuc_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index(string searchString)
        {



            if (!string.IsNullOrEmpty(searchString))
            {

                var upcommingCourses = _dbContext.Courses.Where(x => x.Place.Contains(searchString))

                  .Include(c => c.Lecturer)
                  .Include(c => c.Category)
                  .Where(c => c.DateTime > DateTime.Now);

                var viewModel = new CoursesViewModel
                {
                    UpcomingCourses = upcommingCourses,
                    ShowAction = User.Identity.IsAuthenticated
                };
                return View(viewModel);
            }
            else
            {
                var upcommingCourses = _dbContext.Courses

                     .Include(c => c.Lecturer)
                     .Include(c => c.Category)
                     .Where(c => c.DateTime > DateTime.Now);

                var viewModel = new CoursesViewModel
                {
                    UpcomingCourses = upcommingCourses,
                    ShowAction = User.Identity.IsAuthenticated
                };
                return View(viewModel);
            }



        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}