using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangeTaskTableAdjustAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "task_attachment_file");

            migrationBuilder.AddColumn<string>(
                name: "base64",
                table: "task_attachment_file",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "content_type",
                table: "task_attachment_file",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "task_attachment_file",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "base64",
                table: "task_attachment_file");

            migrationBuilder.DropColumn(
                name: "content_type",
                table: "task_attachment_file");

            migrationBuilder.DropColumn(
                name: "name",
                table: "task_attachment_file");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "task_attachment_file",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
