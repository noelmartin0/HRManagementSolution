namespace HRManagement.Models
{
    public interface ILeaveRepo
    {
        void UpdateEmployeeLeaveDetail(int id, LeaveDetail leave);
        LeaveDetail GetLeaveByEmployeeId(int empid);
        LeaveDetail GetLeaveByLeaveId(int id);
        void AddEmployeeLeave(LeaveDetail leave);
        void UpdateByEmployeeId(int empid,LeaveDetail leave);
    }

    public class LeaveRepo : ILeaveRepo
    {
        HRManagementDBContext _context;
        public LeaveRepo(HRManagementDBContext context)
        {
            _context = context;
        }
        public void UpdateEmployeeLeaveDetail(int id, LeaveDetail leave)
        {
            LeaveDetail l = _context.LeaveDetails.Find(id);
            l.SickLeaves = leave.SickLeaves;
            l.Holidays = leave.Holidays;
            l.VacationDays = leave.VacationDays;
            l.TotalDays = l.SickLeaves + l.Holidays + l.VacationDays;
            l.DaysTaken = leave.DaysTaken;
            l.CalculateDays();
            _context.SaveChanges();
            
        }

        

        LeaveDetail ILeaveRepo.GetLeaveByEmployeeId(int empid)
        {
            return _context.LeaveDetails.FirstOrDefault(e => e.EmployeeId == empid);
            
        }

        LeaveDetail ILeaveRepo.GetLeaveByLeaveId(int id)
        {
           return _context.LeaveDetails.Find(id);
        }

        public void UpdateByEmployeeId(int empid,LeaveDetail leave)
        {
            LeaveDetail l = _context.LeaveDetails.FirstOrDefault(e => e.EmployeeId == empid);
            l.SickLeaves = leave.SickLeaves;
            l.Holidays = leave.Holidays;
            l.VacationDays = leave.VacationDays;
            l.TotalDays = l.SickLeaves + l.Holidays + l.VacationDays;
            l.DaysTaken = leave.DaysTaken;
            l.CalculateDays();
            _context.SaveChanges();
        }

        void ILeaveRepo.AddEmployeeLeave(LeaveDetail leave)
        {
            _context.LeaveDetails.Add(leave);
            _context.SaveChanges(); 
        }
    }
}