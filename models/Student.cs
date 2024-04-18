using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISM5104.Models
{
	public class Student : User
	{
		public Student() { }
		private string AdmissionNumber;
		public string Cohort { get; set; }

		public void setAdmissionNumber(string admissionNumber)
		{
			this.AdmissionNumber = admissionNumber;
		}
		public string getAdmissionNumber()
		{
			return this.AdmissionNumber;
		}
	}
}