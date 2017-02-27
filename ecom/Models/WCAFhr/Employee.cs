using System.ComponentModel.DataAnnotations;

namespace ecom.Models.WCAFhr
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}