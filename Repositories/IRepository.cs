using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISM5104.Models;

namespace MISM5104.Repositories
{
	public interface IRepository
	{
		List<UsersVm> GetUsers();
		List<UsersVm> GetUsers(string userRole);
		bool SaveUser(UsersVm user);
		IEnumerable<Course> GetCourses();
		IEnumerable<Quiz> GetQuizes();
		IEnumerable<Lesson> GetLessons();
		bool SaveCourse(Course model, string createdBy);
		bool SaveLesson(Lesson model);
		bool SaveQuiz(Quiz model);
		IEnumerable<StudentCourse> GetStudentCourse();
		bool SaveCourseRegistration(StudentCourse model);
	}
}
