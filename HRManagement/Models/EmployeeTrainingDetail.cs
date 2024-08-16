using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagement.Models
{
    public class EmployeeTrainingDetail
    {
        [Key]
        public int SNo { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string TrainingId { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        public string TrainingStatus { get; set; }
    }
}
