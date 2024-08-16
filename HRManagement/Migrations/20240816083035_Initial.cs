using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResignationDetails",
                columns: table => new
                {
                    Sno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentDetailDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResignationDetails", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_ResignationDetails_DepartmentDetails_DepartmentDetailDepartmentId",
                        column: x => x.DepartmentDetailDepartmentId,
                        principalTable: "DepartmentDetails",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_ResignationDetails_EmployeeDetails_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeDetails",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResignationDetails_DepartmentDetailDepartmentId",
                table: "ResignationDetails",
                column: "DepartmentDetailDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResignationDetails_EmployeeId",
                table: "ResignationDetails",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResignationDetails");
        }
    }
}
