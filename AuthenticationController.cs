using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homi.Models;
using MySql.Data;
using System.Web.Optimization;

namespace Homi.Controllers
{
    public class AuthenticationController : Controller
    {
        //WebAdmin w = new WebAdmin();
        //Applicant a = new Applicant();
        private modelLayOut mLO = new modelLayOut();
        public modelLayOut mLO2 = new modelLayOut();
        public bool existBool = false; 
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult applicantAuthentication()
        {            
            return View("ApplicantAuthentication");
        }
        public ActionResult applicantIsExist()
        {
            return View("applicantIsExist");
        }
        public ActionResult applicantPassIsWrong()
        {
            return View("applicantPassIsWrong");
        }
        public ActionResult applicantNotExist()
        {
            return View("applicantNotExist");
        }
        [HttpPost]
        public ActionResult applicantCreate(string Username, string Password, string RepeatPassword)
        {
            if (mLO.applicantExistCheck(Username))
            {
                return View("applicantIsExist");
            }
            else
            {
                mLO.insertNewApplicant(Username, Password);
                return View("ApplicantAuthentication");
            }
        }
        [HttpPost]
        public ActionResult applicantAccess(string Username, string Password)
        {
            if (mLO.applicantAccess(Username, Password))
            {
                return RedirectToAction("Home", "Home");
            }
            else
            {
                if (mLO.applicantExistCheck(Username))
                {
                    return View("applicantPassIsWrong");
                }
                else
                {
                    return View("applicantNotExist");
                }
            }
        }

        //agency part
        public ActionResult agencyAuthentication()
        {
            return View("AgencyAuthentication");
        }
        public ActionResult agencyPassIsWrong()
        {
            return View("agencyPassIsWrong");
        }
        public ActionResult agencyNotExist()
        {
            return View("agencyNotExist");
        }
        [HttpPost]
        public ActionResult agencyAccess(string Username, string Password)
        {
            if (mLO.agencyAccess(Username, Password))
            {               
                return RedirectToAction("Home", "Home");
            }
            else
            {
                if (mLO.agencyExistCheck(Username))
                {
                    return View("agencyPassIsWrong");
                }
                else
                {
                    return View("agencyNotExist");
                }
            }
        }

        //webAdmin
        
 
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Authentication/Style.css",
                "~/Content/Authentication/reset.css",
                "~/Content/Authentication/font.css",
                "~/Content/Authentication/font2.css"));
            bundles.Add(new ScriptBundle("~/Content/Authentication/js").Include(
                "~/Content/Authentication/index.js",
                "~/Content/Authentication/jquery.js"));
        }
    }
}