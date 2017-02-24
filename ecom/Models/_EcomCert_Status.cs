using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_EcomCert_Status")]
    public class EcomCert_Status_Data
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Status_Data()
        { }

        [Key]
        public int ID { get; set; }

        // Length: 500
        public string Name { get; set; }

        public bool? IsActive { get; set; }

    }
}
