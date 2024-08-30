using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HRManagement.Attributes.CheckStatus;

namespace HRManagement.Models
{
    [Table("EmployeeTrainingDetails")]
    public class EmployeeTrainingDetail
    {
        [Key]
        public int SNo { get; private set; }

        public int EmployeeId { get; set; }

        public int TrainingId { get; set; }


        //public TrainingDetail TrainingDetail { get; set; }
        //public EmployeeDetail EmployeeDetail { get; set; }


        [StringLength(50)]
        [MinLength(5)]
        [CheckStatus(new string[] { "Completed", "Ongoing","Dropped" })]
        public string TrainingStatus { get; set; }

        
        public int flag = 0;
        

 

       
    }

}
