using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_IT
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_IT()
        { }

        [Key]
        public int CertID { get; set; }

        // Length: 8000
        public string MangeShipmentSys { get; set; }

        // Length: 8000
        public string BookingSys { get; set; }

        // Length: 8000
        public string ProcessShip { get; set; }

        public bool? YN_EDI { get; set; }

        // Length: 2000
        public string YN_EDI_RM { get; set; }

        public bool? YN_EDIImage { get; set; }

        public bool? YN_EDIImage_File { get; set; }

        public bool? YN_PackTrack { get; set; }

        // Length: 2000
        public string YN_PackTrack_RM { get; set; }

        public bool? YN_XML { get; set; }

        // Length: 2000
        public string YN_XML_RM { get; set; }

        public bool? YN_MultiLing { get; set; }

        // Length: 2000
        public string YN_MultiLing_RM { get; set; }

        public bool? YN_ScanBarcode { get; set; }

        // Length: 2000
        public string YN_ScanBarcode_RM { get; set; }

        // Length: 8000
        public string MangementSys { get; set; }

        public bool? YN_API { get; set; }

        // Length: 2000
        public string YN_API_RM { get; set; }

        // Length: -1
        public string Remark { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
