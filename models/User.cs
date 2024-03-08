using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MISM5104.Models
{
	public abstract class User
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please fill in the full name")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Please fill in the Gender")]
		public string Gender { get; set; }
		[Required(ErrorMessage = "Please fill in the Username")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Please fill in the Password")]
		public string Password { get; set; }
		public string Email { get; set; }
		[Required(ErrorMessage = "Please select the role")]
		public string UserRole { get; set; }
		public DateTime CreatedOn { get; set; }
		public string CreatedBy { get; set; }
	}
}