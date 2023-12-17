using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Web.Migrations
{
    /// <inheritdoc />
    public partial class _Mig_UpdateProjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News_NewsGalleries");

            migrationBuilder.DropTable(
                name: "NewsGalleries");

            migrationBuilder.DropTable(
                name: "ProjectGalleries");

            migrationBuilder.DropTable(
                name: "Projects_Galleries");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Projects",
                newName: "ShamsiDateString");

            migrationBuilder.AddColumn<string>(
                name: "MainImageName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondImageName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => new { x.NewsId, x.Id });
                    table.ForeignKey(
                        name: "FK_Galleries_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropColumn(
                name: "MainImageName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SecondImageName",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ShamsiDateString",
                table: "Projects",
                newName: "ImageName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "News_NewsGalleries",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News_NewsGalleries", x => new { x.NewsId, x.Id });
                    table.ForeignKey(
                        name: "FK_News_NewsGalleries_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsGalleries_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectGalleries_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects_Galleries",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects_Galleries", x => new { x.ProjectId, x.Id });
                    table.ForeignKey(
                        name: "FK_Projects_Galleries_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsGalleries_NewsId",
                table: "NewsGalleries",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGalleries_ProjectId",
                table: "ProjectGalleries",
                column: "ProjectId");
        }
    }
}
