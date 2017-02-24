using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    [Table("_Network")]
    public class Network
    {
        [Key]
        public int Nid { get; set; }
        public byte Network_Type { get; set; }
        public string Network_SName { get; set; }
        public string Network_LName { get; set; }
        public bool Enable { get; set; }
    }
}
