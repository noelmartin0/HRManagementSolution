using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagement.Models
{
    [Table("EmployeeTrainingDetails")]
    public class EmployeeTrainingDetail
    {
        [Key]
        public int SNo { get; private set; }

        public int EmployeeId { get; set; }
      //  public EmployeeDetail EmployeeDetail { get; set; }

        public int TrainingId { get; set; }
       // public TrainingDetail TrainingDetail { get; set; }


        [StringLength(50)]
        [MinLength(5)]
        public string TrainingStatus { get; set; }

        
        public int flag = 0;
        

 

       
    }

}
