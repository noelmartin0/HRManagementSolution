using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    [Table("ResignationDetails")]
    public class ResignationDetail
    {
        [Key]
        public int Sno { get; set; }

        // Foreign Key Property
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string Position { get; set; }

        [Required]
        public int ManagerID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ResignDate { get; set; }

        public string PhoneNumber { get; set; }

        // Navigation Properties

        //public EmployeeDetail EmployeeDetail { get; set; }
    }
}