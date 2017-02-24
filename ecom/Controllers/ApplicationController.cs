using ECM.DAL;
using ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecom.Controllers
{
    public class ApplicationController : Controller
    {
        private MSDBContext _db = new MSDBContext();

        [Authorize]
        public ActionResult Certified()
        {
            int Cid = Convert.ToInt32(HttpContext.Session["Cid"]);

            if (Cid == 0)
            {
                //redirec to logi
            }

            ViewMember member = _db.Members.AsNoTracking()
                //.Include(x => x.Member)
                .FirstOrDefault(x => x.Cid == Cid);
            if (member == null)
            {
                //redirec to logi
            }

            CertifiedMemberApplicationView model = new Models.CertifiedMemberApplicationView();

            model.Company = member;
            model.Company.Memberships = member.Memberships;

            model.EcomCert.Cid = Cid;
            model.Company_Detail.CompName = member.Company;

            /* Master Data */
            ViewBag.AveragePackageWeight = _db.EcomCert_AvgPackageWeights.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            ViewBag.Products = _db.EcomCert_Products.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            ViewBag.Services = _db.EcomCert_Service_Master.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            ViewBag.CrossBorderServices = _db.EcomCert_CrossBorders.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            ViewBag.GroundServices = _db.EcomCert_GroundServices.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            ViewBag.TransportFleets = _db.EcomCert_TransportFleets.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            ViewBag.GeoCoverages = _db.EcomCert_GeoCoverages.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            ViewBag.PaymentTypes = _db.EcomCert_PaymentTypes.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            ViewBag.InternalBounds = _db.EcomCert_InternalBounds.AsNoTracking()
                .Where(x => x.IsActive == true)
                .ToList();

            return View(model);
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Certified(CertifiedMemberApplicationView model)
        {
            try
            {
                // TODO: Add insert logic here
                if (model != null)
                {

                }

                return RedirectToAction("Certified");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Application/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Certified");
            }
            catch
            {
                return View();
            }
        }
    }
}
