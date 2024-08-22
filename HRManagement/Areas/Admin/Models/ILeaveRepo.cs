﻿namespace HRManagement.Models
{
    public interface ILeaveRepo
    {
        void UpdateEmployeeLeaveDetail(int id, LeaveDetail leave);
        LeaveDetail GetLeaveByEmployeeId(int empid);
        LeaveDetail GetLeaveByLeaveId(int id);
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



        LeaveDetail ILeaveRepo.GetLeaveByEmployeeId(int empid)
        {
            return _context.LeaveDetails.FirstOrDefault(e => e.EmployeeId == empid);
            
        }

        LeaveDetail ILeaveRepo.GetLeaveByLeaveId(int id)
        {
           return _context.LeaveDetails.Find(id);
        }
    }
}