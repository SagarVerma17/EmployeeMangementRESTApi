using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeRESTApi.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string EmpName { get; set; }

        [DisplayName("Age")]
        public int EmpAge { get; set; }

        public DateTime JoiningDate { get; set; }

        [DisplayName("Address")]
        public String EmpAddress { get; set; }

        [DisplayName("Contact No.")]
        public long EmpMobileNo { get; set; }

        [DisplayName("Department")]
        public string EmpDeptNo { get; set; }
    }
}
