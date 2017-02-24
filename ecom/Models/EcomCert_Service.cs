using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_Service
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_Service()
        { }

        [Key]
        public int CertID { get; set; }

        public int GeoCoverageID { get; set; }

        // Length: 2000
        public string Top5Dest { get; set; }

        // Length: 2000
        public string Top5Ctry { get; set; }

        // Length: 2000
        public string CrossBorder_Other { get; set; }

        // Length: 2000
        public string GroundService_Other { get; set; }

        public bool? YN_SupShipper { get; set; }

        // Length: 2000
        public string YN_SupShipper_RM { get; set; }

        // Length: 2000
        public string YN_PayOnDelivery_RM { get; set; }

        public bool? YN_PreClearance { get; set; }

        // Length: 2000
        public string YN_PreClearance_RM { get; set; }

        public bool? YN_InternalBound { get; set; }

        // Length: 2000
        public string YN_InternalBound_RM { get; set; }

        // Length: 8000
        public string PackageProcess { get; set; }

        // Length: 8000
        public string ManageReverse { get; set; }

        public bool? YN_CTPA { get; set; }

        // Length: 2000
        public string YN_CTPA_RM { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
