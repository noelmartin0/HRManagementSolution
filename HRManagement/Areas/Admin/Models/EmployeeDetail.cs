using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    [Table("EmployeeDetails")]
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeId { get; private set; }

        [StringLength(50)]
        [MinLength(3)]
        [Required]
        public string EmployeeName { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string Nationality { get; set; }


        [StringLength(100)]
        [MinLength(3)]
        public string Address { get; set; }


        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public int? ManagerId { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string Status { get; set; }


        [StringLength(50)]
        [MinLength(3)]
        public string Position { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime JoiningDate { get; set; }


        public int DepartmentId { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string? PreviousTrainingCertifications { get; set; }


        //public DepartmentDetail DepartmentDetail { get; set; }
        //public LeaveDetail LeaveDetail { get; set; }
        //public PayrollDetail PayrollDetail { get; set; }
        //public PerformanceDetail PerformanceDetail { get; set; }
        //public ResignationDetail ResignationDetail { get; set; }


        //public ICollection<EmployeeTrainingDetail> EmployeeTrainingDetail { get; set; }

    }
 
}
