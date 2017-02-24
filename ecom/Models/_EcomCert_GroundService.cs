using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_EcomCert_GroundService")]
    public class EcomCert_GroundService
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_GroundService()
        { }

        [Key]
        public int ID { get; set; }

        // Length: 500
        public string Name { get; set; }

        public bool? IsActive { get; set; }

    }
}
