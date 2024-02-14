using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
		CategoryManager cm = new CategoryManager(new EfCategoryDal());
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
			CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult results = categoryValidator.Validate(category);
			if (results.IsValid)
			{
				cm.CategoryAddBL(category);
				return RedirectToAction("AdminCategoryList");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
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
			CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult results = categoryValidator.Validate(category);
			if (results.IsValid)
			{
				cm.EditCategory(category);
				return RedirectToAction("AdminCategoryList");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
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