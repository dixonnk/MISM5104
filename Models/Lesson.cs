using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISM5104.Models
{
	public class Lesson
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string CourseId { get; set; }
		public int CompletedUser { get; set; }
		private bool IsCompleted;

		public bool CreateLesson()
		{
			return false;
		}
		public Lesson ViewLesson()
		{
			return this;
		}

		public void CompleteLesson()
		{
			this.IsCompleted = true;
		}
	}
}