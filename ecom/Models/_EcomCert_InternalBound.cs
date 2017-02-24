using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_EcomCert_InternalBound")]
    public class EcomCert_InternalBound
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_InternalBound()
        { }

        public int ID { get; set; }

        // Length: 500
        public string Name { get; set; }

        public bool? IsActive { get; set; }

    }
}
