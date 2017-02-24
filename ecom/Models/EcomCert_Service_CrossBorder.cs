using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Service_CrossBorder
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service_CrossBorder()
        { }

        [Key]
        public int ID { get; set; }

        public int CertID { get; set; }

        public int CrossBorderId { get; set; }

    }
}
