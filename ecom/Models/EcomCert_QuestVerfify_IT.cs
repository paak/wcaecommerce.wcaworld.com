using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_QuestVerfify_IT
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_QuestVerfify_IT()
        { }

        [Key]
        public int CertID { get; set; }

        public bool? QV_MangeShipmentSys { get; set; }

        // Length: 1000
        public string QV_MangeShipmentSys_RM { get; set; }

        public bool? QV_BookingSys { get; set; }

        // Length: 1000
        public string QV_BookingSys_RM { get; set; }

        public bool? QV_ProcessShip { get; set; }

        // Length: 1000
        public string QV_ProcessShip_RM { get; set; }

        public bool? QV_YN_EDI { get; set; }

        // Length: 1000
        public string QV_YN_EDI_RM { get; set; }

        public bool? QV_YN_EDIImage { get; set; }

        // Length: 1000
        public string QV_YN_EDIImage_RM { get; set; }

        public bool? QV_YN_PackTrack { get; set; }

        // Length: 1000
        public string QV_YN_PackTrack_RM { get; set; }

        public bool? QV_YN_XML { get; set; }

        // Length: 1000
        public string QV_YN_XML_RM { get; set; }

        public bool? QV_YN_MultiLing { get; set; }

        // Length: 1000
        public string QV_YN_MultiLing_RM { get; set; }

        public bool? QV_YN_ScanBarcode { get; set; }

        // Length: 1000
        public string QV_YN_ScanBarcode_RM { get; set; }

        public bool? QV_MangementSys { get; set; }

        // Length: 1000
        public string QV_MangementSys_RM { get; set; }

        public bool? QV_YN_API { get; set; }

        // Length: 1000
        public string QV_YN_API_RM { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
