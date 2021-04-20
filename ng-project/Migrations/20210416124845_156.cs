using Microsoft.EntityFrameworkCore.Migrations;

namespace ng_project.Migrations
{
    public partial class _156 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Notifies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifies_ProjectId",
                table: "Notifies",
                column: "ProjectId");

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

            migrationBuilder.DropIndex(
                name: "IX_Notifies_ProjectId",
                table: "Notifies");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Notifies");
        }
    }
}
