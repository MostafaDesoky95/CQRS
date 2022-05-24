using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Event_EventID",
                schema: "dbo",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_EventID",
                schema: "dbo",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "EventID",
                schema: "dbo",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "CategoryEvent",
                schema: "dbo",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "int", nullable: false),
                    EventsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEvent", x => new { x.CategoriesID, x.EventsID });
                    table.ForeignKey(
                        name: "FK_CategoryEvent_Category_CategoriesID",
                        column: x => x.CategoriesID,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryEvent_Event_EventsID",
                        column: x => x.EventsID,
                        principalSchema: "dbo",
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEvent_EventsID",
                schema: "dbo",
                table: "CategoryEvent",
                column: "EventsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryEvent",
                schema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                schema: "dbo",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Category_EventID",
                schema: "dbo",
                table: "Category",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Event_EventID",
                schema: "dbo",
                table: "Category",
                column: "EventID",
                principalSchema: "dbo",
                principalTable: "Event",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
