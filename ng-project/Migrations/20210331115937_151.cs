using Microsoft.EntityFrameworkCore.Migrations;

namespace ng_project.Migrations
{
    public partial class _151 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectSubTypeId",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectSubTypeId",
                table: "Projects",
                column: "ProjectSubTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectSubTypeId",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectSubTypeId",
                table: "Projects",
                column: "ProjectSubTypeId",
                unique: true);
        }
    }
}
