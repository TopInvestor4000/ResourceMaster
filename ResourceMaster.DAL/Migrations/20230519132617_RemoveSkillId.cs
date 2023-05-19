using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceMaster.Migrations
{
    public partial class RemoveSkillId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectSkillId",
                table: "ProjectSkills",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectStart",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProjectSkills",
                newName: "ProjectSkillId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectStart",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
