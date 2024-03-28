using System.Collections.Generic;

namespace MISM5104.Models
{
	public class LessonsVm : Lesson
	{
		public readonly IEnumerable<Lesson> Lessons;
		public readonly IEnumerable<Course> Courses;
		public readonly IEnumerable<StudentCourse> StudentCourses;
		public readonly Course Course;
		public LessonsVm() { }
		public LessonsVm(IEnumerable<Lesson> lessons, IEnumerable<Course> courses)
		{
			Lessons = lessons;
			Courses = courses;
		}

		public LessonsVm(IEnumerable<Lesson> lessons, Course course)
		{
			Lessons = lessons;
			Course = course;
		}

		public LessonsVm(IEnumerable<Course> courses, IEnumerable<StudentCourse> studentCourses, IEnumerable<Lesson> lessons)
		{
			Lessons = lessons;
			Courses = courses;
			StudentCourses = studentCourses;
		}
	}
}