using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    public class ResignationDetail
    {
        [Key]
        public int Sno { get; set; }

        // Foreign Key Property
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        public string Position { get; set; }

        [Required]
        public int ManagerID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ResignDate { get; set; }

        // Navigation Properties
        [ForeignKey("EmployeeId")]
        public EmployeeDetail EmployeeDetail { get; set; }
    }
}