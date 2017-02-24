using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Status
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Status()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int StatusID { get; set; }

        // Length: 2000
        public string Status_RM { get; set; }

        // Length: 10
        public string CertLevel { get; set; }

        // Length: 2000
        public string CertLevel_RM { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }

    }
}
