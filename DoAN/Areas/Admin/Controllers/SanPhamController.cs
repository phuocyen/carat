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
    public class SanPhamController : Controller
    {
        //
        // GET: /Admin/SanPham/
        public ActionResult Index(string search="",string sort="", int page = 1)
        {
            CompanyDB db = new CompanyDB();
            //List<Sanpham> sp = db.Sanpham.ToList();
            List<Sanpham> sp = db.Sanpham.Where(row => row.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            switch (sort)
            {
                case "up":
                    sp = sp.OrderBy(row => row.Gia).ToList();
                    break;
                case "down":
                    sp = sp.OrderByDescending(row => row.Gia).ToList();
                    break;
                default:
                    break;
            }

            int NoOfRecordRerPage = 12;
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
            Sanpham sp = db.Sanpham.Where(row => row.IdSP == id).FirstOrDefault();
            return View(sp);
        }

        public ActionResult Create()
        {
            CompanyDB db = new CompanyDB();
            ViewBag.Nhasx = db.Nhasx.ToList();
              return View();
        }

        [HttpPost]
        public ActionResult Create(Sanpham p)
        {
            CompanyDB db = new CompanyDB();
            db.Sanpham.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            CompanyDB db = new CompanyDB();
            Sanpham sp = db.Sanpham.Where(row => row.IdSP == id).FirstOrDefault();
           
            ViewBag.Nhasx = db.Nhasx.ToList();
            return View(sp);
        }
    [HttpPost]
        public ActionResult Edit(Sanpham spt)
        {
            CompanyDB db = new CompanyDB();
            Sanpham sp = db.Sanpham.Where(row => row.IdSP == spt.IdSP).FirstOrDefault();
            sp.Name = spt.Name;
            sp.Gia = spt.Gia;
            sp.IdNhasx = spt.IdNhasx;
            sp.Description = spt.Description;
            sp.ImgUrl = spt.ImgUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CompanyDB db = new CompanyDB();
            Sanpham sp = db.Sanpham.Where(row => row.IdSP == id).FirstOrDefault();

            return View(sp);
        }
        [HttpPost]
        public ActionResult Delete(int id,Sanpham spt)
        {
            CompanyDB db = new CompanyDB();
            Sanpham sp = db.Sanpham.Where(row => row.IdSP == id).FirstOrDefault();
            db.Sanpham.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}