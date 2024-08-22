﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    [Table("PayrollDetails")]
    public class PayrollDetail
    {
        [Key]
        public int PayrollID { get; set; }
        [Required]
     
        public int EmployeeId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Basicpay { get; set; }

        [DataType(DataType.Currency)]
        public decimal Allowance { get; set; }

        [DataType(DataType.Currency)]
        public decimal Deduction { get; set; }

        [DataType(DataType.Currency)]
        public decimal Grosspay { get; private set; }

        [DataType(DataType.Currency)]
        public decimal Netpay { get; private set; }
        public void CalculatePay()
        {
            Grosspay = Basicpay + Allowance;
            Netpay = Grosspay - Deduction;
        }



        //  public EmployeeDetail EmployeeDetail { get; set; }


    }
}
