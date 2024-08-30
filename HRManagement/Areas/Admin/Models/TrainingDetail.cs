using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagement.Models
{

    [Table("TrainingDetails")]
    [Index(nameof(TrainingName), IsUnique = true)]
    public class TrainingDetail
    {
        [Key]
        public int TrainingId { get;private set; }

        [Required]
        public string TrainingName { get; set; }
        
        //public ICollection<EmployeeTrainingDetail> EmployeeTrainingDetail { get; set; }
        

    }
}
