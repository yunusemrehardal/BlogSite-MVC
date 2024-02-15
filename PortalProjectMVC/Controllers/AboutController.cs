using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalProjectMVC.Controllers
{
	[AllowAnonymous]

	public class AboutController : Controller
	{
		// GET: About
		AboutManager aboutManager = new AboutManager(new EfAboutDal());
		AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
		public ActionResult Index()
		{
			var abourtContent = aboutManager.GetList();
			return View(abourtContent);
		}
		public PartialViewResult Footer()
		{
			var aboutContentList = aboutManager.GetList();
			return PartialView(aboutContentList);
		}
		public PartialViewResult MeetTheTeam()
		{
			var authorList = authorManager.GetList();
			return PartialView(authorList);
		}
		[HttpGet]
		public ActionResult UpdateAboutList()
		{
			var aboutList = aboutManager.GetList();
			return View(aboutList);
		}
		[HttpPost]
		public ActionResult UpdateAbout(About p)
		{
			aboutManager.TUpdate(p);
			return RedirectToAction("UpdateAboutList");
		}
	}
}