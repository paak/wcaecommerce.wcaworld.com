using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_History
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_History()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        // Length: 200
        public string Action { get; set; }

        // Length: 1000
        public string Action_RM { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }

    }
}
