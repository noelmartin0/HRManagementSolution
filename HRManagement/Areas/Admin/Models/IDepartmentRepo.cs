using HRManagement.Models;

namespace HRManagement.Areas.Admin.Models
{
    public interface IDepartmentRepo
    {
        public List<DepartmentDetail> GetAllDepartments();
        public DepartmentDetail GetDepartmentById(int id);
        void AddDepartment(DepartmentDetail department);
        void UpdateDepartment(int id, DepartmentDetail department);
        void DeleteDepartment(int id);


    }

    public class DepartmentRepo : IDepartmentRepo
    {
        HRManagementDBContext _context;
        public DepartmentRepo(HRManagementDBContext context)
        {
            _context = context;
        }




        public void AddDepartment(DepartmentDetail department)
        {
            _context.DepartmentDetails.Add(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            DepartmentDetail dep = _context.DepartmentDetails.Find(id);
            if (dep == null)
            {
                throw new InvalidOperationException($"No department is found having ID = {id}");
            }
            _context.DepartmentDetails.Remove(dep);
            _context.SaveChanges();
        }

        public List<DepartmentDetail> GetAllDepartments()
        {
            return _context.DepartmentDetails.ToList();
        }

        public DepartmentDetail GetDepartmentById(int id)
        {
            DepartmentDetail department = _context.DepartmentDetails.Find(id);
            if (department == null)
            {
                throw new InvalidOperationException($"No department is found having ID = {id}");
            }
            return department;

        }

        public void UpdateDepartment(int id, DepartmentDetail department)
        {
            DepartmentDetail dep = _context.DepartmentDetails.Find(id);
            if (dep == null)
            {
                throw new InvalidOperationException($"No department is found having ID = {id}");
            }
            dep.DepartmentName = department.DepartmentName;
            _context.SaveChanges();

        }
    }


}
