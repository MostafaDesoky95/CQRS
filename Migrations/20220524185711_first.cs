using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "PhotoAlbum",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoAlbum", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoAlbumID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Photo_PhotoAlbum_PhotoAlbumID",
                        column: x => x.PhotoAlbumID,
                        principalSchema: "dbo",
                        principalTable: "PhotoAlbum",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabicTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverPhotoID = table.Column<int>(type: "int", nullable: false),
                    SourceID = table.Column<int>(type: "int", nullable: false),
                    PhotoAlbumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_Photo_CoverPhotoID",
                        column: x => x.CoverPhotoID,
                        principalSchema: "dbo",
                        principalTable: "Photo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_PhotoAlbum_PhotoAlbumID",
                        column: x => x.PhotoAlbumID,
                        principalSchema: "dbo",
                        principalTable: "PhotoAlbum",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Source_SourceID",
                        column: x => x.SourceID,
                        principalSchema: "dbo",
                        principalTable: "Source",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Category_Event_EventID",
                        column: x => x.EventID,
                        principalSchema: "dbo",
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_EventID",
                schema: "dbo",
                table: "Category",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CoverPhotoID",
                schema: "dbo",
                table: "Event",
                column: "CoverPhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_PhotoAlbumID",
                schema: "dbo",
                table: "Event",
                column: "PhotoAlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_SourceID",
                schema: "dbo",
                table: "Event",
                column: "SourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PhotoAlbumID",
                schema: "dbo",
                table: "Photo",
                column: "PhotoAlbumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Photo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PhotoAlbum",
                schema: "dbo");
        }
    }
}
