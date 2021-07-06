using _1811061441_NguyenHoangPhuc_BigSchool.Models;
using System.Collections.Generic;

namespace _1811061441_NguyenHoangPhuc_BigSchool.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcomingCourses { get; set; }

        public bool ShowAction { get; set; }

    }
}