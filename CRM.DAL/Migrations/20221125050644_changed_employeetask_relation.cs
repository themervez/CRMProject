using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DAL.Migrations
{
    public partial class changed_employeetask_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_EmployeeId",
                table: "EmployeeTasks");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeTasks",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTasks_EmployeeId",
                table: "EmployeeTasks",
                newName: "IX_EmployeeTasks_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_AspNetUsers_AppUserId",
                table: "EmployeeTasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_AspNetUsers_AppUserId",
                table: "EmployeeTasks");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "EmployeeTasks",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTasks_AppUserId",
                table: "EmployeeTasks",
                newName: "IX_EmployeeTasks_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_EmployeeId",
                table: "EmployeeTasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
