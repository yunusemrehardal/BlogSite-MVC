﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalProjectMVC.Controllers
{
	public class CommentController : Controller
	{
		// GET: Comment
		CommentManager cm = new CommentManager(new EfCommentDal());
		[AllowAnonymous]
		public PartialViewResult CommentList(int id)
		{
			var commentList = cm.CommentByBlog(id);
			return PartialView(commentList);
		}
		[AllowAnonymous]
		[HttpGet]
		public PartialViewResult LeaveComment(int id)
		{
			ViewBag.Id = id;
			return PartialView();
		}
		[AllowAnonymous]
		[HttpPost]
		public PartialViewResult LeaveComment(Comment c)
		{
			c.CommentStatus = true;
			cm.TAdd(c);
			return PartialView();
		}
		public ActionResult AdminCommentListTrue()
		{
			var commentList = cm.CommentByStatusTrue();
			return View(commentList);
		}
		public ActionResult AdminCommentListFalse()
		{
			var commentList = cm.CommentByStatusFalse();
			return View(commentList);
		}
		public ActionResult StatusChangeToFalse(int id)
		{
			cm.CommentStatusChangeToFalse(id);
			return RedirectToAction("AdminCommentListTrue");
		}
		public ActionResult StatusChangeToTrue(int id)
		{
			cm.CommentStatusChangeToTrue(id);
			return RedirectToAction("AdminCommentListFalse");
		}
	}
}