﻿using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Service_Provide
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service_Provide()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int ServiceId { get; set; }

    }
}
