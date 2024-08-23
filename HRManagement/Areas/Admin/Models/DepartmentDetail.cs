﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    [Table("DepartmentDetails")]
    public class DepartmentDetail
    {
        [Key]
        public int DepartmentId { get;private set; }
        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
        public ICollection<EmployeeDetail> EmployeeDetail { get; set; }
    }
}

