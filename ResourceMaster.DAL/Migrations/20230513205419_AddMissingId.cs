using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ResourceMaster.Migrations
{
    public partial class AddMissingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceSkill_Skills_SkillsSkillId",
                table: "ResourceSkill");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SkillsSkillId",
                table: "ResourceSkill",
                newName: "SkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceSkill_SkillsSkillId",
                table: "ResourceSkill",
                newName: "IX_ResourceSkill_SkillsId");

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                columns: table => new
                {
                    ProjectSkillId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    RequiredWorkHours = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkills", x => x.ProjectSkillId);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceProjects",
                columns: table => new
                {
                    ResourceProjectId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    BookedFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BookedTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceProjects", x => x.ResourceProjectId);
                    table.ForeignKey(
                        name: "FK_ResourceProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceProjects_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    IsCertification = table.Column<bool>(type: "boolean", nullable: false),
                    SkillLevel = table.Column<string>(type: "text", nullable: false),
                    Necessity = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceSkills_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_ProjectId",
                table: "ProjectSkills",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_SkillId",
                table: "ProjectSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceProjects_ProjectId",
                table: "ResourceProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceProjects_ResourceId",
                table: "ResourceProjects",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkills_ResourceId",
                table: "ResourceSkills",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkills_SkillId",
                table: "ResourceSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceSkill_Skills_SkillsId",
                table: "ResourceSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceSkill_Skills_SkillsId",
                table: "ResourceSkill");

            migrationBuilder.DropTable(
                name: "ProjectSkills");

            migrationBuilder.DropTable(
                name: "ResourceProjects");

            migrationBuilder.DropTable(
                name: "ResourceSkills");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "ResourceSkill",
                newName: "SkillsSkillId");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceSkill_SkillsId",
                table: "ResourceSkill",
                newName: "IX_ResourceSkill_SkillsSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceSkill_Skills_SkillsSkillId",
                table: "ResourceSkill",
                column: "SkillsSkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
