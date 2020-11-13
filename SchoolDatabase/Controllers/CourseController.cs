using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolDatabase.Models;

namespace SchoolDatabase.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            CourseDataController controller = new CourseDataController();
            IEnumerable<Course> Courses = controller.ListCourses();
            return View(Courses);
        }

        //GET :  /Course/Show/{id}

        public ActionResult Show(int id)
        {
            CourseDataController controller = new CourseDataController();
            Course NewCourse = controller.FindCourse(id);

            return View(NewCourse);
        }
    }
}