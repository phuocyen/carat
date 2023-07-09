using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAN.Models;
using DoAN.ViewModel;
using DoAN.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using DoAN.Filters;
using System.Diagnostics;

namespace DoAN.Controllers
{
    //[MyActionFilter]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(int page = 1,string search="")
        {
            Debug.WriteLine("Start Action Index");
            //ViewBag.Number = 10;
            CompanyDB db = new CompanyDB();

           List<Sanpham> sp = db.Sanpham.ToList();
           int NoOfRecordRerPage = 12;
           int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordRerPage)));

           int NoOfRecordToSkip = (page - 1) * NoOfRecordRerPage;
           ViewBag.Page = page;
           ViewBag.NoOfPages = NoOfPages;
           sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordRerPage).ToList();
           return View(sp);
           
        }
        public ActionResult Error404()
        {
            return View();
        }
        }

}
