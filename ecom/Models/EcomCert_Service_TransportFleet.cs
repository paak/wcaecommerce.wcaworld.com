using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Service_TransportFleet
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service_TransportFleet()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int TransportFleetId { get; set; }

    }
}
