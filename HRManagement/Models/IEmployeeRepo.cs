namespace HRManagement.Models
{
    public interface IEmployeeRepo
    {
        EmployeeDetail GetEmployeeById(int id);
        List<EmployeeDetail> GetAllEmployees();
        void AddEmployee(EmployeeDetail employee);
        void UpdateEmployee(int id, EmployeeDetail employee);
        void DeleteEmployee(int id);
        void AddEmployeePayroll(PayrollDetail payroll);
        void UpdateEmployeePayroll(int id, PayrollDetail payroll);
        //havent written training functions
        void AddEmployeePerformance(PerformanceDetail performance);
        void UpdateEmployeePerformance(int id, PerformanceDetail performance);
        void UpdateEmployeeLeaveDetail(int id, LeaveDetail leave);
        void AddEmployeeResignation(ResignationDetail resignation);
        ResumeTrackingDetail GetResumeById(int id);
        List<ResumeTrackingDetail> GetAllResumes();
        void AddResume(ResumeTrackingDetail resume);
        //void UpdateResumeTrackingDetail(ResumeTrackingDetail resume);
        void DeleteResume(int id);
        void UpdateResume(int id, ResumeTrackingDetail resume);
        void AddEmpTraining(EmployeeTrainingDetail t);



    }



    public class EmployeeRepo : IEmployeeRepo
    {
        HRManagementDBContext _context;
        public EmployeeRepo(HRManagementDBContext context)
        {
            _context = context;
        }

        public void AddEmployee(EmployeeDetail employee)
        {
            _context.EmployeeDetails.Add(employee);
            _context.SaveChanges();
        }

        public void AddEmployeePayroll(PayrollDetail payroll)
        {
            _context.PayrollDetails.Add(payroll);
            _context.SaveChanges();
        }

        public void AddEmployeePerformance(PerformanceDetail performance)
        {
            _context.PerformanceDetails.Add(performance);
            _context.SaveChanges();

        }

        public void AddEmployeeResignation(ResignationDetail resignation)
        {
            _context.ResignationDetails.Add(resignation);
            _context.SaveChanges();

        }

        public void AddResume(ResumeTrackingDetail resume)
        {

            _context.ResumeTrackingDetails.Add(resume);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            EmployeeDetail e = _context.EmployeeDetails.Find(id);
            _context.EmployeeDetails.Remove(e);
            _context.SaveChanges();

        }

        public void DeleteResume(int id)
        {
            ResumeTrackingDetail m = _context.ResumeTrackingDetails.Find(id);
            _context.ResumeTrackingDetails.Remove(m);

        }

        public List<EmployeeDetail> GetAllEmployees()
        {
            return _context.EmployeeDetails.ToList();
        }



        public EmployeeDetail GetEmployeeById(int id)
        {
            EmployeeDetail model = _context.EmployeeDetails.Find(id);
            return model;
        }


        public void UpdateEmployee(int id, EmployeeDetail employee)
        {
            EmployeeDetail e = _context.EmployeeDetails.Find(id);
            e.EmployeeName = employee.EmployeeName;
            e.DateOfBirth = employee.DateOfBirth;
            e.Address = employee.Address;
            e.Nationality = employee.Nationality;
            e.PhoneNumber = employee.PhoneNumber;
            e.Email = employee.Email;
            e.ManagerId = employee.ManagerId;
            e.Status = employee.Status;
            e.Position = employee.Position;
            _context.SaveChanges();
        }

        public void UpdateEmployeeLeaveDetail(int id, LeaveDetail leave)
        {
            LeaveDetail l = _context.LeaveDetails.Find(id);
            l.TotalDays = leave.TotalDays;
            l.DaysTaken = leave.DaysTaken;
            l.LeavesLeft = l.TotalLeaves - l.LeavesTaken;
            _context.SaveChanges();

        }

        public void UpdateEmployeePayroll(int id, PayrollDetail payroll)
        {
            PayrollDetail e = _context.Payrolls.Find(id);
            e.BasicPay = payroll.BasicPay;
            e.Allowances = payroll.Allowances;
            e.Deductions = payroll.Deductions;
            _context.SaveChanges();
        }

        public void UpdateEmployeePerformance(int id, PerformanceDetail performance)
        {
            PerformanceDetail e = _context.Performances.Find(id);
            e.EvaluatorName = performance.EvaluatorName;
            e.EvaluationPeriod = performance.EvaluationPeriod;
            _context.SaveChanges();
        }






        public ResumeTrackingDetail GetResumeById(int id)
        {
            ResumeTrackingDetail resume = _context.Resumes.Find(id);
            return resume;
        }

        public List<ResumeTrackingDetail> GetAllResumes()
        {
            return _context.Resumes.ToList();
        }

        public void UpdateResume(int id, ResumeTrackingDetail resume)
        {
            ResumeTrackingDetail r = _context.Resumes.Find(id);
            r.ApplicationName = resume.ApplicationName;
            r.PhoneNo = resume.PhoneNo;
            r.PrevExperience = resume.PrevExperience;
            r.Specialization = resume.Specializtion;
            r.AreaOfInterest = resume.AreaOfInterest;
            r.Qualification = resume.Qualification;
            _context.SaveChanges();
        }

        public void AddEmpTraining(EmpTraining t)
        {
            _context.Emptraining.Add(t);
            _context.SaveChanges();
        }
    }



}


