using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CertApp.Models
{
    public class CertRow
    {
        public int ID { get; set; }
        [Required]
        public int CertID { get; set; }
        [Required]
        [StringLength(50)]
        public String CustomsEntryNum { get; set; }
        public String HTSCodeDescript { get; set; }
        [StringLength(50)]
        public String TotalWeight { get; set; }
        [StringLength(50)]
        public String Results { get; set; }
        [StringLength(50)]
        public String FDAStatus { get; set; }
        [StringLength(50)]
        public String UnitOfMeasure { get; set; }
        [StringLength(50)]
        public String NumOfPackages { get; set; }
        public String InspectionLotIdNos { get; set; }
        public String CBPContainerLotID { get; set; }


        public virtual Cert Cert { get; set; }
    }
}