using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Service_GeoCoverage
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service_GeoCoverage()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int GeoCoverageId { get; set; }

    }
}
