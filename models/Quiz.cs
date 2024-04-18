using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper.Contrib.Extensions;
using Microsoft.Ajax.Utilities;

namespace MISM5104.Models
{
	[Table("Quizes")]
	public class Quiz
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string Title { get; set; }
		public string Questions { get; set; }
	
		public void CreateQuiz()
		{

		}

		public void SubmitQuiz()
		{

		}

		public Quiz DisplayResult()
		{
			return this;
		}
	}
}