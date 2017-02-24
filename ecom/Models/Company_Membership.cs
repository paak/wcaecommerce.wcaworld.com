using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    public class Company_Membership
    {
        public int CMid { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Nid { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Cid { get; set; }
        public string MemberID { get; set; }
        public DateTime? AnnounceDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        [ForeignKey("Nid")]
        public virtual Network Network { get; set; }
    }
}
