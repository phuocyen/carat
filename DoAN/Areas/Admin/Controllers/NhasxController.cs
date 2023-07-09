using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAN.Models;
using DoAN.Filters;

namespace DoAN.Areas.Admin.Controllers
{
        [AdminAuthorization]

    public class NhasxController : Controller
    {
        //
        // GET: /Admin/Nhasx/
         public ActionResult Index(string sort="", int page = 1,string search="")
        {
            CompanyDB db = new CompanyDB();
            //List<Nhasx> sp = db.Nhasx.ToList();
            List<Nhasx> sp = db.Nhasx.Where(row => row.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            switch (sort)
            {
                case "up":
                    sp = sp.OrderBy(row => row.Name).ToList();
                    break;
                case "down":
                    sp = sp.OrderByDescending(row => row.Name).ToList();
                    break;
                default:
                    break;
            }

            int NoOfRecordRerPage = 9;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordRerPage)));

            int NoOfRecordToSkip = (page - 1) * NoOfRecordRerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordRerPage).ToList();
            return View(sp);
        }

        public ActionResult Detail(int id)
        {
            CompanyDB db = new CompanyDB();
            Nhasx sp = db.Nhasx.Where(row => row.IdNhasx == id).FirstOrDefault();
            return View(sp);
        }

        public ActionResult Create()
        {
            CompanyDB db = new CompanyDB();
            ViewBag.Nhasx = db.Nhasx.ToList();
              return View();
        }

        [HttpPost]
        public ActionResult Create(Nhasx p)
        {
            CompanyDB db = new CompanyDB();
            db.Nhasx.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            CompanyDB db = new CompanyDB();
            Nhasx sp = db.Nhasx.Where(row => row.IdNhasx == id).FirstOrDefault();
           
            ViewBag.Nhasx = db.Nhasx.ToList();
            return View(sp);
        }
    [HttpPost]
        public ActionResult Edit(Nhasx spt)
        {
            CompanyDB db = new CompanyDB();
            Nhasx sp = db.Nhasx.Where(row => row.IdNhasx == spt.IdNhasx).FirstOrDefault();
            sp.Name = spt.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CompanyDB db = new CompanyDB();
            Nhasx sp = db.Nhasx.Where(row => row.IdNhasx == id).FirstOrDefault();

            return View(sp);
        }
        [HttpPost]
        public ActionResult Delete(int id,Nhasx spt)
        {
            CompanyDB db = new CompanyDB();
            Nhasx sp = db.Nhasx.Where(row => row.IdNhasx == id).FirstOrDefault();
            db.Nhasx.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}
