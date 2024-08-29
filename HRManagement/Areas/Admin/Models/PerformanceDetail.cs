using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagement.Models
{
    [Table("PerformanceDetails")]
    public class PerformanceDetail
    {
       [Key]
       public int PerformanceId { get; private set; }
 

        public int EmployeeId { get; set; }   

        [Required]
       public int DepartmentId { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string EvaluatorName { get; set; }

        [Required]
        public int EvaluationPeriod { get; set; }

        public int XoxoPoints { get; set; } = 0;

        //public EmployeeDetail EmployeeDetail { get; set; }



    }
}
