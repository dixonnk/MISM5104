using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISM5104.Models
{
	public class Progress
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int CourseId { get; set; }
		public int CompletedLessons { get; set; }
		public float QuizScores { get; set;}

		public string GetProgress()
		{
			return $"progress";
		}
	}
}