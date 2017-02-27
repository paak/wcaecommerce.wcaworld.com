using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models.MSDB
{
    [Table("vw_contactlist")]
    public class ViewContact
    {
        [Key]
        public int CTId { get; set; }

        public int CId { get; set; }

        public int NId { get; set; }

        public string ContactName { get; set; }
        public string Email { get; set; }

        public bool Selected { get; set; }
        public bool Deleted { get; set; }
    }
}