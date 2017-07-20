using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CertApp.DAL;
using CertApp.Models;
using Newtonsoft.Json;

namespace CertApp.Controllers
{
    public class CertsController : Controller
    {
        private CertContext db = new CertContext();
                
        // GET: Certs
        
        public ActionResult Index(string searchColumn, string searchString)
        {
            
            var searchClmn = searchColumn;
            
            var certs = db.Certs.Include(c => c.CertRows);
            if (!String.IsNullOrEmpty(searchString))
                certs = filterCerts(certs, searchClmn, searchString);
            
            return View(certs.ToList());
        }
        /*
        public ActionResult Index()
        {
            return View();
        }
        */
        
        public IQueryable<Cert> filterCerts(IQueryable<Cert> certs, String searchClmn, String searchString)
        {
            if (searchClmn == "ApplicantName")
            {
                try
                {
                    certs = certs.Where(c => c.ApplicantName.Contains(searchString));
                }
                catch { }
            }
            else if (searchClmn == "InspectionDate")
            {
                try
                {
                    DateTime date = DateTime.ParseExact(searchString, "yyyy-MM-dd", null);
                    certs = certs.Where(c => c.InspectionDate == date);
                }
                catch
                { }


            }
            else if (searchClmn == "ApplicantEmail")
                try
                {
                    certs = certs.Where(c => c.ApplicantEmail.Contains(searchString));
                }
                catch { }

            return certs;
        }

        // GET: Certs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cert cert = db.Certs.Find(id);
            if (cert == null)
            {
                return HttpNotFound();
            }
            return View(cert);
        }

        // GET: Certs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CertNum,SupersededCertNum,PreviousCertNum,InspectionDate,ApplicantName,ApplicantContact,ApplicantAddr,ApplicantAddr2,ApplicantCity,ApplicantState,ApplicantZip,ApplicantPhone,ApplicantEmail,ApplicantFax,SourceFile,Created,InspectorName,AMSInspectorOffice")] Cert cert)
        {
            if (ModelState.IsValid)
            {
                db.Certs.Add(cert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cert);
        }

        // GET: Certs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cert cert = db.Certs.Find(id);
            if (cert == null)
            {
                return HttpNotFound();
            }
            return View(cert);
        }

        // POST: Certs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CertNum,SupersededCertNum,PreviousCertNum,InspectionDate,ApplicantName,ApplicantContact,ApplicantAddr,ApplicantAddr2,ApplicantCity,ApplicantState,ApplicantZip,ApplicantPhone,ApplicantEmail,ApplicantFax,SourceFile,Created,LastUpdate,InspectorName,AMSInspectorOffice")] Cert cert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cert);
        }

        // GET: Certs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cert cert = db.Certs.Find(id);
            if (cert == null)
            {
                return HttpNotFound();
            }
            return View(cert);
        }

        // POST: Certs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cert cert = db.Certs.Find(id);
            db.Certs.Remove(cert);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
