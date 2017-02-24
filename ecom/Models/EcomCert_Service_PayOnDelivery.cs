using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Service_PayOnDelivery
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service_PayOnDelivery()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int PaymentTypeId { get; set; }

    }
}
