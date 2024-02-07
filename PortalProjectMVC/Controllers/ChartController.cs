using DataAccessLayer.Concrete;
using PortalProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalProjectMVC.Controllers
{
	public class ChartController : Controller
	{
		// GET: Chart
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult VisualizeResult()
		{
			return Json(categoryList(), JsonRequestBehavior.AllowGet);
		}
		public List<ChartCategory> categoryList()
		{
			List<ChartCategory> classes = new List<ChartCategory>();
			classes.Add(new ChartCategory()
			{
				CategoryName = "Teknoloji",
				BlogCount = 14
			});
			classes.Add(new ChartCategory()
			{
				CategoryName = "Spor",
				BlogCount = 10
			});
			classes.Add(new ChartCategory()
			{
				CategoryName = "Kitap",
				BlogCount = 16
			});
			return classes;
		}
		public List<ChartBlogRate> BlogList()
		{
			List<ChartBlogRate> chartBlogRates = new List<ChartBlogRate>();
			using (var context = new Context())
			{
				chartBlogRates = context.Blogs.Select(x => new ChartBlogRate
				{
					BlogName = x.BlogTitle,
					Rating = x.BlogRating
				}).ToList();
			}
			return chartBlogRates;
		}
		public ActionResult VisualizeResult2()
		{
			return Json(BlogList(), JsonRequestBehavior.AllowGet);
		}
		public ActionResult Chart1()
		{
			return View();
		}
		public ActionResult Chart2()
		{
			return View();
		}
		public ActionResult Chart3()
		{
			return View();
		}
	}
}