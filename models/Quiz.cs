using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace MISM5104.Models
{
	public class Quiz
	{
		public int Id { get; set; }
		public int LessonId { get; set; }
		public string Title { get; set; }
		public string Questions { get; set; }
		private bool Submitted;
		private bool Started;

		public void CreateQuiz()
		{

		}

		public void SubmitQuiz()
		{

		}

		public void StartQuiz()
		{
			this.Started=true;
		}

		public Quiz DisplayResult()
		{
			return this;
		}
	}
}