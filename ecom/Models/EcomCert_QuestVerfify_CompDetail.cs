using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_QuestVerfify_CompDetail
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_QuestVerfify_CompDetail()
        { }

        [Key]
        public int CertID { get; set; }

        public bool? QV_CompName { get; set; }

        // Length: 1000
        public string QV_CompName_RM { get; set; }

        public bool? QV_AddressHQ { get; set; }

        // Length: 1000
        public string QV_AddressHQ_RM { get; set; }

        public bool? QV_Phone { get; set; }

        // Length: 1000
        public string QV_Phone_RM { get; set; }

        public bool? QV_Email { get; set; }

        // Length: 1000
        public string QV_Email_RM { get; set; }

        public bool? QV_Website { get; set; }

        // Length: 1000
        public string QV_Website_RM { get; set; }

        public bool? QV_WhereIncorp { get; set; }

        // Length: 1000
        public string QV_WhereIncorp_RM { get; set; }

        public bool? QV_YearIncorp { get; set; }

        // Length: 1000
        public string QV_YearIncorp_RM { get; set; }

        public bool? QV_CEOName { get; set; }

        // Length: 1000
        public string QV_CEOName_RM { get; set; }

        public bool? QV_ContatPerson { get; set; }

        // Length: 1000
        public string QV_ContatPerson_RM { get; set; }

        public bool? QV_ContactPhone { get; set; }

        // Length: 1000
        public string QV_ContactPhone_RM { get; set; }

        public bool? QV_ContactEmail { get; set; }

        // Length: 1000
        public string QV_ContactEmail_RM { get; set; }

        public bool? QV_TurnOverPA { get; set; }

        // Length: 1000
        public string QV_TurnOverPA_RM { get; set; }

        public bool? QV_TurnOverPercent { get; set; }

        // Length: 1000
        public string QV_TurnOverPercent_RM { get; set; }

        public bool? QV_AvgPackageWeightID { get; set; }

        // Length: 1000
        public string QV_AvgPackageWeightID_RM { get; set; }

        public bool? QV_ProductHandled_Other { get; set; }

        // Length: 1000
        public string QV_ProductHandled_Other_RM { get; set; }

        public bool? QV_CourierOperate { get; set; }

        // Length: 1000
        public string QV_CourierOperate_RM { get; set; }

        public bool? QV_CrossBorder { get; set; }

        // Length: 1000
        public string QV_CrossBorder_RM { get; set; }

        public bool? QV_ShipmentOperate { get; set; }

        // Length: 1000
        public string QV_ShipmentOperate_RM { get; set; }

        public bool? QV_SizeWarehouse { get; set; }

        // Length: 1000
        public string QV_SizeWarehouse_RM { get; set; }

        public bool? QV_NumBranch { get; set; }

        // Length: 1000
        public string QV_NumBranch_RM { get; set; }

        public bool? QV_NumEmp { get; set; }

        // Length: 1000
        public string QV_NumEmp_RM { get; set; }

        public bool? QV_YN_PayUSD { get; set; }

        // Length: 1000
        public string QV_YN_PayUSD_RM { get; set; }

        public bool? QV_YN_ElecINV { get; set; }

        // Length: 1000
        public string QV_YN_ElecINV_RM { get; set; }

        public bool? QV_YN_RefService { get; set; }

        // Length: 1000
        public string QV_YN_RefService_RM { get; set; }

        public bool? QV_YN_FSL { get; set; }

        // Length: 1000
        public string QV_YN_FSL_RM { get; set; }

        public bool? QV_YN_CyberIns { get; set; }

        // Length: 1000
        public string QV_YN_CyberIns_RM { get; set; }

        public bool? QV_YN_CargoIns { get; set; }

        // Length: 1000
        public string QV_YN_CargoIns_RM { get; set; }

        public bool? QV_Product_Handled { get; set; }

        // Length: 1000
        public string QV_Product_Handled_RM { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
