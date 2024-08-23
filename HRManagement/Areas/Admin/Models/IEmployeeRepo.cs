﻿namespace HRManagement.Models
{
    public interface IEmployeeRepo
    {
        EmployeeDetail GetEmployeeById(int id);
        List<EmployeeDetail> GetAllEmployees();
        void AddEmployee(EmployeeDetail employee);
        void UpdateEmployee(int id, EmployeeDetail employee);
        void DeleteEmployee(int id);
        public void UpdateEmployeeStatus(int employeeId, string newStatus);

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





     


        public void DeleteEmployee(int id)
        {
            EmployeeDetail e = _context.EmployeeDetails.Find(id);
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
            if(e.Status == "Resigned")
            {
                CreateResignationDetail(employee);
            }
            _context.SaveChanges();
        }

        public void UpdateEmployeeStatus(int employeeId, string newStatus)
        {
            EmployeeDetail employee = _context.EmployeeDetails.Find(employeeId);
            if (employee == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }
            if (employee.Status != newStatus)
            {
                employee.Status = newStatus;
                // Check if status is being set to "Resigned"
                if (newStatus == "Resigned")
                {
                    CreateResignationDetail(employee);
                }
                _context.SaveChanges();
            }
        }

        private void CreateResignationDetail(EmployeeDetail employee)
        {
            ResignationDetail resignationDetail = new ResignationDetail
            {
                EmployeeId = employee.EmployeeId,
                DepartmentId = employee.DepartmentId, // Assuming this is stored in EmployeeDetail
                Position = employee.Position,
                ManagerID = employee.ManagerId,
                JoinDate = employee.JoiningDate,
                ResignDate = DateTime.Now, // Current date as the resignation date
                PhoneNumber = employee.PhoneNumber
            };

            _context.ResignationDetails.Add(resignationDetail);
            _context.SaveChanges();
        }










    }
}
