namespace HRManagement.Models
{
    public interface IPerformanceRepo
    {
        void AddEmployeePerformance(PerformanceDetail performance);
        void UpdateEmployeePerformance(int id, PerformanceDetail performance);
        PerformanceDetail GetPerformanceById(int id);
        void DeleteEmployeePerformance(int id);
        PerformanceDetail GetPerformanceByEmpID(int empid);

    }

    public class PerformanceRepo : IPerformanceRepo
    {
        HRManagementDBContext _context;
        public PerformanceRepo(HRManagementDBContext context)
        {
            _context = context;
        }

        public void AddEmployeePerformance(PerformanceDetail performance)
        {
            _context.PerformanceDetails.Add(performance);
            _context.SaveChanges();

        }

        public PerformanceDetail GetPerformanceById(int id)
        {
            PerformanceDetail m=_context.PerformanceDetails.Find(id);
            return m;
        }

        public void UpdateEmployeePerformance(int id, PerformanceDetail performance)
        {
            PerformanceDetail e = _context.PerformanceDetails.Find(id);
            e.EvaluatorName = performance.EvaluatorName;
            e.EvaluationPeriod = performance.EvaluationPeriod;
            _context.SaveChanges();
        }

        public void DeleteEmployeePerformance(int id)
        {
            PerformanceDetail p = _context.PerformanceDetails.Find(id);
            _context.PerformanceDetails.Remove(p);
            _context.SaveChanges();
        }

        public PerformanceDetail GetPerformanceByEmpID(int empid)
        {
            return _context.PerformanceDetails.FirstOrDefault(e => e.EmployeeId == empid);
           
        }
    }
}


