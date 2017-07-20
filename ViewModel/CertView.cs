using CertApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CertApp.ViewModel
{
    public class CertView
    {
        public Cert cert { get; set; }
        public List<CertRow> certRows { get; set; }
    }
}