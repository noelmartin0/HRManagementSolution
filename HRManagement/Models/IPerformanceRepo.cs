﻿namespace HRManagement.Models
{
    interface IPerformanceRepo
    {
        void AddEmployeePerformance(PerformanceDetail performance);
        void UpdateEmployeePerformance(int id, PerformanceDetail performance);

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

        public void UpdateEmployeePerformance(int id, PerformanceDetail performance)
        {
            PerformanceDetail e = _context.PerformanceDetails.Find(id);
            e.EvaluatorName = performance.EvaluatorName;
            e.EvaluationPeriod = performance.EvaluationPeriod;
            _context.SaveChanges();
        }



    }
}


