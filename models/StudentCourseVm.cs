using System.Collections.Generic;

namespace MISM5104.Models
{
	public class StudentCourseVm : StudentCourse
	{
		public readonly IEnumerable<Course> Courses;
		public readonly IEnumerable<StudentCourse> StudentCourses;

		public StudentCourseVm() { }

		public StudentCourseVm(IEnumerable<Course> courses, IEnumerable<StudentCourse> studentCourses)
		{
			Courses = courses;
			StudentCourses = studentCourses;
		}
	}
}