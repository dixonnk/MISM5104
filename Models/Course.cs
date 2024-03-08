using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISM5104.Models
{
	public class Course
	{
		public Course() { }
		public int Id { get; set; }
		public string CourseName { get; set; }
		public string EnrolledUsers { get; set; }
		public DateTime StartDate { get; set;}
		public DateTime EndDate { get; set;}

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