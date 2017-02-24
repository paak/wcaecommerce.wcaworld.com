using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_EcomCert_Service")]
    public class EcomCert_Service_Master
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service_Master()
        { }

        [Key]
        public int ID { get; set; }

        // Length: 500
        public string Name { get; set; }

        public bool? IsActive { get; set; }

    }
}
