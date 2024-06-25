using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateTaskTableRemoveResponsibles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_responsibles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "task_responsibles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    estimated_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    task_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_responsibles", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_task_responsibles_task_task_id",
                        column: x => x.task_id,
                        principalTable: "task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_responsibles_task_id",
                table: "task_responsibles",
                column: "task_id");
        }
    }
}
