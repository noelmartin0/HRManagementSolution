using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "ResignationDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EvaluatorName",
                table: "PerformanceDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDetailDepartmentId",
                table: "PerformanceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "DepartmentDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceDetails_DepartmentDetails_DepartmentDetailDepartmentId",
                table: "PerformanceDetails");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceDetails_DepartmentDetailDepartmentId",
                table: "PerformanceDetails");

            migrationBuilder.DropColumn(
                name: "DepartmentDetailDepartmentId",
                table: "PerformanceDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "ResignationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EvaluatorName",
                table: "PerformanceDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "DepartmentDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
