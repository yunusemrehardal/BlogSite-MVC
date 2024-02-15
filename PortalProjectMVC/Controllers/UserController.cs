using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PortalProjectMVC.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		// GET: AuthorLogin
		UserProfileManager userProfileManager = new UserProfileManager();
		BlogManager bm = new BlogManager(new EfBlogDal());

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
		public ActionResult UpdateUserProfile(Author author)
		{
			userProfileManager.EditAuthor(author);
			return RedirectToAction("Index");
		}

		public ActionResult BlogList(string user)
		{
			Context context = new Context();
			user = (string)Session["Mail"];
			int id = context.Authors.Where(x => x.Mail == user).Select(y => y.AuthorId).FirstOrDefault();
			var blogs = userProfileManager.GetBlogByAuthor(id);
			return View(blogs);
		}

		[HttpGet]
		public ActionResult UpdateBlog(int id)
		{
			Blog blog = bm.GetByID(id);
			Context context = new Context();
			List<SelectListItem> categoryList = (from x in context.Categories.ToList()
												 select new SelectListItem
												 {
													 Text = x.CategoryName,
													 Value = x.CategoryId.ToString()
												 }).ToList();
			ViewBag.CategoryList = categoryList;

			List<SelectListItem> authorList = (from x in context.Authors.ToList()
											   select new SelectListItem
											   {
												   Text = x.AuthorName,
												   Value = x.AuthorId.ToString()
											   }).ToList();
			ViewBag.AuthorList = authorList;
			return View(blog);
		}
		[HttpPost]
		public ActionResult UpdateBlog(Blog p)
		{
			bm.TUpdate(p);
			return RedirectToAction("Bloglist");
		}
		public ActionResult AddBlog()
		{
			Context context = new Context();
			List<SelectListItem> categoryList = (from x in context.Categories.ToList()
												 select new SelectListItem
												 {
													 Text = x.CategoryName,
													 Value = x.CategoryId.ToString()
												 }).ToList();
			ViewBag.CategoryList = categoryList;

			List<SelectListItem> authorList = (from x in context.Authors.ToList()
											   select new SelectListItem
											   {
												   Text = x.AuthorName,
												   Value = x.AuthorId.ToString()
											   }).ToList();
			ViewBag.AuthorList = authorList;
			return View();
		}
		[HttpPost]
		public ActionResult AddBlog(Blog blog)
		{
			bm.TAdd(blog);
			return RedirectToAction("BlogList");
		}
		public ActionResult DeleteBlog(int id)
		{
			Blog blog = bm.GetByID(id);
			bm.TDelete(blog);
			return RedirectToAction("BlogList");
		}
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("AuthorLogin", "Login");
		}
	}
}