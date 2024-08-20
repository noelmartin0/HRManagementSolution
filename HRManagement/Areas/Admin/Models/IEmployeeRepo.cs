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
            _context.SaveChanges();
        }

       








      
    }
}
