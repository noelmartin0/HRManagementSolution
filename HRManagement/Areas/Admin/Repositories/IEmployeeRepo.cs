using Microsoft.EntityFrameworkCore;

using HRManagement.Areas.Admin.Models;
namespace HRManagement.Models
{
    public interface IEmployeeRepo
    {
        EmployeeDetail GetEmployeeById(int id);
        List<EmployeeDetail> GetEmployeeByName(string name);
        List<EmployeeDetail> GetEmployeeByDeptID(int deptID);
        List<EmployeeDetail> GetAllEmployees();
        void AddEmployee(EmployeeDetail employee);
        void UpdateEmployee(int id, EmployeeDetail employee);
        void DeleteEmployee(int id);


        
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
            AddEmployeePayroll(employee.EmployeeId,employee.Position);
            AddEmployeeLeave(employee.EmployeeId);
            AddEmployeePerformance(employee.EmployeeId,employee.DepartmentId);

        }

      

        public void DeleteEmployee(int id)
        {
            EmployeeDetail e = _context.EmployeeDetails.Find(id);
            if (e == null)
            {
                throw new InvalidOperationException($"No Emmployee is found having ID = {id}");
            }
            _context.EmployeeDetails.Remove(e);
            _context.SaveChanges();

        }

        

        public List<EmployeeDetail> GetAllEmployees()
        {
            return _context.EmployeeDetails.ToList();
        }



        public EmployeeDetail GetEmployeeById(int id)
        {

            EmployeeDetail model = _context.EmployeeDetails.Find(id);
            if(model == null)
            {
                throw new InvalidOperationException($"No Emmployee is found having ID ={id}");
            }
            return model;
        }


        public void UpdateEmployee(int id, EmployeeDetail employee)
        {
            //EmployeeDetail e = _context.EmployeeDetails.Find(id);
            //e.EmployeeName = employee.EmployeeName;
            //e.DateOfBirth = employee.DateOfBirth;
            //e.Address = employee.Address;
            //e.Nationality = employee.Nationality;
            //e.PhoneNumber = employee.PhoneNumber;
            //e.Email = employee.Email;
            //e.ManagerId = employee.ManagerId;
            //e.Status = employee.Status;
            //e.Position = employee.Position;
            //e.JoiningDate = employee.JoiningDate;
            //e.DepartmentId = employee.DepartmentId;
            //e.PreviousTrainingCertifications = employee.PreviousTrainingCertifications;
            //if(e.Status == "Resigned")
            //{
            //    CreateResignationDetail(employee);
            //}
            //_context.SaveChanges();
            
            
            
            EmployeeDetail e = _context.EmployeeDetails.Find(id);
         
            if (e != null)
            {
                if (!employee.EmployeeName.Equals("string"))
                {
                    e.EmployeeName = employee.EmployeeName;
                }


                if (!employee.DateOfBirth.Equals("2000-02-02T02:02:02.765Z"))
                {
                    e.DateOfBirth = employee.DateOfBirth;
                }


                if (!employee.Address.Equals("string"))
                {
                    e.Address = employee.Address;
                }

                if (!employee.Nationality.Equals("string"))
                {
                    e.Nationality = employee.Nationality;
                }

                if (!employee.PhoneNumber.Equals("0123456789"))
                {
                    e.PhoneNumber = employee.PhoneNumber;
                }

                if (!employee.Email.Equals("user@example.com"))
                {
                    e.Email = employee.Email;
                }

                if (employee.ManagerId!=0)
                {
                    e.ManagerId = employee.ManagerId;
                }

                if (!employee.Status.Equals("string"))
                {
                    e.Status = employee.Status;
                    if (e.Status.Equals("Resigned") || e.Status.Equals( "Terminated"))
                    {
                        CreateResignationDetail(e);
                    }
                }

                if (!employee.Position.Equals("string"))
                {
                    e.Position = employee.Position;
                    PayrollDetail payrollDetail = _context.PayrollDetails.FirstOrDefault(p => p.EmployeeId == e.EmployeeId);
                    switch (e.Position)
                    {
                        case "Software Engineer":
                            payrollDetail.Basicpay = 20000;
                            break;
                        case "Team Lead":
                            payrollDetail.Basicpay = 40000;
                            break;
                        case "Manager":
                            payrollDetail.Basicpay = 60000;
                            break;
                    }
                    payrollDetail.CalculatePay();
                }


                if (!employee.JoiningDate.Equals("2000-02-02T02:02:02.765Z"))
                {
                    e.JoiningDate = employee.JoiningDate;
                }

                if (employee.DepartmentId != 0)
                {
                    e.DepartmentId = employee.DepartmentId;
                }

                if (!employee.PreviousTrainingCertifications.Equals("string"))
                {
                    e.PreviousTrainingCertifications = employee.PreviousTrainingCertifications;
                }
                
                _context.SaveChanges();
            }
            else throw new InvalidOperationException($"No Emmployee is found having ID = {id}");



        }

        private void CreateResignationDetail(EmployeeDetail employee)
        {
            ResignationDetail resignationDetail = new ResignationDetail
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                DepartmentId = employee.DepartmentId, 
                Position = employee.Position,
                ManagerID = employee.ManagerId,
                JoinDate = employee.JoiningDate,
                ResignDate = DateTime.Now, 
                PhoneNumber = employee.PhoneNumber
            };
            
            _context.ResignationDetails.Add(resignationDetail);
        }

        private void AddEmployeePayroll(int empId, string position)
        {
            PayrollDetail payrollDetail = new PayrollDetail();
            payrollDetail.EmployeeId = empId;
            payrollDetail.SetPay();
            switch(position)
            {
                case "Software Engineer": payrollDetail.Basicpay = 20000;
                    break;
                case "Team Lead": payrollDetail.Basicpay = 40000;
                    break;
                case "Manager": payrollDetail.Basicpay = 60000;
                    break;
            }
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


        private void AddEmployeePerformance(int empId,int deptId)
        {
            var performanceDetail = new PerformanceDetail();
            performanceDetail.EmployeeId = empId;
            performanceDetail.DepartmentId = deptId;
            _context.PerformanceDetails.Add(performanceDetail);
            _context.SaveChanges();


        }


        public List<EmployeeDetail> GetEmployeeByName(string name)
        {
            return _context.EmployeeDetails
                 .Where(e => EF.Functions.Like(e.EmployeeName.ToLower(), $"%{name.ToLower()}%"))
                 .ToList();
        }

        public List<EmployeeDetail> GetEmployeeByDeptID(int deptid)
        {
            return _context.EmployeeDetails.Where(e=>e.DepartmentId == deptid).ToList();
        }


    }
}
