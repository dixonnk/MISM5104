using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISM5104.Models
{
	public class Admin : User
	{
		public Admin() { }
		public string EmploymentNumber { get; set; }

		public bool RegisterUser(Student student)
		{
			return false;
		}

		public bool UpdateUser(Student student)
		{
			return false;
		}
	}
}