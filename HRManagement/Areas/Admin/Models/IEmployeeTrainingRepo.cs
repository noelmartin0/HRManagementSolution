using HRManagement.Models;

namespace HRManagement.Areas.Admin.Models
{
    public interface IEmployeeTrainingRepo
    {
        List<EmployeeTrainingDetail> GetAllRecords( );
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

            }

        }
    }


}
