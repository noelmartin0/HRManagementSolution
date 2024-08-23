using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    [Table("ResignationDetails")]
    public class ResignationDetail
    {
        [Key]
        public int Sno { get;private set; }

        
        public int EmployeeId { get; set; }


        [StringLength(50)]
        [MinLength(50)]
        [Required]
        public string EmployeeName { get; set; }

        public int DepartmentId { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string Position { get; set; }

        [Required]
        public int? ManagerID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ResignDate { get; set; }

        public string PhoneNumber { get; set; }

        // Navigation Properties

        //public EmployeeDetail EmployeeDetail { get; set; }
    }
}