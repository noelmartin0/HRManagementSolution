using Microsoft.EntityFrameworkCore;
using HRManagement.Models;
using HRManagement.Areas.Admin.Models;

namespace HRManagement.Models
{
    public class HRManagementDBContext:DbContext
    {
        
        public HRManagementDBContext(DbContextOptions<HRManagementDBContext> options) : base(options)
        {

        }
     
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet <PayrollDetail> PayrollDetails { get; set; }
        public DbSet<TrainingDetail> TrainingDetails { get; set; }
        public DbSet<PerformanceDetail> PerformanceDetails { get; set; }
        public DbSet<LeaveDetail> LeaveDetails{ get; set; }
        public DbSet<DepartmentDetail> DepartmentDetails { get; set; }
        public DbSet<ResignationDetail> ResignationDetails{get; set; }
        public DbSet<ResumeTrackingDetail> ResumeTrackingDetails { get; set; } 
        public DbSet<EmployeeTrainingDetail> EmployeeTrainingDetails { get; set; }
        public DbSet<AdminLogin> AdminLoginDetails { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DepartmentDetail>()
        //   .HasMany(d => d.EmployeeDetail)
        //   .WithOne(e => e.DepartmentDetail)
        //   .HasForeignKey(e => e.DepartmentId);

        //    modelBuilder.Entity<EmployeeDetail>()
        //   .HasOne(e => e.PayrollDetail)
        //   .WithOne(p => p.EmployeeDetail)
        //   .HasForeignKey<PayrollDetail>(p => p.EmployeeId);

        //    modelBuilder.Entity<EmployeeDetail>()
        // .HasOne(e => e.LeaveDetail)
        // .WithOne(p => p.EmployeeDetail)
        // .HasForeignKey<LeaveDetail>(p => p.EmployeeId);

        //    modelBuilder.Entity<EmployeeDetail>()
        //   .HasOne(e => e.PerformanceDetail)
        //   .WithOne(p => p.EmployeeDetail)
        //   .HasForeignKey<PerformanceDetail>(p => p.EmployeeId);

        //    modelBuilder.Entity<EmployeeDetail>()
        //  .HasOne(e => e.ResignationDetail)
        //  .WithOne(p => p.EmployeeDetail)
        //  .HasForeignKey<ResignationDetail>(p => p.EmployeeId);

        //    modelBuilder.Entity<EmployeeTrainingDetail>()
        //        .HasOne(e => e.EmployeeDetail)
        //        .WithMany(d => d.EmployeeTrainingDetail)
        //        .HasForeignKey(e => e.EmployeeId);

        //    modelBuilder.Entity<EmployeeTrainingDetail>()
        //       .HasOne(e => e.TrainingDetail)
        //       .WithMany(d => d.EmployeeTrainingDetail)
        //       .HasForeignKey(e => e.TrainingId);
        //}



    }
}
