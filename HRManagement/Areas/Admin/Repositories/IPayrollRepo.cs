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
            if (p != null)
            {
                _context.PayrollDetails.Remove(p);
                _context.SaveChanges();
            }
            else
                throw new InvalidOperationException($"No payroll details found for Payroll ID {id}");

        }

        public List<PayrollDetail> GetAllPayrolls()
        {
            return _context.PayrollDetails.ToList();
        }

        public PayrollDetail GetPayrollByEmpID(int empid)
        {
            PayrollDetail e = _context.PayrollDetails.FirstOrDefault(e => e.EmployeeId == empid);
            if(e != null)
                return e;
            else
                throw new InvalidOperationException($"No payroll details found for Employee ID {empid}");

        }

        public PayrollDetail GetPayrollByID(int id)
        {
            PayrollDetail e = _context.PayrollDetails.Find(id);
            if (e != null)
                return e;
            else
                throw new InvalidOperationException($"No payroll details found for Payroll ID {id}");
        }

        public void UpdateEmployeePayroll(int empid, PayrollDetail payroll)
        {
            var existingPayroll = _context.PayrollDetails.FirstOrDefault(e => e.EmployeeId == empid);
            if (existingPayroll == null)
            {
                throw new InvalidOperationException($"No payroll details found for Employee ID {empid}");
            }
            else
            {
                                
                if (payroll.Basicpay != 0)
                {
                    existingPayroll.Basicpay = payroll.Basicpay;
                }

                if (payroll.Allowance != 0)
                {
                    existingPayroll.Allowance = payroll.Allowance;
                }

                if (payroll.Deduction != 0)
                {
                    existingPayroll.Deduction = payroll.Deduction;
                }


                existingPayroll.CalculatePay();

                _context.SaveChanges();
            }
        }

        public void DeletePayrollByEmpID(int empid)
        {
            var payroll = _context.PayrollDetails.FirstOrDefault(e => e.EmployeeId == empid);
            _context.PayrollDetails.Remove(payroll);
            _context.SaveChanges();
            

        }
    }
}


