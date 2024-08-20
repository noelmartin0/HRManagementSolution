namespace HRManagement.Models
{
    public interface IEmployeeRepo
    {
        EmployeeDetail GetEmployeeById(int id);
        List<EmployeeDetail> GetAllEmployees();
        void AddEmployee(EmployeeDetail employee);
        void UpdateEmployee(int id, EmployeeDetail employee);
        void DeleteEmployee(int id);
       
        //havent written training functions
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
            l.DaysRemaining = l.TotalDays - l.DaysTaken;
            _context.SaveChanges();

        }








        public ResumeTrackingDetail GetResumeById(int id)
        {
            ResumeTrackingDetail resume = _context.ResumeTrackingDetails.Find(id);
            return resume;
        }

        public List<ResumeTrackingDetail> GetAllResumes()
        {
            return _context.ResumeTrackingDetails.ToList();
        }

        public void UpdateResume(int id, ResumeTrackingDetail resume)
        {
            ResumeTrackingDetail r = _context.ResumeTrackingDetails.Find(id);
            r.ApplicantName = resume.ApplicantName;
            r.PhoneNo = resume.PhoneNo;
            r.Experience = resume.Experience;
            r.Specialization = resume.Specialization;
            r.AreaOfInterest = resume.AreaOfInterest;
            r.Qualification = resume.Qualification;
            _context.SaveChanges();
        }

        public void AddEmpTraining(EmployeeTrainingDetail t)
        {
            _context.EmployeeTrainingDetails.Add(t);
            _context.SaveChanges();
        }
    }
}
