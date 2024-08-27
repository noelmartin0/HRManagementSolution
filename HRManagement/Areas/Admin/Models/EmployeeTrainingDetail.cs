using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagement.Models
{
    [Table("EmployeeTrainingDetails")]
    public class EmployeeTrainingDetail
    {
        [Key]
        public int SNo { get; set; }

        public int EmployeeId { get; set; }
        //public EmployeeDetail EmployeeDetail { get; set; }

        public int TrainingId { get; set; }
        //public TrainingDetail TrainingDetail { get; set; }


        [StringLength(50)]
        [MinLength(5)]
        public string TrainingStatus { get; set; }

        public static int count = 0;
        public int flag = 0;
        public void SetSNo()
        {
            SNo = ++count;
        }

 

       
    }

}
