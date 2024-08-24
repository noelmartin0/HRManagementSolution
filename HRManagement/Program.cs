using HRManagement.Areas.Admin.Models;
using HRManagement.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<HRManagementDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("nwCnstring")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IPayrollRepo, PayrollRepo>();
builder.Services.AddScoped<ILeaveRepo, LeaveRepo>();
builder.Services.AddScoped<IPerformanceRepo, PerformanceRepo>();
builder.Services.AddScoped<ITrainingRepo, TrainingRepo>();
builder.Services.AddScoped<IResignationRepo, ResignationRepo>();
builder.Services.AddScoped<HRManagement.Areas.Admin.Models.IResumeRepo, HRManagement.Areas.Admin.Models.ResumeTrackingRepo>();
builder.Services.AddScoped<HRManagement.Models.IResumeRepo, HRManagement.Models.ResumeTrackingRepo>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
