using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models
{
    public class DepartmentDetail
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set;}

        public ICollection<EmployeeDetail> EmployeeDetail { get; set; }
        public ICollection<ResignationDetail> ResignationDetail { get; set; }

        public ICollection<PerformanceDetail> PerformanceDetail { get; set; }
    }
}

