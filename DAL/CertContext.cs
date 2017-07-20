using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CertApp.DAL
{
    public class CertContext : DbContext
    {
        public CertContext() : base("CertContext")
        {
        }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<CertApp.Models.Cert> Certs { get; set; }

        public System.Data.Entity.DbSet<CertApp.Models.CertRow> CertRows { get; set; }
    }
}