using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Product_Handled
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Product_Handled()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int ProductId { get; set; }

    }
}
