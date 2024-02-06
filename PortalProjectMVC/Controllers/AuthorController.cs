using BusinessLayer.Concrete;
using EntityLayer.Concrete;
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
		BlogManager blogManager = new BlogManager();
		AuthorManager authorManager = new AuthorManager();
		public PartialViewResult AuthorAbout(int id)
		{
			var authorDetail = blogManager.GetBlogByID(id);
			return PartialView(authorDetail);
		}
		public PartialViewResult AuthorPopularPost(int id)
		{
			var blogAuthorId = blogManager.GetAll().Where(x => x.BlogId == id).Select(y => y.AuthorId).FirstOrDefault();
			var authorsblog = blogManager.GetBlogByAuthor(blogAuthorId);
			return PartialView(authorsblog);
		}
		public ActionResult AuthorList()
		{
			var authorLists = authorManager.GetAll();
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
			authorManager.AddAuthorBL(p);
			return RedirectToAction("AuthorList");
		}
		[HttpGet]

		public ActionResult AuthorEdit(int id)
		{
			Author author = authorManager.FindAuthor(id);
			return View(author);
		}
		[HttpPost]

		public ActionResult AuthorEdit(Author p)
		{
			authorManager.EditAuthor(p);
			return RedirectToAction("AuthorList");
		}
	}
}