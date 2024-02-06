using DataAccessLayer.Concrete;
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
		Context db = new Context();

		// GET: Login
		public ActionResult Index()
		{
			return View();
		}
		//[HttpPost]
		//public ActionResult Index(UserViewModel userViewModel)
		//{
		//	var userInDb = db.Authors.FirstOrDefault(x => x.AuthorName == userViewModel.UserName);

		//	if (userInDb != null)
		//	{
		//		FormsAuthentication.SetAuthCookie(userViewModel.UserName, false);
		//		return RedirectToAction("Index", "Blog");
		//	}
		//	else
		//	{
		//		ViewBag.Message = "Invalid username.";
		//		return View();
		//	}
		//}
	}
}