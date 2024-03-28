using System;
using Dapper.Contrib.Extensions;

namespace MISM5104.Models
{
	[Table("StudentCourses")]
	public class StudentCourse
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int CourseId { get; set; }
		public DateTime EnrolledOn { get; set; }
		public bool IsCompleted { get; set;}
	}
}