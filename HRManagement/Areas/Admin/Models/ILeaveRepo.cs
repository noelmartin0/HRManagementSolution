namespace HRManagement.Models
{
    interface ILeaveRepo
    {
        void UpdateEmployeeLeaveDetail(int id, LeaveDetail leave);
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
            l.TotalDays = leave.TotalDays;
            l.DaysTaken = leave.DaysTaken;
            l.DaysRemaining = l.TotalDays - l.DaysTaken;
            _context.SaveChanges();

        }

    }
}