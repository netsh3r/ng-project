using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ng_project.Migrations
{
    public partial class _133 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Participants_ParticipantsId",
                table: "ProjectWorker");

            migrationBuilder.DropTable(
                name: "SkillsParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker");

            migrationBuilder.DropIndex(
                name: "IX_ProjectWorker_ProjectsId",
                table: "ProjectWorker");

            migrationBuilder.DropIndex(
                name: "IX_NewsImages_NewsId",
                table: "NewsImages");

            migrationBuilder.DropColumn(
                name: "Teg",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "ProjectWorker",
                newName: "WorkersId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjectTypeId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TegId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker",
                columns: new[] { "ProjectsId", "WorkersId" });

            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tegs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tegs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypeSkill",
                columns: table => new
                {
                    BaseSkillsId = table.Column<int>(type: "int", nullable: false),
                    ProjectTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypeSkill", x => new { x.BaseSkillsId, x.ProjectTypesId });
                    table.ForeignKey(
                        name: "FK_ProjectTypeSkill_ProjectTypes_ProjectTypesId",
                        column: x => x.ProjectTypesId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTypeSkill_Skills_BaseSkillsId",
                        column: x => x.BaseSkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorker_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsImages_NewsId",
                table: "NewsImages",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_News_TegId",
                table: "News",
                column: "TegId");

            migrationBuilder.CreateIndex(
                name: "IX_Creators_UserId",
                table: "Creators",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTypeSkill_ProjectTypesId",
                table: "ProjectTypeSkill",
                column: "ProjectTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Tegs_TegId",
                table: "News",
                column: "TegId",
                principalTable: "Tegs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                principalTable: "ProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Participants_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Tegs_TegId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Participants_WorkersId",
                table: "ProjectWorker");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DropTable(
                name: "ProjectTypeSkill");

            migrationBuilder.DropTable(
                name: "Tegs");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker");

            migrationBuilder.DropIndex(
                name: "IX_ProjectWorker_WorkersId",
                table: "ProjectWorker");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_NewsImages_NewsId",
                table: "NewsImages");

            migrationBuilder.DropIndex(
                name: "IX_News_TegId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TegId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "WorkersId",
                table: "ProjectWorker",
                newName: "ParticipantsId");

            migrationBuilder.AddColumn<string>(
                name: "Teg",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker",
                columns: new[] { "ParticipantsId", "ProjectsId" });

            migrationBuilder.CreateTable(
                name: "SkillsParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsParticipants_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillsParticipants_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorker_ProjectsId",
                table: "ProjectWorker",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsImages_NewsId",
                table: "NewsImages",
                column: "NewsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillsParticipants_ParticipantId",
                table: "SkillsParticipants",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsParticipants_SkillId",
                table: "SkillsParticipants",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Participants_ParticipantsId",
                table: "ProjectWorker",
                column: "ParticipantsId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
