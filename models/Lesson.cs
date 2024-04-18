using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper.Contrib.Extensions;

namespace MISM5104.Models
{
	[Table("Lessons")]
	public class Lesson
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int CourseId { get; set; }
		public int Duration { get; set; }
		public int InstructorId { get; set; }

		public bool CreateLesson()
		{
			return false;
		}
		public Lesson ViewLesson()
		{
			return this;
		}
	}
}