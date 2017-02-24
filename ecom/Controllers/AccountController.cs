using ECM.DAL;
using ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ecom.Controllers
{
    public class AccountController : Controller
    {
        private MSDBContext _db = new MSDBContext();

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
            {
                return View(model);
            }

            IQueryable<ViewMember> query = _db.Members.AsNoTracking()
                .Where(x => x.Username == model.Username)
                .Where(x => x.Password == model.Password);

            //bool isValid = query.Count() > 0 ? true : false;
            int Cid = query.Select(x => x.Cid).FirstOrDefault();

            if (Cid > 0)
            {
                //LoginInfo loginInfo = new ecom.LoginInfo();

                HttpContext.Session.Add("Cid", Cid);

                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1,
                    model.Username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    model.RememberMe,
                    "your custom data");

                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (model.RememberMe)
                {
                    ck.Expires = tkt.Expiration;
                }
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                return RedirectToLocal(returnUrl);
            }
            else
            {
                return View(model);
            }
        }

        // POST: Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout(LoginViewModel logOn)
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}