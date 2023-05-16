using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceMaster.Migrations
{
    public partial class AddBaseSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DropTable(
                name: "ResourceSkill");

            migrationBuilder.DropColumn(
                name: "Necessity",
                table: "ResourceSkills");

            migrationBuilder.AddColumn<bool>(
                name: "IsCertification",
                table: "ProjectSkills",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Necessity",
                table: "ProjectSkills",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "ProjectSkills",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCertification",
                table: "ProjectSkills");

            migrationBuilder.DropColumn(
                name: "Necessity",
                table: "ProjectSkills");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "ProjectSkills");

            migrationBuilder.AddColumn<string>(
                name: "Necessity",
                table: "ResourceSkills",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceSkill",
                columns: table => new
                {
                    ResourcesId = table.Column<int>(type: "integer", nullable: false),
                    SkillsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSkill", x => new { x.ResourcesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ResourceSkill_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_SkillId",
                table: "ProjectSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkill_SkillsId",
                table: "ResourceSkill",
                column: "SkillsId");
        }
    }
}
