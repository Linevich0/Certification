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

namespace CertApp.Controllers
{
    public class CertRowsController : Controller
    {
        private CertContext db = new CertContext();

        // GET: CertRows
        public ActionResult Index()
        {
            var certRows = db.CertRows.Include(c => c.Cert);
            return View(certRows.ToList());
        }

        // GET: CertRows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertRow certRow = db.CertRows.Find(id);
            if (certRow == null)
            {
                return HttpNotFound();
            }
            return View(certRow);
        }

        // GET: CertRows/Create
        public ActionResult Create()
        {
            ViewBag.CertID = new SelectList(db.Certs, "ID", "CertNum");
            return View();
        }

        // POST: CertRows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CertID,CustomsEntryNum,HTSCodeDescript,TotalWeight,Results,FDAStatus,UnitOfMeasure,NumOfPackages,InspectionLotIdNos,CBPContainerLotID")] CertRow certRow)
        {
            if (ModelState.IsValid)
            {
                db.CertRows.Add(certRow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CertID = new SelectList(db.Certs, "ID", "CertNum", certRow.CertID);
            return View(certRow);
        }

        // GET: CertRows/Create
        public ActionResult CreateByID(int id)
        {
            //var defualtVal = id;
            ViewBag.defualtCertID = id;
            ViewBag.CertID = new SelectList(db.Certs, "ID", "ID", id);
            return View();
        }


        // GET: CertRows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertRow certRow = db.CertRows.Find(id);
            if (certRow == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertID = new SelectList(db.Certs, "ID", "CertNum", certRow.CertID);
            return View(certRow);
        }

        // POST: CertRows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CertID,CustomsEntryNum,HTSCodeDescript,TotalWeight,Results,FDAStatus,UnitOfMeasure,NumOfPackages,InspectionLotIdNos,CBPContainerLotID")] CertRow certRow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certRow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CertID = new SelectList(db.Certs, "ID", "CertNum", certRow.CertID);
            return View(certRow);
        }

        // GET: CertRows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertRow certRow = db.CertRows.Find(id);
            if (certRow == null)
            {
                return HttpNotFound();
            }
            return View(certRow);
        }

        // POST: CertRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CertRow certRow = db.CertRows.Find(id);
            db.CertRows.Remove(certRow);
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
