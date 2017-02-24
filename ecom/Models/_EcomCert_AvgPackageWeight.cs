using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_EcomCert_AvgPackageWeight")]
    public class EcomCert_AvgPackageWeight
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_AvgPackageWeight()
        { }

        [Key]
        public int ID { get; set; }

        // Length: 500
        public string Name { get; set; }

        public bool? IsActive { get; set; }

    }
}
