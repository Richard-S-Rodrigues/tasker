using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    public partial class UpdateTaskTableAddTaskChecklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_task_checklist_task_id",
                table: "task_checklist",
                column: "task_id");

            migrationBuilder.AddForeignKey(
                name: "FK_task_checklist_task_task_id",
                table: "task_checklist",
                column: "task_id",
                principalTable: "task",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_task_checklist_task_task_id",
                table: "task_checklist");

            migrationBuilder.DropIndex(
                name: "IX_task_checklist_task_id",
                table: "task_checklist");
        }
    }
}
