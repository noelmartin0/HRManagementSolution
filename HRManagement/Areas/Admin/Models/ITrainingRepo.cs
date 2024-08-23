using HRManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Areas.Admin.Models
{
    public interface ITrainingRepo
    {
        TrainingDetail GetTrainingByTrainingId(int trid);
        List<TrainingDetail> GetAllTrainings();
        List<EmployeeDetail> GetAllEmployeesByTrainingId(int trid);
        public List<TrainingDetail> GetTrainingsByEmployeeId(int empid);

        void AddTraining(TrainingDetail trainingdetail);
        void UpdateTraining(int id, TrainingDetail training);
        void DeleteTraining(int trid);


    }
    public class TrainingRepo : ITrainingRepo
    {
        HRManagementDBContext _context;
        public TrainingRepo(HRManagementDBContext _context)
        {
            this._context= _context;    

        }
        public void AddTraining(TrainingDetail trainingdetail)
        {
            _context.TrainingDetails.Add(trainingdetail);
            _context.SaveChanges();
        }

        public void DeleteTraining(int trid)
        {
            TrainingDetail tr = _context.TrainingDetails.Find(trid);
            _context.TrainingDetails.Remove(tr);
            _context.SaveChanges();

        }

      
            public List<EmployeeDetail> GetAllEmployeesByTrainingId(int trainingId)
            {
                // this is where it fetches all EmployeeTrainingDetails where TrainingId matches the passed TID
                var employeeIds = _context.EmployeeTrainingDetails
                    .Where(et => et.TrainingId == trainingId)
                    .Select(et => et.EmployeeId)
                    .ToList();

                // Fetching EmployeeDetails for the retrieved EmployeeIds
                List<EmployeeDetail> employees = _context.EmployeeDetails
                    .Where(e => employeeIds.Contains(e.EmployeeId))
                    .ToList();

                return employees;
            }

        

        public List<TrainingDetail> GetAllTrainings()
        {
            return _context.TrainingDetails.ToList();

        }

        public TrainingDetail GetTrainingByTrainingId(int trid)
        {
            return _context.TrainingDetails.Find(trid);
        }

        public void UpdateTraining(int id, TrainingDetail training)
        {
            TrainingDetail model = _context.TrainingDetails.Find(id);
            model.TrainingName = training.TrainingName;
            _context.SaveChanges();
        }

        List<TrainingDetail> ITrainingRepo.GetTrainingsByEmployeeId(int empid)
        {
            var trainingIds = _context.EmployeeTrainingDetails
      .Where(et => et.EmployeeId == empid)
      .Select(et => et.TrainingId)
      .ToList();

            // this fetches TrainingDetails for the filtered trainingIds from the employeeid that we enter
            List<TrainingDetail> trainings = _context.TrainingDetails
                .Where(t => trainingIds.Contains(t.TrainingId))
                .ToList();

            return trainings;
        }
    }
}
