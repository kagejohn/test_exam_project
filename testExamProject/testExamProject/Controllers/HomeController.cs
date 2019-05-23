using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testExamProject.Data;

namespace testExamProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly CreateData _createData = new CreateData();
        private readonly LoadData _loadData = new LoadData();

        public ActionResult Index()
        {
            //var test = new Data.CreateTestData(100000);
            return View();
        }

        public ActionResult CreateStudent()
        {
            return View();
        }

        public ActionResult CreateTeacher()
        {
            return View();
        }

        public ActionResult CreateCourse()
        {
            return View();
        }

        public ActionResult CreateSubject()
        {
            return View();
        }

        public ActionResult JoinCourse()
        {
            return View();
        }

        public ActionResult ConnectCourseToSubject()
        {
            return View();
        }

        public ActionResult DisplaySchedule()
        {
            return View(_loadData.GetCourses());
        }

        [HttpPost]
        public ActionResult CreateStudentPost()
        {
            string name = Request["Name"];
            int age = Convert.ToInt32(Request["Age"]);

            ViewBag.Success = _createData.CreateStudents(name, age);

            return View("CreateStudent");
        }

        [HttpPost]
        public ActionResult CreateTeacherPost()
        {
            string name = Request["Name"];
            string education = Request["Education"];
            bool teaching = Request["Teaching"] == "true,false" || Request["Teaching"] == "true";

            ViewBag.Success = _createData.CreateTeachers(name, education, teaching);

            return View("CreateTeacher");
        }

        [HttpPost]
        public ActionResult CreateCoursePost()
        {
            string name = Request["Name"];
            int duration = Convert.ToInt32(Request["Duration"]);
            DateTime addedDate = Request["AddedDate"] == "" ? DateTime.Today : Convert.ToDateTime(Request["AddedDate"]);
            int teacherId = Convert.ToInt32(Request["TeacherId"]);

            ViewBag.Success = _createData.CreateCourses(name, duration, addedDate, teacherId);

            return View("CreateCourse");
        }

        [HttpPost]
        public ActionResult CreateSubjectPost()
        {
            string name = Request["Name"];

            ViewBag.Success = _createData.CreateSubjects(name);

            return View("CreateSubject");
        }

        [HttpPost]
        public ActionResult JoinCoursePost()
        {
            int studentId = Convert.ToInt32(Request["StudentId"]);
            int courseId = Convert.ToInt32(Request["CourseId"]);
            bool paid = Request["Paid"] == "true,false" || Request["Paid"] == "true";

            ViewBag.Success = _createData.CreateCourseParticipations(studentId, courseId, paid);

            return View("JoinCourse");
        }

        [HttpPost]
        public ActionResult ConnectCourseToSubjectPost()
        {
            int courseId = Convert.ToInt32(Request["CourseId"]);
            int subjectId = Convert.ToInt32(Request["SubjectId"]);

            ViewBag.Success = _createData.CreateCourseSubjects(subjectId, courseId);

            return View("ConnectCourseToSubject");
        }
    }
}