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
	}
}