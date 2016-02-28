using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DjCollab.Api.Controllers
{
    /// <summary>
    /// View Controller for Hosting a Party
    /// </summary>
    public class HostPartyController : Controller
    {
        /// <summary>
        /// Returns the callback after login
        /// </summary>
        /// <returns></returns>
        public ActionResult Callback()
        {
            return View();
        }

        /// <summary>
        /// Returns the main host a party view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Host a Party";
            return View();
        }
    }
}