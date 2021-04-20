using Microsoft.EntityFrameworkCore.Migrations;

namespace ng_project.Migrations
{
    public partial class _157 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifies_Projects_ProjectId",
                table: "Notifies");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifies_Projects_ProjectId",
                table: "Notifies",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifies_Projects_ProjectId",
                table: "Notifies");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifies_Projects_ProjectId",
                table: "Notifies",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
