using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISM5104.Models;

namespace MISM5104.Repositories
{
	public interface IRepository
	{
		List<UsersVm> GetUsers();
		bool SaveUser(UsersVm user);
	}
}
