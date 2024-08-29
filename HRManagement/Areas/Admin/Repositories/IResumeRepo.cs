using HRManagement.Models;

namespace HRManagement.Areas.Admin.Models
{
    public interface IResumeRepo
    {
        
            ResumeTrackingDetail GetResumeById(int id);
            List<ResumeTrackingDetail> GetAllResumes();
            void AddResume(ResumeTrackingDetail resume);

            void DeleteResume(int id);
            void UpdateResume(int id, ResumeTrackingDetail resume);

            void HireEmployee(int id, EmployeeDetail employeefromPostMethod);

            //Write the promote() function
     }

        public class ResumeTrackingRepo : IResumeRepo
        {

            HRManagementDBContext _context;
            public ResumeTrackingRepo(HRManagementDBContext context)
            {
                _context = context;
            }

            public void AddResume(ResumeTrackingDetail resume)
            {

                _context.ResumeTrackingDetails.Add(resume);
                _context.SaveChanges();
            }

            public void DeleteResume(int id)
         {
            ResumeTrackingDetail m = _context.ResumeTrackingDetails.Find(id);
            if (m == null)
            {
                throw new InvalidOperationException($"No Resume is found having ID = {id}");
            }
            _context.ResumeTrackingDetails.Remove(m);
            _context.SaveChanges();

            }

            public List<ResumeTrackingDetail> GetAllResumes()
            {
                return _context.ResumeTrackingDetails.ToList();
            }

            public ResumeTrackingDetail GetResumeById(int id)
            {
            ResumeTrackingDetail m = _context.ResumeTrackingDetails.Find(id);
            if (m == null)
            {
                throw new InvalidOperationException($"No Resume is found having ID = {id}");
            }
                return m;
            }

        public void HireEmployee(int id,EmployeeDetail employeefromPostMethod)
        {
            ResumeTrackingDetail resume = _context.ResumeTrackingDetails.Find(id);

            if (resume == null)
            {
                throw new InvalidOperationException($"No Resume is found having ID = {id}");
            }
            
            EmployeeDetail emp = new EmployeeDetail();
            emp.EmployeeName = resume.ApplicantName;
            emp.DateOfBirth = resume.DateOfBirth;
            emp.Address = resume.Address;
            emp.Nationality = resume.Nationality;
            emp.PhoneNumber = resume.PhoneNo;
            emp.Email = resume.Email;
            emp.DepartmentId = employeefromPostMethod.DepartmentId;
            emp.ManagerId = employeefromPostMethod.ManagerId;
            emp.Status = employeefromPostMethod.Status;
            emp.JoiningDate = employeefromPostMethod.JoiningDate;
            emp.Position = resume.ApplyingFor;
            emp.PreviousTrainingCertifications = resume.Certifications;
            _context.EmployeeDetails.Add(emp);
            _context.SaveChanges();
            AddEmployeeLeave(emp.EmployeeId);
            AddEmployeePayroll(emp.EmployeeId);
            _context.ResumeTrackingDetails.Remove(resume);
            _context.SaveChanges();
        }

        public void UpdateResume(int id, ResumeTrackingDetail resume)
            {
            ResumeTrackingDetail r = _context.ResumeTrackingDetails.Find(id);
            if (r == null)
            {
                throw new InvalidOperationException($"No Resume is found having ID = {id}");
            }

            r.ApplicantName = resume.ApplicantName;
                r.PhoneNo = resume.PhoneNo;
                r.Email = resume.Email;
                r.Address = resume.Address;
                r.DateOfBirth = resume.DateOfBirth;
                r.Nationality = resume.Nationality;
                r.ApplyingFor = resume.ApplyingFor;
                r.Experience = resume.Experience;
                r.Specialization = resume.Specialization;
                r.AreaOfInterest = resume.AreaOfInterest;
                r.Qualification = resume.Qualification;
            r.Certifications = resume.Certifications;
                _context.SaveChanges();
            }

        private void AddEmployeePayroll(int empId)
        {
            PayrollDetail payrollDetail = new PayrollDetail();
            payrollDetail.EmployeeId = empId;
            payrollDetail.SetPay();
            payrollDetail.CalculatePay();
            _context.PayrollDetails.Add(payrollDetail);
            _context.SaveChanges();
        }


        private void AddEmployeeLeave(int empId)
        {
            LeaveDetail leaveDetail = new LeaveDetail();
            leaveDetail.EmployeeId = empId;
            leaveDetail.SetDays();
            leaveDetail.CalculateDays();
            _context.LeaveDetails.Add(leaveDetail);

            _context.SaveChanges();

        }



    }

   }

