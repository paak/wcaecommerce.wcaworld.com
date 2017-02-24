using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("vw_members_withSuspendNTerminated")]
    public class ViewMember
    {
        [Key]
        public int Cid { get; set; }
        public int MasterCid { get; set; }
        public int Nid { get; set; }
        public int HQID { get; set; }
        public int? WcaHQid { get; set; }
        public int? LognetHQid { get; set; }
        public int? GaaHQid { get; set; }

        public string BusinessType { get; set; }
        public string GroupName { get; set; }
        public string GroupFormerly { get; set; }

        public string Company { get; set; }
        public string FormerlyName { get; set; }
        public string BranchName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        //public string CountryShortName { get; set; }

        public string Country { get; set; }
        public string CityCode { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        /*								
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string Zipcode { get; set; }
        */
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        //public string Email { get; set; }
        public string Emergency { get; set; }
        public byte ShowEmergency { get; set; }
        public string Website { get; set; }
        public string EmailInfo { get; set; }
        public byte ShowEmail { get; set; }
        /*
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone { get; set; }
        public DateTime Created { get; set; }
        */
        public string Username { get; set; }
        public string Password { get; set; }

        public string Logo { get; set; }
        public string PPActive { get; set; }
        public bool? RMActive { get; set; }
        public DateTime? RiskExpiration { get; set; }
        //public bool IsVendor { get; set; }
        //public bool IsMember { get; set; }
        //public string Classify { get; set; }
        public virtual ICollection<Company_Membership> Memberships { get; set; }
    }

    /*
DepartureType	Network_Sname		CompanyKeyword				Mailing			countryAlias		CityAlias		StateAlias		Tags		Created	Terminate	TerminateDate	TerminateReason		Networks	NetworksOnly	NetworksALL
8509	85	Freight Forwarder	CaribEx Worldwide	8509	8509	NULL	8509	85	NULL	1	M	0	103	WCA-eCom	CaribEx Worldwide, Inc.	CaribExWorldwideInc	NULL	Greensboro, NC- Head Office	4248 Piedmont Parkway,
Greensboro, NC 27410 USA

	NULL	Greensboro, NC	United States of America	USA	__USA_
US_
U.S.A._
US._
U.S._
united states__	US	NULL	NULL	NC	North Carolina, NC	__North Carolina_
NC__	NA	NC	North America	27425-5668	+1.336.315.0443	+1.336.315.0531			2	www.caribex.com	NULL	wcafamily@caribex.com	2	Ms. Lauren Smith	WCA Sales	+1.843.573.1110	lsmith@caribex.com	1	2017-08-31 00:00:00	1	NULL	caribx	8410	8509.JPG	2007-07-31 18:08:00	NULL	NULL	NULL	1	1	WCA,CGLN,AWS,Pharma,GAA,WCA-eCom	WCA-First,WCA-CG,WCA-Pharma,WCA-eCom	WCA-First,WCA-CG,WCA-Pharma,GAA,WCA-eCom
     */
}
