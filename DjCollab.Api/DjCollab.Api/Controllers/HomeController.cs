using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DjCollab.Api.Controllers
{
    /// <summary>
    /// View Controller for Home
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns view for the index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "DJCollab";
            return View();
        }
    }
}
