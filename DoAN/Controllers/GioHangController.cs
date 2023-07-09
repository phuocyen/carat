using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAN.Models;
using  DoAN.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using DoAN.ViewModel;

namespace DoAN.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        public ActionResult Index()
        {
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            return View(giohang);
        }
        
        public ActionResult ThemVaoGioHang(int idSanPHam)
        {
            // AppDbContext db = new AppDbContext();
            //string curenUserID = User.Identity.GetUserId();
            //var cart = db.GioHangs.FirstOrDefault(x => x.UserID == curenUserID && x.IdProduct == idSanPHam);
            //GioHang GHang = new GioHang();
            //GHang.IdProduct = idSanPHam;
            //GHang.UserID = curenUserID;
          
            //if(GHang == null)
            //{
            //    GHang.Quantity = 1;
            //    db.GioHangs.Add(GHang);
            //    db.SaveChanges();
            //}
            //else
            //{
              
            //    cart.Quantity += 1;
            //    db.SaveChanges();
            //}
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<GioHang>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }
            string curenUserID = User.Identity.GetUserId();
             AppDbContext db = new AppDbContext();
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;  // Gán qua biến giohang dễ code
            var cart = db.GioHangs.FirstOrDefault(x => x.UserID == curenUserID && x.IdProduct == (int)idSanPHam);
            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.IdProduct == (int)idSanPHam) == null) // ko co sp nay trong gio hang
            {
                GioHang GHang = new GioHang();
                GHang.IdProduct = (int)idSanPHam;
                GHang.UserID = curenUserID;
                // Tạo ra 1 CartItem mới

                giohang.Add(GHang);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                GioHang cardItem = giohang.FirstOrDefault(m => m.IdProduct == idSanPHam);
                cardItem.Quantity++;
            }
            return RedirectToAction("Detail", "SanPham", new { id =(int)idSanPHam });
        }
	}
}