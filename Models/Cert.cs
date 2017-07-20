using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CertApp.Models
{
    public class Cert
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Certificate number")]
        public String CertNum { get; set; }
        [StringLength(50)]
        public String SupersededCertNum { get; set; }
        [StringLength(250)]
        public String PreviousCertNum { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InspectionDate { get; set; }
        [Required]
        [Display(Name = "Applicant name")]
        public String ApplicantName { get; set; }
        [Display(Name = "Applicant Contact")]
        public String ApplicantContact { get; set; }
        public String ApplicantAddr { get; set; }
        public String ApplicantAddr2 { get; set; }
        [StringLength(100)]
        public String ApplicantCity { get; set; }
        [StringLength(10)]
        public String ApplicantState { get; set; }
        [StringLength(50)]
        public String ApplicantZip { get; set; }
        [StringLength(50)]
        public String ApplicantPhone { get; set; }
        public String ApplicantEmail { get; set; }
        public String ApplicantFax { get; set; }
        public String SourceFile { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdate { get; set; }
        public String InspectorName { get; set; }
        public String AMSInspectorOffice { get; set; }

        public virtual ICollection<CertRow> CertRows { get; set; }

    }

   
}