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

	public class AuthorController : Controller
	{
		// GET: Author
		BlogManager blogManager = new BlogManager(new EfBlogDal());
		AuthorManager authorManager = new AuthorManager(new EfAuthorDal());

		[AllowAnonymous]
		public PartialViewResult AuthorAbout(int id)
		{
			var authorDetail = blogManager.GetBlogByID(id);
			return PartialView(authorDetail);
		}
		[AllowAnonymous]
		public PartialViewResult AuthorPopularPost(int id)
		{
			var blogAuthorId = blogManager.GetList().Where(x => x.BlogId == id).Select(y => y.AuthorId).FirstOrDefault();
			var authorsblog = blogManager.GetBlogByAuthor(blogAuthorId);
			return PartialView(authorsblog);
		}
		public ActionResult AuthorList()
		{
			var authorLists = authorManager.GetList();
			return View(authorLists);
		}
		[HttpGet]
		public ActionResult AddAuthor()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddAuthor(Author p)
		{
			AuthorValidator authorValidator = new AuthorValidator();
			ValidationResult results = authorValidator.Validate(p);
			if (results.IsValid)
			{
				authorManager.TAdd(p);
				return RedirectToAction("AuthorList");
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
		public ActionResult AuthorEdit(int id)
		{
			Author author = authorManager.GetByID(id);
			return View(author);
		}
		[HttpPost]
		public ActionResult AuthorEdit(Author p)
		{
			AuthorValidator authorValidator = new AuthorValidator();
			ValidationResult results = authorValidator.Validate(p);
			if (results.IsValid)
			{
				authorManager.TUpdate(p);
				return RedirectToAction("AuthorList");
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
	}
}