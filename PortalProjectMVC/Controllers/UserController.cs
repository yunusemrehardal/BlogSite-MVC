using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalProjectMVC.Controllers
{
	public class UserController : Controller
	{
		// GET: AuthorLogin
		UserProfileManager userProfileManager = new UserProfileManager();
		public ActionResult Index()
		{
			return View();
		}
		public PartialViewResult Partial1(string userMail)
		{
			userMail = (string)Session["Mail"];
			var model = userProfileManager.GetAuthorByMail(userMail);
			return PartialView(model);
		}
		public ActionResult BlogList(string user)
		{
			Context context = new Context();
			user = (string)Session["Mail"];
			int id = context.Authors.Where(x => x.Mail == user).Select(y => y.AuthorId).FirstOrDefault();
			var blogs = userProfileManager.GetBlogByAuthor(id);
			return View(blogs);
		}
	}
}