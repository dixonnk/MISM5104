using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper.Contrib.Extensions;

namespace MISM5104.Models
{
	[Table("Courses")]
	public class Course
	{
		public Course() { }
		public int Id { get; set; }
		public string CourseName { get; set; }
		public DateTime StartDate { get; set;}
		public DateTime EndDate { get; set;}
		public DateTime CreatedOn { get; set; }
		public string CreatedBy{ get; set; }

		public bool CreateCourse()
		{
			return false;
		}

		public bool StartCourse()
		{
			return false;
		}

		public bool EndCourse()
		{
			return false;
		}
	}
}