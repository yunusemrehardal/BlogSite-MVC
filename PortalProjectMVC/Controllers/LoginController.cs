using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace PortalProjectMVC.Controllers
{
	public class LoginController : Controller
	{
		Context db = new Context();

		// GET: Login
		public ActionResult AuthorLogin()
		{
			return View();
		}
		
	}
}