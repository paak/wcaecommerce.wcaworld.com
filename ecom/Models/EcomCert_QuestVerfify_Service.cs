using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class EcomCert_QuestVerfify_Service
    {
        /// <summary>
        /// User defined Contructor
        /// </sumary>
        public EcomCert_QuestVerfify_Service()
        { }

        [Key]
        public int CertID { get; set; }

        public bool? QV_Top5Dest { get; set; }

        // Length: 1000
        public string QV_Top5Dest_RM { get; set; }

        public bool? QV_Top5Ctry { get; set; }

        // Length: 1000
        public string QV_Top5Ctry_RM { get; set; }

        public bool? QV_CrossBorder_Other { get; set; }

        // Length: 1000
        public string QV_CrossBorder_Other_RM { get; set; }

        public bool? QV_GroundService_Other { get; set; }

        // Length: 1000
        public string QV_GroundService_Other_RM { get; set; }

        public bool? QV_YN_SupShipper { get; set; }

        // Length: 1000
        public string QV_YN_SupShipper_RM { get; set; }

        public bool? QV_YN_PayOnDelivery { get; set; }

        // Length: 1000
        public string QV_YN_PayOnDelivery_RM { get; set; }

        public bool? QV_YN_PreClearance { get; set; }

        // Length: 1000
        public string QV_YN_PreClearance_RM { get; set; }

        public bool? QV_YN_InternalBound { get; set; }

        // Length: 1000
        public string QV_YN_InternalBound_RM { get; set; }

        public bool? QV_PackageProcess { get; set; }

        // Length: 1000
        public string QV_PackageProcess_RM { get; set; }

        public bool? QV_ManageReverse { get; set; }

        // Length: 1000
        public string QV_ManageReverse_RM { get; set; }

        public bool? QV_YN_CTPA { get; set; }

        // Length: 1000
        public string QV_YN_CTPA_RM { get; set; }

        public bool? QV_Service_Provide { get; set; }

        // Length: 1000
        public string QV_Service_Provide_RM { get; set; }

        public bool? QV_Service_CrossBorder { get; set; }

        // Length: 1000
        public string QV_Service_CrossBorder_RM { get; set; }

        public bool? QV_Service_Ground { get; set; }

        // Length: 1000
        public string QV_Service_Ground_RM { get; set; }

        public bool? QV_Service_TransportFleet { get; set; }

        // Length: 1000
        public string QV_Service_TransportFleet_RM { get; set; }

        public bool? QV_Service_PayOnDelivery { get; set; }

        // Length: 1000
        public string QV_Service_PayOnDelivery_RM { get; set; }

        public bool? QV_Service_InternalBound { get; set; }

        // Length: 1000
        public string QV_Service_InternalBound_RM { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
