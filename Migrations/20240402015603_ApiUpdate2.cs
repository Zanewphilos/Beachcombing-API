using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beachcombing_API.Migrations
{
    /// <inheritdoc />
    public partial class ApiUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FavoritePlaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "TideExtreme",
                table: "FavoritePlaces",
                newName: "TideData");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FavoritePlaces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "FavoritePlaces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "FavoritePlaces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "AvatarUrl", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "https://beachcombingstorage.blob.core.windows.net/useravatar/user1.jpg", "0282af83-86d5-40c1-b5f3-339d20e9fdfd", "AQAAAAIAAYagAAAAEAJs6hfe6YO+cnTj+bnkqo3ogIjw5oupDBP0yRNsV3A6K1mzaQE4CNbxDnwY1KEpqg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "FavoritePlaces");

            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "FavoritePlaces");

            migrationBuilder.DropColumn(
                name: "State",
                table: "FavoritePlaces");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TideData",
                table: "FavoritePlaces",
                newName: "TideExtreme");

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
        }
    }
}
