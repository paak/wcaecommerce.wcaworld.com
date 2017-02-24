using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_EcomCert_TransportFleet")]
    public class EcomCert_TransportFleet
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_TransportFleet()
        { }

        [Key]
        public int ID { get; set; }

        // Length: 500
        public string Name { get; set; }

        public bool? IsActive { get; set; }

    }
}
