using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Migrations
{
    public partial class IntialDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentDetails",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDetails", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ResumeTrackingsDetails",
                columns: table => new
                {
                    ResumeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaOfInterest = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTrackingsDetails", x => x.ResumeID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDetails",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDetails", x => x.TrainingId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_DepartmentDetails_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentDetails",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTrainingDetails",
                columns: table => new
                {
                    SNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeDetailEmployeeId = table.Column<int>(type: "int", nullable: true),
                    TrainingDetailTrainingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTrainingDetails", x => x.SNo);
                    table.ForeignKey(
                        name: "FK_EmployeeTrainingDetails_EmployeeDetails_EmployeeDetailEmployeeId",
                        column: x => x.EmployeeDetailEmployeeId,
                        principalTable: "EmployeeDetails",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_EmployeeTrainingDetails_TrainingDetails_TrainingDetailTrainingId",
                        column: x => x.TrainingDetailTrainingId,
                        principalTable: "TrainingDetails",
                        principalColumn: "TrainingId");
                });

            migrationBuilder.CreateTable(
                name: "LeaveManagements",
                columns: table => new
                {
                    SNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    DaysTaken = table.Column<int>(type: "int", nullable: false),
                    DaysRemaining = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveManagements", x => x.SNo);
                    table.ForeignKey(
                        name: "FK_LeaveManagements_EmployeeDetails_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeDetails",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollDeatils",
                columns: table => new
                {
                    PayrollID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Basicpay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Grosspay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Netpay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollDeatils", x => x.PayrollID);
                    table.ForeignKey(
                        name: "FK_PayrollDeatils_EmployeeDetails_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeDetails",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceDetails",
                columns: table => new
                {
                    PerformanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EvaluatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationPeriod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceDetails", x => x.PerformanceId);
                    table.ForeignKey(
                        name: "FK_PerformanceDetails_EmployeeDetails_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeDetails",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_DepartmentId",
                table: "EmployeeDetails",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTrainingDetails_EmployeeDetailEmployeeId",
                table: "EmployeeTrainingDetails",
                column: "EmployeeDetailEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTrainingDetails_TrainingDetailTrainingId",
                table: "EmployeeTrainingDetails",
                column: "TrainingDetailTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveManagements_EmployeeId",
                table: "LeaveManagements",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDeatils_EmployeeID",
                table: "PayrollDeatils",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceDetails_EmployeeId",
                table: "PerformanceDetails",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTrainingDetails");

            migrationBuilder.DropTable(
                name: "LeaveManagements");

            migrationBuilder.DropTable(
                name: "PayrollDeatils");

            migrationBuilder.DropTable(
                name: "PerformanceDetails");

            migrationBuilder.DropTable(
                name: "ResumeTrackingsDetails");

            migrationBuilder.DropTable(
                name: "TrainingDetails");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "DepartmentDetails");
        }
    }
}
