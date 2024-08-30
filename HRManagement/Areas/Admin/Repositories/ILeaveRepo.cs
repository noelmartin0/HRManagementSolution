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
            int? sl = leave.SickLeaves;
            int? h = leave.Holidays;
            int? v = leave.VacationDays;

            if (l != null)
            {
                // Update only the fields that are not null or have been changed
                if (sl != 0)
                {
                    l.SickLeaves = sl.Value;
                }

                if (h != 0)
                {
                    l.Holidays = h.Value;
                }

                if (v != 0)
                {
                    l.VacationDays = v.Value;
                }

                if (leave.DaysTaken != 0)
                {
                    l.DaysTaken = leave.DaysTaken.Value;
                }

                // Recalculate the remaining leave days
                l.CalculateDays();

                // Save changes to the database
                _context.SaveChanges();

            }
            else
                throw new InvalidOperationException($"No records found for Leave ID {id} ");


        }

        LeaveDetail ILeaveRepo.GetLeaveByEmployeeId(int empid)
        {
            
            LeaveDetail leave = _context.LeaveDetails.FirstOrDefault(e => e.EmployeeId == empid);
            if (leave != null)
            return leave;
            else
                throw new InvalidOperationException($"No records found for Employee ID {empid} ");

        }

        LeaveDetail ILeaveRepo.GetLeaveByLeaveId(int id)
        {
            LeaveDetail leave = _context.LeaveDetails.Find(id);
            if (leave != null)
                return leave;
            else
                throw new InvalidOperationException($"No records found for Leave ID {id} ");
        }

        public void UpdateByEmployeeId(int empid, LeaveDetail leave)
        {
            // Fetch the LeaveDetail record for the specified EmployeeId
            LeaveDetail l = _context.LeaveDetails.FirstOrDefault(e => e.EmployeeId == empid);
            int? sl = leave.SickLeaves;
            int? h = leave.Holidays;
            int? v = leave.VacationDays;

            if (l != null)
            {
                // Update only the fields that are not null or have been changed
                if (sl!=0)
                {
                    l.SickLeaves = sl.Value;
                }

                if (h!=0)
                {
                    l.Holidays = h.Value;
                }

                if (v!=0)
                {
                    l.VacationDays = v.Value;
                }

                if (leave.DaysTaken!=0)
                {
                    l.DaysTaken = leave.DaysTaken.Value;
                }

                // Recalculate the remaining leave days
                l.CalculateDays();

                // Save changes to the database
                _context.SaveChanges();
            }
            else
                throw new InvalidOperationException($"No records found for Employee ID {empid} ");
        }


        void ILeaveRepo.AddEmployeeLeave(LeaveDetail leave)
        {
            _context.LeaveDetails.Add(leave);
            _context.SaveChanges(); 
        }
    }
}



