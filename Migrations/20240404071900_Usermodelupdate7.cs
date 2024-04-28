using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beachcombing_API.Migrations
{
    /// <inheritdoc />
    public partial class Usermodelupdate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "FavoritePlaces");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "FavoritePlaces",
                newName: "Note");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "FavoritePlaces",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf7acb36-5a14-4b83-b1bf-4edf8bb2a39e", "AQAAAAIAAYagAAAAEKoLnG1RDgwwp1oj4EbSPaXgdJdHUz6UE89uX1C8FW73kgKsTtcF5q/Wa+/uxrlV/A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "FavoritePlaces",
                newName: "Notes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FavoritePlaces",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "FavoritePlaces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f33cae2d-e44d-4e47-a517-a94ff156749f", "AQAAAAIAAYagAAAAEHXgaTzj6HIBFPBR3g21eT67yeTmPtpw7mxFxuIKzPvtcGmJ9+nzpnJxlqL1+jLSAA==" });
        }
    }
}
