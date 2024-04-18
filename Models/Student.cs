using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISM5104.Models
{
	public class Student : User
	{
		public Student() { }
		public string AdmissionNumber { get; set; }
		public string Cohort { get; set; }
	}
}