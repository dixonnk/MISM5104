using System.Collections.Generic;

namespace MISM5104.Models
{
	public class CourseVm : Course
	{
		public readonly IEnumerable<Course> Courses;

		public CourseVm() { }
		public CourseVm(IEnumerable<Course> courses)
		{
			Courses = courses;
		}
	}
}