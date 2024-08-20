using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    [Table("EmployeeDetails")]
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        [Required]
        public string EmployeeName { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        public string Nationality { get; set; }


        [StringLength(100)]
        [MinLength(5)]
        public string Address { get; set; }


        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public int? ManagerId { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        public string Status { get; set; }


        [StringLength(50)]
        [MinLength(5)]
        public string Position { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime JoiningDate { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public DepartmentDetail DepartmentDetail { get; set; }


        //public ICollection<EmployeeTrainingDetail> EmployeeTrainingDetail { get; set; }

    }
}
