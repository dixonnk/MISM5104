using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MISM5104.Models;
using MISM5104.Repositories;
using MvcFlash.Core;
using MvcFlash.Core.Extensions;

namespace MISM5104.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IRepository _repository;
	    public HomeController()
	    {
            _repository=new Repository();
	    }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
	        var users = _repository.GetUsers();
	        var model = new UsersVm(users);
	        return View(model);
        }

        public ActionResult SaveUser(UsersVm user)
        {
	        if (user == null)
	        {
		        Flash.Instance.Warning($"The User cannot be null");
		        return RedirectToAction("CreateUser");
			}

			user.CreatedOn= DateTime.Now;
			user.CreatedBy = "Admin";
	        if (_repository.SaveUser(user))
	        {
		        Flash.Instance.Success($"User {user.FullName} saved successfully");
	        }
	        return RedirectToAction("CreateUser");
        }
    }
}