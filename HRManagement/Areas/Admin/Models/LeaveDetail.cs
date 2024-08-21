using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagement.Models
{
    [Table("LeaveDetails")]
    public class LeaveDetail
    {
        [Key]
        public int SNo { get; set; }
        [Required]
       

        public int EmployeeId { get; set; }
        [Required]
        public int TotalDays { get; set; }

        
        public int? DaysTaken { get; set; }

        
        public int? DaysRemaining { get; set; }


       
        public EmployeeDetail EmployeeDetail { get; set; }
    }
}
