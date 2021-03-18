using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ng_project.Migrations
{
    public partial class ProjectImage3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Images_Projects_ProjectId",
            //    table: "Images");

            //migrationBuilder.DropIndex(
            //    name: "IX_Images_ProjectId",
            //    table: "Images");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    table: "Images");

            //migrationBuilder.DropColumn(
            //    name: "ProjectId",
            //    table: "Images");

            migrationBuilder.CreateTable(
                name: "MainProjectImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainProjectImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainProjectImages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "ProjectImages",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectId = table.Column<int>(type: "int", nullable: false),
            //        Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProjectImages", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProjectImages_Projects_ProjectId",
            //            column: x => x.ProjectId,
            //            principalTable: "Projects",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_MainProjectImages_ProjectId",
                table: "MainProjectImages",
                column: "ProjectId",
                unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProjectImages_ProjectId",
            //    table: "ProjectImages",
            //    column: "ProjectId",
            //    unique: true);
        }

    }
}
