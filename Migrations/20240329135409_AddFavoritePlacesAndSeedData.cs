using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beachcombing_API.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoritePlacesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoritePlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeatherData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TideExtreme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritePlaces_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e3fcf2e-b61e-4940-979b-14dfb1828f61", "AQAAAAIAAYagAAAAEPH/y9bHeplysDs1PvygceOEsMttyPGtkpmBZGKpHgwhXEaPJRecUDuffKHrnYbPlw==" });

            migrationBuilder.InsertData(
                table: "FavoritePlaces",
                columns: new[] { "Id", "City", "Country", "District", "Latitude", "Longitude", "Notes", "TideExtreme", "UserId", "WeatherData" },
                values: new object[] { 1, "Fresno", "United States", "Central California", 36.778300000000002, -119.4179, "Lots of interesting seashells", "Low tide at 5 PM", "1", "Sunny" });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlaces_UserId",
                table: "FavoritePlaces",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritePlaces");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ff23aa2-3c25-48be-96cf-89522c42e8b7", "AQAAAAIAAYagAAAAEA3c91g5ySBaSCzfOM3owBzSaRM4Psfk53o4Qwmlms61rq4BBllNl9BSSCE+MXVCdg==" });
        }
    }
}
