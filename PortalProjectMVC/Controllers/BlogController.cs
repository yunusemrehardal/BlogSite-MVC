using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease;

namespace PortalProjectMVC.Controllers
{
	public class BlogController : Controller
	{
		BlogManager bm = new BlogManager();

		//[Authorize]
		public ActionResult Index()
		{
			return View();
		}
		public PartialViewResult BlogList(int page = 1)
		{
			var bloglist = bm.GetAll().ToPagedList(page, 6);
			return PartialView(bloglist);
		}
		public PartialViewResult FeaturedPost()
		{
			//Post1
			var postTittle1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
			var postImage1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
			var blogDate1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();
			var blogPostId1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogId).FirstOrDefault();

			ViewBag.postTittle1 = postTittle1;
			ViewBag.postImage1 = postImage1;
			ViewBag.blogDate1 = blogDate1;
			ViewBag.blogPostId1 = blogPostId1;

			//Post2
			var postTittle2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
			var postImage2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogImage).FirstOrDefault();
			var blogDate2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogDate).FirstOrDefault();
			var blogPostId2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogId).FirstOrDefault();

			ViewBag.postTittle2 = postTittle2;
			ViewBag.postImage2 = postImage2;
			ViewBag.blogDate2 = blogDate2;
			ViewBag.blogPostId2 = blogPostId2;

			//Post3
			var postTittle3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
			var postImage3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
			var blogDate3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();
			var blogPostId3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogId).FirstOrDefault();

			ViewBag.postTittle3 = postTittle3;
			ViewBag.postImage3 = postImage3;
			ViewBag.blogDate3 = blogDate3;
			ViewBag.blogPostId3 = blogPostId3;

			//Post4
			var postTittle4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
			var postImage4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogImage).FirstOrDefault();
			var blogDate4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();
			var blogPostId4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogId).FirstOrDefault();

			ViewBag.postTittle4 = postTittle4;
			ViewBag.postImage4 = postImage4;
			ViewBag.blogDate4 = blogDate4;
			ViewBag.blogPostId4 = blogPostId4;

			//Post5
			var postTittle5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogTitle).FirstOrDefault();
			var postImage5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogImage).FirstOrDefault();
			var blogDate5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogDate).FirstOrDefault();
			var blogPostId5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogId).FirstOrDefault();

			ViewBag.postTittle5 = postTittle5;
			ViewBag.postImage5 = postImage5;
			ViewBag.blogDate5 = blogDate5;
			ViewBag.blogPostId5 = blogPostId5;

			return PartialView();
		}
		public PartialViewResult OutherFeaturedPost()
		{
			return PartialView();
		}

		public ActionResult BlogDetails()
		{

			return View();
		}
		public PartialViewResult BlogCover(int id)
		{
			var BlogDetailsList = bm.GetBlogByID(id);
			return PartialView(BlogDetailsList);
		}
		public PartialViewResult BlogReadAll(int id)
		{
			var BlogDetailsList = bm.GetBlogByID(id);
			return PartialView(BlogDetailsList);
		}
		public ActionResult BlogByCategory(int id)
		{
			var BlogListByCategory = bm.GetBlogByCategory(id);
			var CategoryName = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryName).FirstOrDefault();
			ViewBag.CategoryName = CategoryName;
			var CategoryDescription = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryDescription).FirstOrDefault();
			ViewBag.CategoryDescription = CategoryDescription;
			return View(BlogListByCategory);
		}
		public ActionResult AdminBlogList()
		{
			var blogList = bm.GetAll();
			return View(blogList);
		}
		public ActionResult AdminBlogList2()
		{
			var blogList = bm.GetAll();
			return View(blogList);
		}
		[HttpGet]
		public ActionResult AddNewBlog()
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
		public ActionResult AddNewBlog(Blog b)
		{
			bm.BlogAddBL(b);
			return RedirectToAction("AdminBlogList");
		}
		public ActionResult DeleteBlog(int id)
		{
			bm.DeleteBlog(id);
			return RedirectToAction("AdminBlogList");
		}
		[HttpGet]
		public ActionResult UpdateBlog(int id)
		{
			Blog blog = bm.FindBlog(id);
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
			bm.UpdateBlog(p);
			return RedirectToAction("AdminBlogList");
		}
		public ActionResult GetCommentByBlog(int id)
		{
			CommentManager cm = new CommentManager();
			var commentlist = cm.CommentByBlog(id);
			return View(commentlist);
		}
	}
}