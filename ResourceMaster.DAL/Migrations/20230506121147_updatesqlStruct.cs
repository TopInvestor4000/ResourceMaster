using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceMaster.Migrations
{
    /// <inheritdoc />
    public partial class updatesqlStruct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_customerid",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Projects_Projectid",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Resources_Resourceid",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_Projectid",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_Resourceid",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Projectid",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Resourceid",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "isCertification",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "necessity",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "age",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "country",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "location",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "street",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "zipCode",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "workForce",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "skillLevel",
                table: "Skills",
                newName: "SkillName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Resources",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Resources",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Resources",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "projectStart",
                table: "Projects",
                newName: "ProjectStart");

            migrationBuilder.RenameColumn(
                name: "projectName",
                table: "Projects",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "projectEnd",
                table: "Projects",
                newName: "ProjectEnd");

            migrationBuilder.RenameColumn(
                name: "customerid",
                table: "Projects",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_customerid",
                table: "Projects",
                newName: "IX_Projects_CustomerId");

            migrationBuilder.RenameColumn(
                name: "zipCode",
                table: "Customers",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Customers",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Customers",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Customers",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "companyName",
                table: "Customers",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customers",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectStart",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectEnd",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "ResourceId",
                table: "Projects",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectSkill",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkill", x => new { x.ProjectsId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceSkill",
                columns: table => new
                {
                    ResourcesId = table.Column<int>(type: "integer", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSkill", x => new { x.ResourcesId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_ResourceSkill_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceSkill_Skills_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ResourceId",
                table: "Projects",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_SkillId",
                table: "ProjectSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkill_SkillsSkillId",
                table: "ResourceSkill",
                column: "SkillsSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Resources_ResourceId",
                table: "Projects",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Resources_ResourceId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DropTable(
                name: "ResourceSkill");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ResourceId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "Skills",
                newName: "skillLevel");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Skills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Resources",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Resources",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Resources",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProjectStart",
                table: "Projects",
                newName: "projectStart");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Projects",
                newName: "projectName");

            migrationBuilder.RenameColumn(
                name: "ProjectEnd",
                table: "Projects",
                newName: "projectEnd");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Projects",
                newName: "customerid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                newName: "IX_Projects_customerid");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Customers",
                newName: "zipCode");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Customers",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Customers",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Customers",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Customers",
                newName: "companyName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Projectid",
                table: "Skills",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Resourceid",
                table: "Skills",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Skills",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isCertification",
                table: "Skills",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "necessity",
                table: "Skills",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Resources",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Resources",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Resources",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "Resources",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "zipCode",
                table: "Resources",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "projectStart",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "projectEnd",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "workForce",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Projectid",
                table: "Skills",
                column: "Projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Resourceid",
                table: "Skills",
                column: "Resourceid");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_customerid",
                table: "Projects",
                column: "customerid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Projects_Projectid",
                table: "Skills",
                column: "Projectid",
                principalTable: "Projects",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Resources_Resourceid",
                table: "Skills",
                column: "Resourceid",
                principalTable: "Resources",
                principalColumn: "id");
        }
    }
}
