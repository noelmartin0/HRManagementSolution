using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagement.Models
{
    public class PerformanceDetail
    {
       [Key]
       public int PerformanceId { get; set; } 
       
       public int EmployeeId { get; set; }   

        [Required]
       public int DepartmentId { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        public string EvaluatorName { get; set; }

        [Required]
        public int EvaluationPeriod { get; set; }

        [ForeignKey("EmployeeId")]
        public EmployeeDetail EmployeeDetail { get; set; }

        

    }
}
