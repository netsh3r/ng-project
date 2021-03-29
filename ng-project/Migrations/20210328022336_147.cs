using Microsoft.EntityFrameworkCore.Migrations;

namespace ng_project.Migrations
{
    public partial class _147 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Tegs_TegId",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "TegId",
                table: "News",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Tegs_TegId",
                table: "News",
                column: "TegId",
                principalTable: "Tegs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Tegs_TegId",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "TegId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Tegs_TegId",
                table: "News",
                column: "TegId",
                principalTable: "Tegs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
