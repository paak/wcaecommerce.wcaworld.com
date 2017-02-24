using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert()
        { }

        [Key]
        public int CertID { get; set; }

        public int Cid { get; set; }

        public bool? CheckCustRef { get; set; }

        // Length: 2000
        public string CheckCustRef_RM { get; set; }

        public DateTime? SiteVisitDate { get; set; }

        // Length: 1000
        public string PersonVisitName { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}