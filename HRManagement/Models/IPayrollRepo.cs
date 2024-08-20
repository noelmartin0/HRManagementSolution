namespace HRManagement.Models
{
    interface IPayrollRepo
    {
        void AddEmployeePayroll(PayrollDetail payroll);
        void UpdateEmployeePayroll(int id, PayrollDetail payroll);

    }

    public class PayrollRepo : IPayrollRepo
    {
        HRManagementDBContext _context;
        public PayrollRepo(HRManagementDBContext context)
        {
            _context = context;
        }


        public void AddEmployeePayroll(PayrollDetail payroll)
        {
            _context.PayrollDetails.Add(payroll);
            _context.SaveChanges();
        }

        public void UpdateEmployeePayroll(int id, PayrollDetail payroll)
        {
            PayrollDetail e = _context.PayrollDetails.Find(id);
            e.Basicpay = payroll.Basicpay;
            e.Allowance = payroll.Allowance;
            e.Deduction = payroll.Deduction;
            _context.SaveChanges();
        }


    }
}


