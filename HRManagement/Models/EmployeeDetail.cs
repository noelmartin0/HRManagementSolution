using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    [Table("EmployeeDetails")]
    public class EmployeeDetail
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]

        public int EmployeeId { get; set; } = 1000;

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
        public int Address { get; set; }


        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("DepartmentDetail")]
        public int DepartmentId { get; set; }

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
        public DepartmentDetail DepartmentDetail { get; set; }

        public ICollection<EmployeeTrainingDetail> EmployeeTrainingDetail { get; set; }
        public ICollection<ResignationDetail> ResignationDetails { get; set; }


    }
}
