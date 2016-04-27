using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homi.Models;

namespace Homi.Controllers
{
    public class AdminController : Controller
    {
        public modelLayOut mLO = new modelLayOut();
        string currentUser;
        // GET: Admin 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult webAdminPage()
        {
            return View("webAdminPage");
        }

        [HttpPost]
        public ActionResult createAgency()
        {
            if (mLO.dod2() == "admin")
            {
                return View("createAgency");
            }
            else
            {
                return View("notAccess");
            }
        }

        public ActionResult webAdminAuthentication()
        {
            return View("WebAdminAuthentication");
        }
        public ActionResult webAdminAccessWrong()
        {
            return View("webAdminAccessWrong");
        }
        [HttpPost]
        public ActionResult webAdminAccess(string Username, string Password)
        {
            if (mLO.webAdminAccess(Username, Password))
            {
                currentUser = Username;
                mLO.dod(Username);
                return RedirectToAction("webAdminPage", "Admin");
            }
            else
            {
                return View("webAdminAccessWrong");
            }
        }
        [HttpPost]
        public ActionResult insertNewAgency(string name, string address, int phoneNumber, string username, string password)
        {
                return View("agencyCreateSuccessfully");
        }
        [HttpPost]
        public ActionResult getAgencyIncome()
        {

                return View("getAgencyIncome");

        }
    }
}