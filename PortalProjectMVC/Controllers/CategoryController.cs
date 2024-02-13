using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
			var categoryList = cm.GetAll();
			return View(categoryList);
		}
		[HttpPost]
		public ActionResult AdminCategoryAdd(Category category)
		{
			cm.CategoryAddBL(category);
			return RedirectToAction("AdminCategoryList");
		}
		[HttpGet]
		public ActionResult CategoryEdit(int id)
		{
			Category category = cm.FindCategory(id);
			return View(category);
		}
		[HttpPost]
		public ActionResult CategoryEdit(Category category)
		{
			cm.EditCategory(category);
			return RedirectToAction("AdminCategoryList");
		}
		public ActionResult CategoryDelete(int id)
		{
			cm.StatusFalseBL(id);
			return RedirectToAction("AdminCategoryList");
		}
		public ActionResult StatusTrue(int id)
		{
			cm.StatusTrueBL(id);
			return RedirectToAction("AdminCategoryList");
		}
	}
}