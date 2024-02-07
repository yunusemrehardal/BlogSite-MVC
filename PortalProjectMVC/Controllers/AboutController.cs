using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalProjectMVC.Controllers
{
	public class AboutController : Controller
	{
		// GET: About
		AboutManager aboutManager = new AboutManager();
		AuthorManager authorManager = new AuthorManager();
		public ActionResult Index()
		{
			var abourtContent = aboutManager.GetAll();
			return View(abourtContent);
		}
		public PartialViewResult Footer()
		{
			var aboutContentList = aboutManager.GetAll();
			return PartialView(aboutContentList);
		}
		public PartialViewResult MeetTheTeam()
		{
			var authorList = authorManager.GetAll();
			return PartialView(authorList);
		}
		[HttpGet]
		public ActionResult UpdateAboutList()
		{
			var aboutList = aboutManager.GetAll();
			return View(aboutList);
		}
		[HttpPost]
		public ActionResult UpdateAbout(About p)
		{
			aboutManager.UpdateAboutBM(p);
			return RedirectToAction("UpdateAboutList");
		}
	}
}