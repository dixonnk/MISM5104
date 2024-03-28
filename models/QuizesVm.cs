using System.Collections.Generic;

namespace MISM5104.Models
{
	public class QuizesVm : Quiz
	{
		public readonly Quiz SelectedQuiz;
		public readonly IEnumerable<Quiz> Quizes;
		public readonly IEnumerable<Course> Courses;
		public readonly IEnumerable<StudentCourse> StudentCourses;
		public readonly Course Course;
		public QuizesVm() {}

		public QuizesVm(Quiz quiz)
		{
			SelectedQuiz = quiz;
		}

		public QuizesVm(IEnumerable<Quiz> quizes, IEnumerable<Course> courses)
		{
			Quizes = quizes;
			Courses = courses;
		}

		public QuizesVm(IEnumerable<Quiz> quizes, Course course)
		{
			Quizes = quizes;
			Course = course;
		}

		public QuizesVm(IEnumerable<Course> courses, IEnumerable<StudentCourse> studentCourses, IEnumerable<Quiz> quizes)
		{
			Quizes = quizes;
			Courses = courses;
			StudentCourses = studentCourses;
		}
	}
}