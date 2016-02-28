using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DjCollab.Api.Controllers
{
    public class JoinPartyController : Controller
    {
        // GET: JoinParty
        public ActionResult Index()
        {
            ViewBag.Title = "Join a Party";
            return View();
        }
    }
}