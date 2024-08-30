using HRManagement.Models;

namespace HRManagement.Areas.Admin.Models
{
    public interface IEmployeeTrainingRepo
    {
        List<EmployeeTrainingDetail> GetAllRecords();
        void AddEmpTrainingDependancy(EmployeeTrainingDetail model);
        void DeleteEmpTrainingDependancyByEmployeeIdAndTrainingId(int empId, int TraId);
        void UpdateEmpTrainingDependancy(int empId, int TraId, EmployeeTrainingDetail model);
    }

    public class EmployeeTrainingRepo : IEmployeeTrainingRepo
    {
        HRManagementDBContext _context;
        public EmployeeTrainingRepo(HRManagementDBContext _context)
        {
            this._context = _context;
        }
        public void AddEmpTrainingDependancy(EmployeeTrainingDetail model)
        {
            _context.EmployeeTrainingDetails.Add(model);
            _context.SaveChanges();
            CheckForUpdatingPayroll(model);
            if (model.TrainingStatus == "Completed")
                UpdateXoxoPoints(model.EmployeeId);

        }

        private void UpdateXoxoPoints(int empId)
        {
            PerformanceDetail performanceDetail = _context.PerformanceDetails.FirstOrDefault(e => e.EmployeeId == empId);
            performanceDetail.XoxoPoints += 50;
            _context.SaveChanges();
        }

        private void CheckForUpdatingPayroll(EmployeeTrainingDetail model)
        {
            var trainingIds = _context.EmployeeTrainingDetails
                 .Where(et => et.EmployeeId == model.EmployeeId && et.TrainingStatus == "Completed")
                 .Select(et => et.TrainingId)
                 .ToList();

            // this fetches TrainingDetails for the filtered trainingIds from the employeeid that we enter
            List<TrainingDetail> trainings = _context.TrainingDetails
                .Where(t => trainingIds.Contains(t.TrainingId))
                .ToList();
            if (trainings.Count == 2 && model.flag == 0)
            {
                UpdatePayroll(model.EmployeeId);
                model.flag = 1;

            }
        }

        public void DeleteEmpTrainingDependancyByEmployeeIdAndTrainingId(int empId, int TraId)
        {
            EmployeeTrainingDetail model = _context.EmployeeTrainingDetails.FirstOrDefault(et => et.EmployeeId == empId && et.TrainingId == TraId);
            if (model == null)
            {
                throw new InvalidOperationException($"No records found for Employee ID {empId} and Training ID {TraId}");
            }
            else
            {
                _context.EmployeeTrainingDetails.Remove(model);
                _context.SaveChanges();
            }
        }

        public List<EmployeeTrainingDetail> GetAllRecords()
        {
            return _context.EmployeeTrainingDetails.ToList();
        }

        public void UpdateEmpTrainingDependancy(int empId, int TraId, EmployeeTrainingDetail model)
        {
            EmployeeTrainingDetail record = _context.EmployeeTrainingDetails.FirstOrDefault(et => et.EmployeeId == empId && et.TrainingId == TraId);
            if (record == null)
            {
                throw new InvalidOperationException($"No records found for Employee ID {empId} and Training ID {TraId}");
            }
            else
            {
                record.TrainingStatus = model.TrainingStatus;
                _context.SaveChanges();
                if (model.TrainingStatus == "Completed")
                    UpdateXoxoPoints(model.EmployeeId);
                CheckForUpdatingPayroll(record);
            }

        }

        private void UpdatePayroll(int empid)
        {
            
            PayrollDetail payroll = _context.PayrollDetails.FirstOrDefault(e => e.EmployeeId == empid);

            payroll.Basicpay = payroll.Basicpay * (decimal)0.15 + payroll.Basicpay;
            payroll.CalculatePay();
            _context.SaveChanges();
        }
    }


}


