using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    public class PayrollDetail
    {
        [Key]
        public int PayrollID { get; set; }
        [Required]
        public int EmployeeID { get; set; }

        [DataType(DataType.Currency)]
        public decimal Basicpay { get; set; }

        [DataType(DataType.Currency)]
        public decimal Allowance { get; set; }

        [DataType(DataType.Currency)]
        public decimal Deduction { get; set; }

        [DataType(DataType.Currency)]
        public decimal Grosspay { get; set; }

        [DataType(DataType.Currency)]
        public decimal Netpay { get; set; }

        [ForeignKey("EmployeeID")]
        public EmployeeDetail EmployeeDetail { get; set; }


    }
}
