using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAN.Models;
using DoAN.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using DoAN.ViewModel;
using DoAN.Filters;
using System.Web.SessionState;

namespace DoAN.Controllers
{
    public class SanphamController : Controller
    {
        //Get : SanPham

        //[MyAuthenFilter]
        public ActionResult Index(string sort = "", int page = 1, string search = "")
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

        public ActionResult Detail(int SPId)
        {
            CompanyDB db = new CompanyDB();

            Sanpham sp = db.Sanpham.Where(row => row.IdSP == SPId).FirstOrDefault();
            ViewBag.id = sp.IdSP;
            return View(sp);
        }
        //[HttpPost]
        //public ActionResult Detail(int SPId, int SoLuong)
        //{
        //     AppDbContext db = new AppDbContext();
        //    string curentUserID = User.Identity.GetUserId();
        //    var Cart = db.GioHang.FirstOrDefault(x => x.IdUser == curentUserID && x.IdGioHang == SPId);
        //    if(Cart==null)
        //    {
        //        DonHang Carts = new DonHang();
        //        Carts.IdGioHang = SPId;
        //        Carts.IdUser = curentUserID;
        //        
        //        db.GioHang.Add(Carts);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
                
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Details");
        //}

       
       
    }
}


