using MISM5104.Models;
using MISM5104.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MISM5104.Controllers
{
    public class AccountController : Controller
    {
		// GET: Account
		// GET: Account
		private readonly IRepository _repository;
		public AccountController(IRepository repository)
		{
			_repository = repository;

		}
		[AllowAnonymous]
		public ActionResult Login()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Logon(LoginViewModel model, string returnUrl = "")
		{
			if (!ModelState.IsValid)
			{
				model.PassWord = null;
				return View("Login", model);
			}
			var user = _repository.GetUsers().FirstOrDefault(m=>m.Username==model.UserName && m.Password==model.PassWord);

			//var authenticate = AuthenticateAd(model.UserName, model.PassWord);
			if (user != null)
			{
				var sourceIp = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
				if (string.IsNullOrEmpty(sourceIp))
				{
					sourceIp = Request.ServerVariables["REMOTE_ADDR"];
				}
				var role = user.UserRole;
				FormsAuthentication.SetAuthCookie(user.Username, model.RememberMe);
				var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(20), model.RememberMe, user.UserRole);
				var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
				var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
				Session["user"] = user;
				
				HttpContext.Response.Cookies.Add(authCookie);
				if (user.UserRole == "Admin")
				{
					return RedirectToAction("CreateUser", "Home");
				}
				if (user.UserRole == "Student")
				{
					return RedirectToAction("StudentProfile", "Home", new {user.Id});
				}
				if (user.UserRole == "Instructor")
				{
					return RedirectToAction("CreateQuiz", "Home");
				}
				return RedirectToAction("Index", "Home");
			}
			model.PassWord = null;
			ModelState.AddModelError("", "Invalid login attempt.");
			return View("login", model);
		}
		public bool AuthenticateAd(string username, string password)
		{
			//return new PrincipalContext(ContextType.Domain, "mail.knec.ac.ke", "OU=Users,DC=mail.knec.ac.ke,DC=com")
			//    .ValidateCredentials(username, password, ContextOptions.Negotiate);
			return true;
		}

		[HttpPost]
		public ActionResult LogOut()
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetNoStore();
			FormsAuthentication.SignOut();
			if (Session != null)
			{
				Session["user"] = null;
			}
			return RedirectToAction("Login", "Account");
		}
	}
}