using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAN.Identity;
using DoAN.ViewModel;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using DoAN.Filters;

namespace DoAN.Areas.Admin.Controllers
{
        [AdminAuthorization]

    public class UserController : Controller
    {
        //
        // GET: /Admin/User/
        public ActionResult Index(string search = "", string sort = "", int page = 1)
        {
            AppDbContext db = new AppDbContext();
            List<AppUser> users = db.Users.Where(row => row.UserName.Contains(search)).ToList();
            ViewBag.Search = search;
            switch (sort)
            {
                case "up":
                    users = users.OrderBy(row => row.UserName).ToList();
                    break;
                case "down":
                    users = users.OrderByDescending(row => row.UserName).ToList();
                    break;
                default:
                    break;
            }

            int NoOfRecordRerPage = 12;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(users.Count) / Convert.ToDouble(NoOfRecordRerPage)));

            int NoOfRecordToSkip = (page - 1) * NoOfRecordRerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            users = users.Skip(NoOfRecordToSkip).Take(NoOfRecordRerPage).ToList();
         
            return View(users);
        }

        public ActionResult Detail(string id)
        {
            AppDbContext db = new AppDbContext();
            AppUser sp = db.Users.Where(row => row.Id == id).FirstOrDefault();
            return View(sp);
        }

        public ActionResult Create()
        {
            AppDbContext db = new AppDbContext();
            ViewBag.Users = db.Users.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterVM rvm)
        {
            ////if (ModelState.IsValid)
            ////{
                var appDbContext = new AppDbContext();
                var userStore = new appUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passHash = Crypto.HashPassword(rvm.Password);

                var user = new AppUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.Username,
                    PasswordHash = passHash,
                    City = rvm.City,
                    Birtday = rvm.DateOfBirth,
                    Adress = rvm.Address,
                    PhoneNumber = rvm.Mobile,


                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;

                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    //authenManager.SignIn(new AuthenticationProperties(), userIdentity);


                }
                return RedirectToAction("Index", "User");
                //}
                //else
                //{
                //    ModelState.AddModelError("New Error", "Invalid Data");
                //    return View();
                //}

            ////}
        }

        public ActionResult Edit(string id)
        {
            AppDbContext db = new AppDbContext();
            AppUser sp = db.Users.Where(row => row.Id == id).FirstOrDefault();

            ViewBag.Users = db.Users.ToList();
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(AppUser spt)
        {
            AppDbContext db = new AppDbContext();
            AppUser sp = db.Users.Where(row => row.Id == spt.Id).FirstOrDefault();
            sp.UserName = spt.UserName;
            sp.Email = spt.Email;
            sp.Adress = spt.Adress;
            sp.Birtday = spt.Birtday;
            sp.City = spt.City;
            sp.PhoneNumber = spt.PhoneNumber;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            AppDbContext db = new AppDbContext();
            AppUser sp = db.Users.Where(row => row.Id == id).FirstOrDefault();

            return View(sp);
        }
        [HttpPost]
        public ActionResult Delete(string id, AppUser spt)
        {
            AppDbContext db = new AppDbContext();
            AppUser sp = db.Users.Where(row => row.Id == id).FirstOrDefault();
            db.Users.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}