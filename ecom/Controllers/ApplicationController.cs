using ECM.DAL;
using ecom.Models;
using ecom.Models.MSDB;
using ecom.Models.WCAFhr;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ecom.Controllers
{
    public class ApplicationController : Controller
    {
        private MSDBContext _db = new MSDBContext();
        private WCAFhrContext _hr = new WCAFhrContext();

        public ApplicationController()
        {
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

        }

        [AllowAnonymous]
        public ActionResult Report()
        {
            if (Session["temp_report"] == null)
            {
                return RedirectToAction("Login", "Application");
            }

            IQueryable<EcomCert_Status> ecomCertStatusQuery = _db.EcomCert_Status.AsNoTracking()
                .Where(x => x.StatusID == 2)
                .OrderBy(x => x.CertID);

            IEnumerable<int> certIDs = ecomCertStatusQuery.Select(x => x.CertID).ToList();

            IEnumerable<EcomCert_CompDetail> certs = _db.EcomCert_CompDetail.AsNoTracking()
                .Where(x => certIDs.Contains(x.CertID))
                .ToList();

            return View(certs);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.Form["login_name"] == "wcaecom_rpcm")
            {
                Session["temp_report"] = "temp_report";

                return RedirectToAction("Report", "Application");
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult ReportCertified(int id)
        {
            /*if (Request.UrlReferrer == null || (Request.UrlReferrer != null && Request.UrlReferrer.AbsoluteUri != "http://wcaecommerce.wcaworld.com/eng/report_cert.asp"))
            {
                return RedirectToAction("Login", "Account");
            }*/

            if (Session["temp_report"] == null)
            {
                return RedirectToAction("Login", "Application");
            }

            //int Cid = Convert.ToInt32(HttpContext.Session["Cid"]);
            int CertId = id;

            int Cid = _db.EcomCerts.Where(r => r.CertID == CertId).FirstOrDefault().Cid;

            if (Cid == 0)
            {
                //redirec to login
            }

            ViewMember member = _db.Members.AsNoTracking()
                .Include(x => x.Memberships)
                .Include(x => x.Memberships.Select(y => y.Network))
                .FirstOrDefault(x => x.Cid == Cid && x.Nid == 103);

            if (member == null)
            {
                //redirec to logi
            }

            CertifiedMemberApplicationView model = new CertifiedMemberApplicationView();

            model.Company = member;
            model.Company.Memberships = member.Memberships;

            model.EcomCert.Cid = Cid;
            model.Company_Detail.CompName = member.Company;

            EcomCert cert = _db.EcomCerts.AsNoTracking()
                .FirstOrDefault(x => x.Cid == Cid);

            if (cert != null)
            {
                int StatusId = _db.EcomCert_Status.AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.StatusID)
                    .FirstOrDefault();

                // Status
                model.Status = StatusId == 1 ? "draft" : "submitted";


                // Company detail
                EcomCert_CompDetail companyDetail = _db.EcomCert_CompDetail
                    .Find(cert.CertID);

                model.Company_Detail = companyDetail;

                IEnumerable<int> productsHandled = _db.EcomCert_Product_Handled
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.ProductId)
                    .ToList();
                model.Products_Handled = productsHandled;

                // Company service
                EcomCert_Service companyService = _db.EcomCert_Service
                    .Find(cert.CertID);

                // Company service: services provide
                IEnumerable<int> companyServicesProvide = _db.EcomCert_Service_Provide
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.ServiceId)
                    .ToList();

                model.Company_Service = companyService;
                model.Services = companyServicesProvide;

                // Company service cross-border service provide
                model.CrossBorderServices = _db.EcomCert_Service_CrossBorder
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.CrossBorderId)
                    .ToList();

                // Company service: GroundServices
                model.GroundServices = _db.EcomCert_Service_Ground
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.GroundServiceId)
                    .ToList();

                // Company service: TransportFleets
                model.TransportFleets = _db.EcomCert_Service_TransportFleet
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.TransportFleetId)
                    .ToList();

                // Company service: PayOnDelivery
                model.PayOnDelivery = _db.EcomCert_Service_PayOnDelivery
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.PaymentTypeId)
                    .ToList();

                // Company service: InternalBounds
                model.InternalBounds = _db.EcomCert_Service_InternalBound
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.InternalBoundId)
                    .ToList();

                // Company IT
                EcomCert_IT companyIT = _db.EcomCert_IT
                    .Find(cert.CertID);

                model.Company_IT = companyIT;
            }

            return View(model);
        }

        //[Authorize]
        public ActionResult Certified(int cId = 0)
        {
            int Cid = cId == 0 ? Convert.ToInt32(HttpContext.Session["Cid"]) : cId;

            ViewMember member = _db.Members.AsNoTracking()
                .Include(x => x.Memberships)
                .Include(x => x.Memberships.Select(y => y.Network))
                .FirstOrDefault(x => x.Cid == Cid && x.Nid == 103);

            if (member == null)
            {
                //redirec to login
                return RedirectToAction("Login", "Account", new { returnUrl = "application/certified" });
            }

            CertifiedMemberApplicationView model = new CertifiedMemberApplicationView();

            model.Company = member;
            model.Company.Memberships = member.Memberships;

            model.EcomCert.Cid = Cid;
            model.Company_Detail.CompName = member.Company;

            EcomCert cert = _db.EcomCerts.AsNoTracking()
                .FirstOrDefault(x => x.Cid == Cid);

            if (cert != null)
            {
                int StatusId = _db.EcomCert_Status.AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.StatusID)
                    .FirstOrDefault();

                // Status
                model.Status = StatusId == 1 ? "draft" : "submitted";


                // Company detail
                EcomCert_CompDetail companyDetail = _db.EcomCert_CompDetail
                    .Find(cert.CertID);

                model.Company_Detail = companyDetail == null ? new EcomCert_CompDetail() : companyDetail;

                IEnumerable<int> productsHandled = _db.EcomCert_Product_Handled
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.ProductId)
                    .ToList();
                model.Products_Handled = productsHandled;

                // Company service
                EcomCert_Service companyService = _db.EcomCert_Service
                    .Find(cert.CertID);

                // Company service: services provide
                IEnumerable<int> companyServicesProvide = _db.EcomCert_Service_Provide
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.ServiceId)
                    .ToList();

                model.Company_Service = companyService == null ? new EcomCert_Service() : companyService;
                model.Services = companyServicesProvide;

                // Company service cross-border service provide
                model.CrossBorderServices = _db.EcomCert_Service_CrossBorder
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.CrossBorderId)
                    .ToList();

                // Company service: GroundServices
                model.GroundServices = _db.EcomCert_Service_Ground
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.GroundServiceId)
                    .ToList();

                // Company service: TransportFleets
                model.TransportFleets = _db.EcomCert_Service_TransportFleet
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.TransportFleetId)
                    .ToList();

                // Company service: PayOnDelivery
                model.PayOnDelivery = _db.EcomCert_Service_PayOnDelivery
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.PaymentTypeId)
                    .ToList();

                // Company service: InternalBounds
                model.InternalBounds = _db.EcomCert_Service_InternalBound
                    .AsNoTracking()
                    .Where(x => x.CertID == cert.CertID)
                    .Select(x => x.InternalBoundId)
                    .ToList();

                // Company IT
                EcomCert_IT companyIT = _db.EcomCert_IT
                    .Find(cert.CertID);

                model.Company_IT = companyIT == null ? new EcomCert_IT() : companyIT;
            }

            return View(model);
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Certified(CertifiedMemberApplicationView model, string btn_save, HttpPostedFileBase file)
        {
            try
            {
                if (model != null && model.EcomCert != null)
                {
                    // Application
                    EcomCert cert = CreateEcomCertIfNotExists(model.EcomCert.Cid);

                    // Application status
                    InsertOrUpdateCertifidMemberApplicationStatus(cert.CertID, btn_save);

                    // Company details
                    InsertOrUpdateCompanyDetail(cert.CertID, model.Company_Detail);

                    // Products Handles
                    InsertOrUpdateProductsHandled(cert.CertID, model.Products_Handled);

                    // Company Services
                    InsertOrUpdateCompanyServices(cert.CertID, model.Company_Service);

                    // Company Service Provide
                    InsertOrUpdateCompanyServicesProvide(cert.CertID, model.Services);

                    // Company Service Cross-Border
                    InsertOrUpdateCompanyServicesCrossBorder(cert.CertID, model.CrossBorderServices);

                    // EcomCert_Service_Ground
                    InsertOrUpdateCompanyServicesGround(cert.CertID, model.GroundServices);

                    // EcomCert_Service_TransportFleet
                    InsertOrUpdateCompanyServicesFleet(cert.CertID, model.TransportFleets);

                    // EcomCert_Service_PayOnDelivery
                    InsertOrUpdateCompanyServicesPayOnDelivery(cert.CertID, model.PayOnDelivery);

                    // EcomCert_Service_InternalBound
                    InsertOrUpdateCompanyServicesInternalBound(cert.CertID, model.InternalBounds);

                    // EcomCert_Service_GeoCoverage
                    //InsertOrUpdateCompanyServicesGeoCoverage(cert.CertID,model.g)

                    // EcomCert_IT
                    InsertOrUpdateCompanyIT(cert.CertID, model.Company_IT);

                    // File uploading
                    // Verify that the user selected a file
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the filename
                        string fileName = Path.GetFileName(file.FileName);

                        // upload directory
                        string basePath = "~/uploads";

                        string path = Path.Combine(Server.MapPath(basePath), fileName);
                        file.SaveAs(path);

                        model.Company_IT.YN_EDIImage_File = fileName;

                        // EcomCert_IT
                        InsertOrUpdateCompanyIT(cert.CertID, model.Company_IT);
                    }

                    if (btn_save == "submit")
                    {
                        // Get member data
                        ViewMember member = _db.Members
                            .AsNoTracking()
                            .FirstOrDefault(x => x.Cid == cert.Cid && x.Nid == 103);

                        int repID = _db.SalesRep
                            .AsNoTracking()
                            .Where(x => x.IsActive && x.Nid == 103 && x.TypeCode == "Rep")
                            .Where(x => x.CountryCode == member.Country)
                            .Select(x => x.EmpID)
                            .FirstOrDefault();

                        //Sales Rep
                        Employee emp = _hr.Employees
                            .AsNoTracking()
                            .FirstOrDefault(x => x.EmployeeID == repID);

                        string repEmail = emp == null ? "" : emp.Email;

                        // Mail to salesrep and Alex
                        string body = "<p>A new certification from: {0}</p>";
                        body += "<p>The WCA eCommerce Certified Member Application report can be found here:</p>";
                        body += "<p><a href=\"http://wcaecommerce.wcaworld.com/application/report\">http://wcaecommerce.wcaworld.com/application/report</a>";
                        body += "<p>password: wcaecom_rpcm</p>";

                        var message = new MailMessage();

                        message.To.Add(new MailAddress("alex@wcaworld.com"));
                        message.To.Add(new MailAddress("mrane@wcaworld.com"));
                        message.To.Add(new MailAddress(repEmail));
                        message.Bcc.Add(new MailAddress("paak@wcaworld.com"));

                        message.Subject = "A new certification waiting for verification.";
                        message.Body = string.Format(body, model.Company_Detail.CompName);
                        message.IsBodyHtml = true;

                        using (var smtp = new SmtpClient())
                        {
                            smtp.Send(message);
                        }

                        // Mail to member
                        IEnumerable<ViewContact> contacts = _db.ViewContacts
                            .AsNoTracking()
                            .Where(x => x.Selected == true)
                            .Where(x => x.Deleted == false)
                            .Where(x => x.NId == 103)
                            .Where(x => x.CId == cert.Cid)
                            .ToList();
                        if (contacts.Count() != 0)
                        {
                            string bodyToMember = string.Format("The request is submitted and pending for approval. You may contact <a href='mailto:{0}'>{0}</a> for any questions.", repEmail);

                            MailMessage messageToMember = new MailMessage();

                            foreach (ViewContact contact in contacts)
                            {
                                messageToMember.To.Add(new MailAddress(contact.Email + ".th"));
                            }
                            messageToMember.Bcc.Add(new MailAddress("paak@wcaworld.com"));

                            messageToMember.Subject = "The request is submitted and pending for approval.";
                            messageToMember.Body = bodyToMember;
                            messageToMember.IsBodyHtml = true;

                            using (var smtp = new SmtpClient())
                            {
                                // If live email will send to member
                                if (AppSetting.GetIsLive)
                                {
                                    smtp.Send(messageToMember);
                                }
                            }
                        }
                    }
                }

                return RedirectToAction("Certified");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Certified");
            }
        }

        private EcomCert CreateEcomCertIfNotExists(int cId)
        {
            // Check if already created
            EcomCert cert = _db.EcomCerts
                .AsNoTracking()
                .FirstOrDefault(x => x.Cid == cId);

            // If no recorad create new
            if (cert == null)
            {
                cert = new EcomCert();
                cert.Cid = cId;
                cert.CreateDate = DateTime.Now;

                _db.EcomCerts.Add(cert);
                _db.SaveChanges();
            }

            return cert;
        }

        private void InsertOrUpdateCertifidMemberApplicationStatus(int certId, string status)
        {
            // EcomCert_Status
            EcomCert_Status certStatus = _db.EcomCert_Status
                .AsNoTracking()
                .FirstOrDefault(x => x.CertID == certId);

            using (MSDBContext db = new MSDBContext())
            {
                if (certStatus == null)
                {
                    certStatus = new EcomCert_Status();
                    certStatus.CertID = certId;
                    certStatus.StatusID = status == "save" ? 1 : 2;

                    db.EcomCert_Status.Add(certStatus);
                }
                else
                {
                    certStatus.StatusID = status == "save" ? 1 : 2;

                    db.EcomCert_Status.Attach(certStatus);
                    db.Entry(certStatus).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
        }

        private void InsertOrUpdateCompanyDetail(int certId, EcomCert_CompDetail companyDetail)
        {
            // Company Details
            EcomCert_CompDetail certCompanyDetail = _db.EcomCert_CompDetail
                .Find(certId);

            // save modified entity using new Context
            using (MSDBContext db = new MSDBContext())
            {
                if (certCompanyDetail == null)
                {
                    certCompanyDetail = companyDetail;

                    certCompanyDetail.CertID = certId;
                    certCompanyDetail.CreateDate = DateTime.Now;

                    db.EcomCert_CompDetail.Add(certCompanyDetail);
                }
                else
                {
                    certCompanyDetail = companyDetail;

                    certCompanyDetail.CertID = certId;
                    certCompanyDetail.ModifiedDate = DateTime.Now;

                    db.EcomCert_CompDetail.Attach(certCompanyDetail);
                    db.Entry(certCompanyDetail).State = EntityState.Modified;
                }

                // SaveChanges
                db.SaveChanges();
            }
        }

        private void InsertOrUpdateProductsHandled(int certId, IEnumerable<int> productIds)
        {
            if (productIds.Count() > 0)
            {
                _db.Database.ExecuteSqlCommand("DELETE FROM EcomCert_Product_Handled WHERE CertID = {0}", certId);

                foreach (int productId in productIds)
                {
                    EcomCert_Product_Handled productsHandled = new EcomCert_Product_Handled();
                    productsHandled.CertID = certId;
                    productsHandled.ProductId = productId;

                    _db.EcomCert_Product_Handled.Add(productsHandled);
                    _db.SaveChanges();
                }
            }

        }

        private void InsertOrUpdateCompanyServices(int certId, EcomCert_Service companyService)
        {
            // Company Services
            EcomCert_Service certCompanyServices = _db.EcomCert_Service
                .Find(certId);

            using (MSDBContext db = new MSDBContext())
            {
                // Add new record
                if (certCompanyServices == null)
                {
                    certCompanyServices = new EcomCert_Service();
                    certCompanyServices = companyService;

                    certCompanyServices.CertID = certId;
                    certCompanyServices.CreatedDate = DateTime.Now;

                    db.EcomCert_Service.Add(certCompanyServices);
                }
                // Update existing
                else
                {
                    certCompanyServices = companyService;

                    certCompanyServices.CertID = certId;
                    certCompanyServices.ModifiedDate = DateTime.Now;

                    db.EcomCert_Service.Attach(certCompanyServices);
                    db.Entry(certCompanyServices).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
        }

        private void InsertOrUpdateCompanyServicesProvide(int certId, IEnumerable<int> serviceIds)
        {
            if (serviceIds.Count() > 0)
            {
                _db.Database.ExecuteSqlCommand("DELETE FROM EcomCert_Service_Provide WHERE CertID = {0}", certId);

                foreach (int serviceId in serviceIds)
                {
                    EcomCert_Service_Provide servicesProvide = new EcomCert_Service_Provide();
                    servicesProvide.CertID = certId;
                    servicesProvide.ServiceId = serviceId;

                    _db.EcomCert_Service_Provide.Add(servicesProvide);
                    _db.SaveChanges();
                }
            }
        }

        private void InsertOrUpdateCompanyServicesCrossBorder(int certId, IEnumerable<int> crossborderIds)
        {
            if (crossborderIds.Count() > 0)
            {
                _db.Database.ExecuteSqlCommand("DELETE FROM EcomCert_Service_CrossBorder WHERE CertID = {0}", certId);

                foreach (int crossborderId in crossborderIds)
                {
                    EcomCert_Service_CrossBorder crossborder = new EcomCert_Service_CrossBorder();
                    crossborder.CertID = certId;
                    crossborder.CrossBorderId = crossborderId;

                    _db.EcomCert_Service_CrossBorder.Add(crossborder);
                    _db.SaveChanges();
                }
            }
        }

        private void InsertOrUpdateCompanyServicesGround(int certId, IEnumerable<int> groundServiceIds)
        {
            if (groundServiceIds.Count() > 0)
            {
                _db.Database.ExecuteSqlCommand("DELETE FROM EcomCert_Service_Ground WHERE CertID = {0}", certId);

                foreach (int groundServiceId in groundServiceIds)
                {
                    EcomCert_Service_Ground groundService = new EcomCert_Service_Ground();
                    groundService.CertID = certId;
                    groundService.GroundServiceId = groundServiceId;

                    _db.EcomCert_Service_Ground.Add(groundService);
                    _db.SaveChanges();
                }
            }
        }

        private void InsertOrUpdateCompanyServicesFleet(int certId, IEnumerable<int> fleetIds)
        {
            if (fleetIds.Count() > 0)
            {
                _db.Database.ExecuteSqlCommand("DELETE FROM EcomCert_Service_TransportFleet WHERE CertID = {0}", certId);

                foreach (int fleetId in fleetIds)
                {
                    EcomCert_Service_TransportFleet transportFleet = new EcomCert_Service_TransportFleet();
                    transportFleet.CertID = certId;
                    transportFleet.TransportFleetId = fleetId;

                    _db.EcomCert_Service_TransportFleet.Add(transportFleet);
                    _db.SaveChanges();
                }
            }
        }

        private void InsertOrUpdateCompanyServicesPayOnDelivery(int certId, IEnumerable<int> paymentTypeIds)
        {
            if (paymentTypeIds.Count() > 0)
            {
                _db.Database.ExecuteSqlCommand("DELETE FROM EcomCert_Service_PayOnDelivery WHERE CertID = {0}", certId);

                foreach (int paymentTypeId in paymentTypeIds)
                {
                    EcomCert_Service_PayOnDelivery payOnDelivery = new EcomCert_Service_PayOnDelivery();
                    payOnDelivery.CertID = certId;
                    payOnDelivery.PaymentTypeId = paymentTypeId;

                    _db.EcomCert_Service_PayOnDelivery.Add(payOnDelivery);
                    _db.SaveChanges();
                }
            }
        }

        private void InsertOrUpdateCompanyServicesInternalBound(int certId, IEnumerable<int> boundIds)
        {
            if (boundIds.Count() > 0)
            {
                _db.Database.ExecuteSqlCommand("DELETE FROM EcomCert_Service_InternalBound WHERE CertID = {0}", certId);

                foreach (int boundId in boundIds)
                {
                    EcomCert_Service_InternalBound internalBound = new EcomCert_Service_InternalBound();
                    internalBound.CertID = certId;
                    internalBound.InternalBoundId = boundId;

                    _db.EcomCert_Service_InternalBound.Add(internalBound);
                    _db.SaveChanges();
                }
            }
        }

        private void InsertOrUpdateCompanyServicesGeoCoverage(int certId, IEnumerable<int> coverageIds)
        {
            if (coverageIds.Count() > 0)
            {
                _db.Database.ExecuteSqlCommand("DELETE FROM EcomCert_Service_GeoCoverage WHERE CertID = {0}", certId);

                foreach (int coverageId in coverageIds)
                {
                    EcomCert_Service_GeoCoverage geoCoverage = new EcomCert_Service_GeoCoverage();
                    geoCoverage.CertID = certId;
                    geoCoverage.GeoCoverageId = coverageId;

                    _db.EcomCert_Service_GeoCoverage.Add(geoCoverage);
                    _db.SaveChanges();
                }
            }
        }

        private void InsertOrUpdateCompanyIT(int certId, EcomCert_IT companyIT)
        {
            if (companyIT == null)
            {
                return;
            }

            EcomCert_IT ecomCompanyIT = _db.EcomCert_IT
                .AsNoTracking()
                .FirstOrDefault(x => x.CertID == certId);

            using (MSDBContext db = new MSDBContext())
            {
                if (ecomCompanyIT == null)
                {
                    ecomCompanyIT = companyIT;

                    ecomCompanyIT.CertID = certId;
                    ecomCompanyIT.CreatedDate = DateTime.Now;

                    db.EcomCert_IT.Add(companyIT);
                }
                else
                {
                    ecomCompanyIT = companyIT;

                    ecomCompanyIT.CertID = certId;
                    ecomCompanyIT.ModifiedDate = DateTime.Now;

                    db.EcomCert_IT.Attach(ecomCompanyIT);
                    db.Entry(ecomCompanyIT).State = EntityState.Modified;
                }

                db.SaveChanges();
            }

        }


        private void SendEmail()
        {

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
