using Microsoft.EntityFrameworkCore;
using HRManagement.Areas.Admin.Models;

namespace HRManagement.Models
{
    public class HRManagementDBContext:DbContext
    {
        public HRManagementDBContext()
        {

        }
        public HRManagementDBContext(DbContextOptions<HRManagementDBContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeeDetail>()
        //   .Property(p => p.EmployeeId + 1)
        //   .ValueGeneratedOnAdd();
        //}
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet <PayrollDetail> PayrollDetails { get; set; }
        public DbSet<TrainingDetail> TrainingDetails { get; set; }
        public DbSet<PerformanceDetail> PerformanceDetails { get; set; }
        public DbSet<LeaveDetail> LeaveDetails{ get; set; }
        public DbSet<DepartmentDetail> DepartmentDetails { get; set; }
        public DbSet<ResignationDetail> ResignationDetails{get; set; }
        public DbSet<ResumeTrackingDetail>ResumeTrackingDetails { get; set; } 
        public DbSet<EmployeeTrainingDetail>EmployeeTrainingDetails { get; set; }
        public DbSet<Author>Authors { get; set; }
        public DbSet<Book>Books { get; set; }
    }
}
