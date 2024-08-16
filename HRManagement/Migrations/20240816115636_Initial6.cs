using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentDetailDepartmentId",
                table: "ResignationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDetailDepartmentId",
                table: "PerformanceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResignationDetails_DepartmentDetailDepartmentId",
                table: "ResignationDetails",
                column: "DepartmentDetailDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceDetails_DepartmentDetailDepartmentId",
                table: "PerformanceDetails",
                column: "DepartmentDetailDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceDetails_DepartmentDetails_DepartmentDetailDepartmentId",
                table: "PerformanceDetails",
                column: "DepartmentDetailDepartmentId",
                principalTable: "DepartmentDetails",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResignationDetails_DepartmentDetails_DepartmentDetailDepartmentId",
                table: "ResignationDetails",
                column: "DepartmentDetailDepartmentId",
                principalTable: "DepartmentDetails",
                principalColumn: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceDetails_DepartmentDetails_DepartmentDetailDepartmentId",
                table: "PerformanceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ResignationDetails_DepartmentDetails_DepartmentDetailDepartmentId",
                table: "ResignationDetails");

            migrationBuilder.DropIndex(
                name: "IX_ResignationDetails_DepartmentDetailDepartmentId",
                table: "ResignationDetails");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceDetails_DepartmentDetailDepartmentId",
                table: "PerformanceDetails");

            migrationBuilder.DropColumn(
                name: "DepartmentDetailDepartmentId",
                table: "ResignationDetails");

            migrationBuilder.DropColumn(
                name: "DepartmentDetailDepartmentId",
                table: "PerformanceDetails");
        }
    }
}
