using Microsoft.EntityFrameworkCore.Migrations;

namespace ng_project.Migrations
{
    public partial class _148 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTypeRoles",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypeRoles", x => new { x.ProjectTypeId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_ProjectTypeRoles_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProjectTypeRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTypeRoles_RolesId",
                table: "ProjectTypeRoles",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTypeRoles");
        }
    }
}
