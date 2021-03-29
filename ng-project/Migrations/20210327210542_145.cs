using Microsoft.EntityFrameworkCore.Migrations;

namespace ng_project.Migrations
{
    public partial class _145 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectSubscriber",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    SubscribersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSubscriber", x => new { x.ProjectsId, x.SubscribersId });
                    table.ForeignKey(
                        name: "FK_ProjectSubscriber_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProjectSubscriber_Subscribers_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });
            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubscriber_SubscribersId",
                table: "ProjectSubscriber",
                column: "SubscribersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
