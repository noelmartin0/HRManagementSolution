using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    [Table("PayrollDetails")]
    public class PayrollDetail
    {
        [Key]
        public int PayrollID { get;private set; }
        [Required]
     
        public int EmployeeId { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "Basic pay must be a positive value.")]
        public decimal Basicpay { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Allowance must be a positive value.")]
        [DataType(DataType.Currency)]
        public decimal Allowance { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "Deduction must be a positive value.")]
        [DataType(DataType.Currency)]
        public decimal Deduction { get; set; }

        [DataType(DataType.Currency)]
        public decimal Grosspay { get; private set; }

        [DataType(DataType.Currency)]
        public decimal Netpay { get; private set; }

        public void SetPay()
        {
            Basicpay = 15000;
            Allowance = 10000;
            Deduction = 1500;
        }
        public void CalculatePay()
        {
            Grosspay = Basicpay + Allowance;
            Netpay = Grosspay - Deduction;
        }




        public EmployeeDetail EmployeeDetail { get; set; }


    }
}
