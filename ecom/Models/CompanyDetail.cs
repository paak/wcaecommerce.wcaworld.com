using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecom.Models
{
    public class CompanyDetail
    {
        public int Cid { get; set; } = -1;
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressBranch { get; set; }
        public string AddressHQ { get; set; }
        public string CountryHQ { get; set; }
        public string WhereIncorp { get; set; }
        public string YearStarted { get; set; }
        public string NameCEO { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string TurnOverPA { get; set; }
        public int Employees { get; set; }

        public bool? YN_PayUSD { get; set; }
        public string YN_PayUSD_Remark { get; set; }
        public bool? YN_ElecInv { get; set; }
        public string YN_ElecInv_Remark { get; set; }
        public bool? YN_RefService { get; set; }
        public string YN_RefService_Remark { get; set; }
        public bool? EandO { get; set; }
        public string EandO_Remark { get; set; }
        public bool? YN_CyberInsur { get; set; }
        public string YN_CyberInsur_Remark { get; set; }
        public bool? YN_CargoInsur { get; set; }
        public string YN_CargoInsur_Remark { get; set; }

        public List<Membership> Memberships { get; set; }
    }

    public class Membership
    {
        public int Nid { get; set; } = -1;
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateEnrolled { get; set; }
    }
}