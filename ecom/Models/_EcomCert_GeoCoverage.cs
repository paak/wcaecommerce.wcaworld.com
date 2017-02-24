using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_EcomCert_GeoCoverage")]
    public class EcomCert_GeoCoverage
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_GeoCoverage()
        { }

        public int ID { get; set; }

        // Length: 500
        public string Name { get; set; }

        public bool? IsActive { get; set; }

    }
}
