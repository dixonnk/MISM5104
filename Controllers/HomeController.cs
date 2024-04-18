using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MISM5104.Models;
using MISM5104.Repositories;
using MvcFlash.Core;
using MvcFlash.Core.Extensions;

namespace MISM5104.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IRepository _repository;
	    public HomeController(IRepository repository)
	    {
		    _repository = repository;
	    }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
	        var users = _repository.GetUsers();
	        var model = new UsersVm(users);
	        return View(model);
        }

        public ActionResult SaveUser(UsersVm user)
        {
	        if (user == null)
	        {
		        Flash.Instance.Warning($"The User cannot be null");
		        return RedirectToAction("CreateUser");
			}

			user.CreatedOn= DateTime.Now;
			user.CreatedBy = "Admin";
	        if (_repository.SaveUser(user))
	        {
		        Flash.Instance.Success($"User {user.FullName} saved successfully");
	        }
	        return RedirectToAction("CreateUser");
        }

        public ActionResult CreateCourse()
        {
	        var courses = _repository.GetCourses();
	        var model = new CourseVm(courses);
	        return View(model);
        }
        public ActionResult CreateQuiz()
        {
	        var courses = _repository.GetCourses();
			var quizes = _repository.GetQuizes();
	        var model = new QuizesVm(quizes, courses);
	        return View(model);
        }
        public ActionResult CreateLesson()
        {
	        var courses = _repository.GetCourses();
	        var lessons = _repository.GetLessons();
	        var model = new LessonsVm(lessons, courses);
	        return View(model);
        }
        public ActionResult RegisterForCourse()
        {
			var courses = _repository.GetCourses();
			var model = new CourseVm(courses);
	        return View(model);
        }
        public ActionResult AttemptQuiz(int quizId)
        {
	        var quiz = _repository.GetQuizes().FirstOrDefault(m=>m.Id==quizId);
	        var model = new QuizesVm(quiz);
	        return View(model);
        }

        public ActionResult StudentProfile(int id)
        {
	        var studentDetails = _repository.GetUsers("Student").FirstOrDefault(m => m.Id == id);
	        var model = new UsersVm(studentDetails);
			return View(model);
        }

        public ActionResult SaveCourse(Course model)
        {
			var user = (UsersVm)HttpContext.Session["user"];
			if (_repository.SaveCourse(model, user.FullName))
	        {
		        Flash.Instance.Success($"Course saved successfully");
	        }

	        return RedirectToAction("CreateCourse");
        }

        public ActionResult AddLesson(int courseId)
        {
	        var course = _repository.GetCourses().FirstOrDefault(m => m.Id == courseId);
	        var lessons = _repository.GetLessons().Where(m => m.CourseId == courseId);
			var model = new LessonsVm(lessons, course);
			return View(model);
		}

        public ActionResult SaveLesson(Lesson model)
        {
			var user = (UsersVm)HttpContext.Session["user"];
			model.InstructorId=user.Id;
			if (_repository.SaveLesson(model))
			{
				Flash.Instance.Success($"Lesson saved successfully");
			}

			return RedirectToAction("AddLesson", new { courseId =model.CourseId});
		}

        public ActionResult AddQuiz(int courseId)
        {
			var course = _repository.GetCourses().FirstOrDefault(m => m.Id == courseId);
			var quizes = _repository.GetQuizes().Where(m => m.CourseId == courseId);
			var model = new QuizesVm(quizes, course);
			return View(model);
		}

        public ActionResult SaveQuiz(Quiz model)
        {
			if (_repository.SaveQuiz(model))
			{
				Flash.Instance.Success($"Quiz saved successfully");
			}

			return RedirectToAction("AddQuiz",new{ courseId=model.CourseId });
		}

        public ActionResult CourseRegistration(int userId)
        {
			var courses = _repository.GetCourses();
			var studentCourses = _repository.GetStudentCourse().Where(m=>m.StudentId==userId);
			var model = new StudentCourseVm(courses, studentCourses);
			return View(model);
		}

        public ActionResult AddCourseRegistration(int courseId)
        {
			var user = (UsersVm)HttpContext.Session["user"];
			var model = new StudentCourse
			{
				CourseId = courseId,
				StudentId = user.Id,
				EnrolledOn = DateTime.Now,
				IsCompleted = false
			};
			if (_repository.SaveCourseRegistration(model))
			{
				Flash.Instance.Success($"Registration successful");
			}

			return RedirectToAction("CourseRegistration", new { userId = user.Id });
        }

        public ActionResult ViewLessons(int userId)
        {
			var courses = _repository.GetCourses();
			var studentCourses = _repository.GetStudentCourse().Where(m => m.StudentId == userId);
			var lessons = _repository.GetLessons();
			var model = new LessonsVm(courses, studentCourses, lessons);
			return View(model);
        }

        public ActionResult ViewQuizes(int userId)
        {
			var courses = _repository.GetCourses();
			var studentCourses = _repository.GetStudentCourse().Where(m => m.StudentId == userId);
			var quizes = _repository.GetQuizes();
			var model = new QuizesVm(courses, studentCourses, quizes);
			return View(model);
        }
    }
}