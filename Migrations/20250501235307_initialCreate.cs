using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    YearPublished = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGame_Platform_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PC" },
                    { 2, "Nintendo GameCube" },
                    { 3, "Playstaion 4" }
                });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "Description", "PlatformId", "Price", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, "Young hero sets out to save Hyrule and Princess Zelda", 2, 49.99m, "The Legend of Zelda: Twilight Princess", 2006 },
                    { 2, "Your character accidently interupts a ritual that opens up rifts from another world, causing the world to be invaded by other-world being", 3, 60.00m, "Dragon Age: Inquisition", 2014 },
                    { 3, "Gatcha-Type video game with an open world filled with quests and unlockables", 1, 0.00m, "Genshin Impact", 2020 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_PlatformId",
                table: "VideoGame",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGame");

            migrationBuilder.DropTable(
                name: "Platform");
        }
    }
}
