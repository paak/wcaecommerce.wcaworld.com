using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    public class EcomCert_CompDetail
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_CompDetail()
        { }

        [Key]
        public int CertID { get; set; }

        // Length: 1000
        public string CompName { get; set; }

        // Length: 2000
        public string AddressHQ { get; set; }

        // Length: 500
        public string Phone { get; set; }

        // Length: 1000
        public string Email { get; set; }

        // Length: 1000
        public string Website { get; set; }

        // Length: 2000
        public string WhereIncorp { get; set; }

        // Length: 20
        public string YearIncorp { get; set; }

        // Length: 1000
        public string CEOName { get; set; }

        // Length: 1000
        public string ContatPerson { get; set; }

        // Length: 1000
        public string ContactPhone { get; set; }

        // Length: 1000
        public string ContactEmail { get; set; }

        // Length: 510
        public string TurnOverPA { get; set; }

        // Length: 510
        public string TurnOverPercent { get; set; }

        public int? AvgPackageWeightID { get; set; }

        // Length: 2000
        public string ProductHandled_Other { get; set; }

        // Length: 2000
        public string CourierOperate { get; set; }

        // Length: 2000
        public string CrossBorder { get; set; }

        // Length: 2000
        public string ShipmentOperate { get; set; }

        // Length: 2000
        public string SizeWarehouse { get; set; }

        // Length: 1000
        public string NumBranch { get; set; }

        // Length: 1000
        public string NumEmp { get; set; }

        public bool? YN_PayUSD { get; set; }

        // Length: 2000
        public string YN_PayUSD_RM { get; set; }

        public bool? YN_ElecINV { get; set; }

        // Length: 2000
        public string YN_ElecINV_RM { get; set; }

        public bool? YN_RefService { get; set; }

        // Length: 2000
        public string YN_RefService_RM { get; set; }

        public bool? YN_FSL { get; set; }

        // Length: 2000
        public string YN_FSL_RM { get; set; }

        public bool? YN_CyberIns { get; set; }

        // Length: 2000
        public string YN_CyberIns_RM { get; set; }

        public bool? YN_CargoIns { get; set; }

        // Length: 2000
        public string YN_CargoIns_RM { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
