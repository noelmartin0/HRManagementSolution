using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagement.Models
{
    [Table("LeaveDetails")]
    public class LeaveDetail
    {
        [Key]
        public int SNo { get;private set; }
        [Required]
       

        public int EmployeeId { get; set; }
        public int SickLeaves { get; set; }
        public int VacationDays { get; set; }   
        public int Holidays { get; set; }


        [Required]
        public int TotalDays { get; set; }

        [Range(0, 26, ErrorMessage = "Days taken cannot be negative or greater than 26.")]
        public int? DaysTaken { get; set; }

        [Range(0, 26, ErrorMessage = "Days remaining cannot be negative or greater than 26.")]
        public int? DaysRemaining { get;private set; }

        public void SetDays()
        {
            SickLeaves = 8;
            VacationDays = 6;
            Holidays = 12;
            DaysTaken = 0;
            TotalDays = 26;

        }

        public void CalculateDays()
        {

            DaysRemaining = TotalDays - DaysTaken;
        }
       
       // public EmployeeDetail EmployeeDetail { get; set; }
    }
}
