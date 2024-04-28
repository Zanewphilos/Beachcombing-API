using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beachcombing_API.Migrations
{
    /// <inheritdoc />
    public partial class Usermodelupdate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeatherData",
                table: "FavoritePlaces");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "FavoritePlaces",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "FavoritePlaces",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f33cae2d-e44d-4e47-a517-a94ff156749f", "AQAAAAIAAYagAAAAEHXgaTzj6HIBFPBR3g21eT67yeTmPtpw7mxFxuIKzPvtcGmJ9+nzpnJxlqL1+jLSAA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "FavoritePlaces",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "FavoritePlaces",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "WeatherData",
                table: "FavoritePlaces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "058df708-c9a8-4470-88b4-bfe753ae3f61", "AQAAAAIAAYagAAAAEMNhIQm1g0QDY8eA6nefiMxwkFrfrHcFwrBhmSwwJtfQmFFkIQr/+rRFbocLUqLWlQ==" });
        }
    }
}
