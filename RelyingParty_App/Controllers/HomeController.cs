using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonAccessAttributes;

namespace RelyingParty_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ClientAccess]
        public ActionResult OnlyClientsAllowed()
        {
            ViewBag.Message = "You have successfully accessed this Client-Only section";
            return View();
        }

        [PartnerAccess]
        public ActionResult OnlyPartnersAllowed()
        {
            ViewBag.Message = "You have successfully accessed this Partner-Only section";
            return View();
        }
    }
}
