using System.Collections.Generic;

namespace MISM5104.Models
{
	public class UsersVm : User
	{
		public readonly List<UsersVm> Users;

		public UsersVm()
		{
			//
		}

		public UsersVm(List<UsersVm> users)
		{
			Users = users;
		}
	}
}