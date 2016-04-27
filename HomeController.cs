using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homi.Models;
using MySql.Data;
using System.Web.Optimization;
using Homi.Controllers;

namespace Homi.Controllers
{
    public class HomeController : Controller
    {
        //public string username;
        //public string password;
        private AuthenticationController ac = new AuthenticationController();
        public ActionResult Index()
        {
            return View("Home");
        }

        public ActionResult Home()
        {
            return View("Home");
        }
        [HttpPost]
        public ActionResult sendToApplicantAuthentication(string applicant)
        {
            return RedirectToAction("applicantAuthentication", "Authentication");
        }
        [HttpPost]
        public ActionResult sendToAgencyAuthentication(string agency)
        {
            return RedirectToAction("agencyAuthentication", "Authentication");
        }
        [HttpPost]
        public ActionResult sendToAdminAuthentication(string Admin)
        {
            return RedirectToAction("webAdminAuthentication", "Authentication");
        }
        public ActionResult mainPage()

        {
            HomeController wb = new HomeController();
            ViewData["h"] = wb;
            return View("ApplicantAuthentication");
            //Response.AddHeader("Content-Disposition", new System.Net.Mime.ContentDisposition { Inline = true, FileName = "login1.html" }.ToString());
            //var path = @"C:\Users\Muhammad Ehsan\Documents\Visual Studio 2015\Projects\Homi\Homi\Views\Home\login1\index3.html";
            //return new FilePathResult(path, "text/html");
        }
        public void string1()
        {
            
           // wb.InsertToDb("hasan", "123");
        }
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Style.css",
                "~/Content/reset.css",
                "~/Content/font.css",
                "~/Content/font2.css"));
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                "~/Content/index.js",
                "~/Content/jquery.js"));
        }
        [HttpPost]
        public ActionResult setp(string Username, string Password)
        {
            WebAdmin wa = new WebAdmin();
            wa.InsertToDb(Username, Password);
            return View("index2");
        }
        [HttpPost]
        public ActionResult setp2(string Username, string Password, string RepeatPassword)
        {
            WebAdmin wa = new WebAdmin();
            wa.InsertToDb(Username, Password);
            return View("index2");
        }

    }
}