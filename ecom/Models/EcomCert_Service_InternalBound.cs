using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Service_InternalBound
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service_InternalBound()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int InternalBoundId { get; set; }

    }
}
