namespace HRManagement.Models
{
    public interface IPayrollRepo
    {
        void AddEmployeePayroll(PayrollDetail payroll);
        void UpdateEmployeePayroll(int empid, PayrollDetail payroll);
        PayrollDetail GetPayrollByID(int id);
        PayrollDetail GetPayrollByEmpID(int empid);

        List<PayrollDetail> GetAllPayrolls();
        void DeleteEmployeePayroll(int id);

        void DeletePayrollByEmpID(int empid);

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
            payroll.CalculatePay();
            _context.PayrollDetails.Add(payroll);
            _context.SaveChanges();
        }

        public void DeleteEmployeePayroll(int id)
        {
           PayrollDetail p = _context.PayrollDetails.Find(id);
            _context.PayrollDetails.Remove(p);
            _context.SaveChanges();
        }

        public List<PayrollDetail> GetAllPayrolls()
        {
            return _context.PayrollDetails.ToList();
        }

        public PayrollDetail GetPayrollByEmpID(int empid)
        {
            PayrollDetail e = _context.PayrollDetails.FirstOrDefault(e => e.EmployeeId == empid);
            return e;
        }

        public PayrollDetail GetPayrollByID(int id)
        {
            PayrollDetail e = _context.PayrollDetails.Find(id);
            return e;
        }

        public void UpdateEmployeePayroll(int empid, PayrollDetail payroll)
        {
            var existingPayroll = _context.PayrollDetails.FirstOrDefault(e => e.EmployeeId == empid);
            if (existingPayroll == null)
            {
                throw new InvalidOperationException($"No payroll details found for Employee ID {empid}");
            }

            // Update only the properties that can be updated
            existingPayroll.Basicpay = payroll.Basicpay;
            existingPayroll.Allowance = payroll.Allowance;
            existingPayroll.Deduction = payroll.Deduction;

            // Recalculate Grosspay and Netpay
            existingPayroll.CalculatePay();

            _context.SaveChanges();
        }

        public void DeletePayrollByEmpID(int empid)
        {
            var payroll = _context.PayrollDetails.FirstOrDefault(e => e.EmployeeId == empid);
            _context.PayrollDetails.Remove(payroll);
            _context.SaveChanges();
            

        }
    }
}


