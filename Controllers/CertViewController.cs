using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CertApp.DAL;
using CertApp.ViewModel;
using CertApp.Models;

namespace CertApp.Controllers
{
    public class CertViewController : Controller
    {
        private CertContext db = new CertContext();

        public ActionResult Index(string searchColumn, string searchString)
        {
            var searchClmn = searchColumn;
            List<CertView> allCerts = new List<CertView>();

            var certs = db.Certs.Include(c => c.CertRows);
            if (!String.IsNullOrEmpty(searchString))
            {
                certs = filterCerts(certs, searchClmn, searchString);
                foreach (var c in certs)
                {
                    var cert_certrows = db.CertRows.Where(a => a.CertID.Equals(c.ID)).ToList();
                    allCerts.Add(new CertView { cert = c, certRows = cert_certrows });
                }
            }
            else
            {
                certs = db.Certs;
                foreach (var c in certs)
                {
                    var cert_certrows = db.CertRows.Where(a => a.CertID.Equals(c.ID)).ToList();
                    allCerts.Add(new CertView { cert = c, certRows = cert_certrows });
                }
            }

            return View(allCerts);
        }

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

    }
}