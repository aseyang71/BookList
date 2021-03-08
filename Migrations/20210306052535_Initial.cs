using Microsoft.EntityFrameworkCore.Migrations;

namespace BookList.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BLPs",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    AuthorFirstName = table.Column<string>(nullable: false),
                    AuthorLastName = table.Column<string>(nullable: false),
                    Publisher = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(maxLength: 14, nullable: false),
                    Category1 = table.Column<string>(nullable: false),
                    Category2 = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    PageNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLPs", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BLPs");
        }
    }
}
