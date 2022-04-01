using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteGraphQL.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Inspirational" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Funny" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Dark" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "CategoryId", "Text" },
                values: new object[] { 1, "Dr . Seuss", 1, "You’re off to great places, today is your day. Your mountain is waiting, so get on your way." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "CategoryId", "Text" },
                values: new object[] { 2, "Groucho Marx", 1, "No one is perfect - that’s why pencils have erasers." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "CategoryId", "Text" },
                values: new object[] { 3, "Wolfgang Riebe", 2, "Marriage is the chief cause of divorce." });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CategoryId",
                table: "Quotes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
