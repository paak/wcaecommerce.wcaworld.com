using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Service_Ground
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service_Ground()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int GroundServiceId { get; set; }

    }
}
