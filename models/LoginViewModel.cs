using System.ComponentModel.DataAnnotations;

namespace MISM5104.Models
{
	public class LoginViewModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a username")]
		[Display(Name = "Username")]
		public string UserName { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Password field cannot be empty")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string PassWord { get; set; }
		public bool RememberMe { get; set; }
	}
}