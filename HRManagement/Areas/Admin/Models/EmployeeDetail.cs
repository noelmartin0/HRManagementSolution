using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HRManagement.Attributes.CheckStatus;
using static HRManagement.Attributes.MinimumAge;

namespace HRManagement.Models
{
    [Table("EmployeeDetails")]
    [Index(nameof(PhoneNumber), nameof(Email), IsUnique = true)]
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeId { get; private set; }

        [StringLength(50)]
        [MinLength(3)]
        [Required]
        public string EmployeeName { get; set; }


        [DataType(DataType.DateTime)]
        [MinimumAge(18, ErrorMessage = "Minimum age required is 18 years.")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string Nationality { get; set; }


        [StringLength(100)]
        [MinLength(3)]
        public string Address { get; set; }


        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]//with @, you dont need an extra backslash
                                                                                                  //before the escape sequence
        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public int? ManagerId { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        [CheckStatus(new string[] { "Permanent", "Trainee", "Terminated","Resigned" })]
        public string Status { get; set; }


        [StringLength(50)]
        [MinLength(3)]
        [CheckStatus(new string[] { "Associate Software Engineer", "Software Engineer", "Manager", "Team Lead" })]
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
