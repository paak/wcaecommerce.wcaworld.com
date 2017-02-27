using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_SalesRep")]
    public class SalesRep
    {
        [Key]
        public int EmpID { get; set; }
        public string CountryCode { get; set; }
    }
}