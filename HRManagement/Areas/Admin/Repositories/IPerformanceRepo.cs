namespace HRManagement.Models
{
    public interface IPerformanceRepo
    {
        void AddEmployeePerformance(PerformanceDetail performance);
        void UpdateEmployeePerformance(int id, PerformanceDetail performance);
        PerformanceDetail GetPerformanceById(int id);
        void DeleteEmployeePerformance(int id);
        PerformanceDetail GetPerformanceByEmpID(int empid);
       // public void UpdateEmployeeCredentials(int empId,int deptId);

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
            if(m==null)
              
                    throw new InvalidOperationException($"No Performance details found for Performance ID {id}");
            else
            return m;
        }

        public void UpdateEmployeePerformance(int id, PerformanceDetail performance)
        {
            PerformanceDetail e = _context.PerformanceDetails.Find(id);
            if (e != null)
            {
                e.EvaluatorName = performance.EvaluatorName;
                e.EvaluationPeriod = performance.EvaluationPeriod;
                e.XoxoPoints = performance.XoxoPoints;
                _context.SaveChanges();
            }
            else throw new InvalidOperationException($"No Performance details found for Performance ID {id}");

        }

        public void DeleteEmployeePerformance(int id)
        {

            PerformanceDetail p = _context.PerformanceDetails.Find(id);
            if (p != null)
            {
                _context.PerformanceDetails.Remove(p);
                _context.SaveChanges();
            }
            else throw new InvalidOperationException($"No Performance details found for Performance ID {id}");

        }

        public PerformanceDetail GetPerformanceByEmpID(int empid)
        {

            PerformanceDetail p = _context.PerformanceDetails.FirstOrDefault(e => e.EmployeeId == empid);
            if(p != null)
            return p;
            else             
                throw new InvalidOperationException($"No Performance details found for Employee ID {empid}");


        }




    }
}


