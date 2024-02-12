using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace PortalProjectMVC.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		Context context = new Context();
		// GET: Login
		[HttpGet]
		public ActionResult AuthorLogin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AuthorLogin(Author p)
		{
			var userInfo = context.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
			if (userInfo != null)
			{
				FormsAuthentication.SetAuthCookie(userInfo.Mail, false);
				Session["Mail"] = userInfo.Mail.ToString();
				return RedirectToAction("Index", "User");
			}
			else
			{
				return RedirectToAction("AuthorLogin", "Login");
			}
		}
		[HttpGet]
		public ActionResult AdminLogin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AdminLogin(Admin p)
		{
			var adminInfo = context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
			if (adminInfo != null)
			{
				FormsAuthentication.SetAuthCookie(adminInfo.UserName, false);
				Session["UserName"] = adminInfo.UserName.ToString();
				return RedirectToAction("AdminBlogList", "Blog");
			}
			else
			{
				return RedirectToAction("AdminLogin", "Login");
			}
		}
	}
}