using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalProjectMVC.Controllers
{
    public class CategoryController : Controller
    {
		// GET: Category
		CategoryManager cm = new CategoryManager();
		public ActionResult Index()
		{
			var categoryvalues = cm.GetAll();
			return View(categoryvalues);
		}
		[AllowAnonymous]
		public PartialViewResult BlogDetailsCategoryList()
		{
			var categoryvalues = cm.GetAll();
			return PartialView(categoryvalues);
		}
		public ActionResult AdminCategoryList()
		{
			var categoryList= cm.GetAll();
			return View(categoryList);
		}
	}
}