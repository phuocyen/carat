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


namespace DoAN.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM rvm)
        {
            if(ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new appUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passHash = Crypto.HashPassword(rvm.Password);

                var user = new AppUser()
                {
                    Email = rvm.Email,
                    UserName=rvm.Username,
                    PasswordHash=passHash,
                    City=rvm.City,
                    Birtday = rvm.DateOfBirth,
                    Adress = rvm.Address,
                    PhoneNumber=rvm.Mobile,


                 };
                IdentityResult identityResult = userManager.Create(user);
                if(identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;

                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                    
                
                }
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();           
            }

           
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM lvm)
        {
            var appDbContext = new AppDbContext();
            var userStore = new appUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);

            var user = userManager.Find(lvm.Username, lvm.Password);
            if(user !=null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                 if(userManager.IsInRole(user.Id,"Admin"))
                 {
                     return RedirectToAction("Index", "Home", new { area = "Admin" });
                 }
                 else
                 {
                     return RedirectToAction("Index", "Home");
           
                 }
            }
            else
            {
                ModelState.AddModelError("myError", "Invalib username and password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

	}
}