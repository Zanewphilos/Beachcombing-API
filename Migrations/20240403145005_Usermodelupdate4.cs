using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beachcombing_API.Migrations
{
    /// <inheritdoc />
    public partial class Usermodelupdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SelfIntro",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CleanupRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrashItemCountsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleanupRecords", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "058df708-c9a8-4470-88b4-bfe753ae3f61", "AQAAAAIAAYagAAAAEMNhIQm1g0QDY8eA6nefiMxwkFrfrHcFwrBhmSwwJtfQmFFkIQr/+rRFbocLUqLWlQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleanupRecords");

            migrationBuilder.AlterColumn<string>(
                name: "SelfIntro",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2553450-c499-4242-aef4-36d5cd25afed", "AQAAAAIAAYagAAAAEJy0s8ONUAoGAglKjku+xxqoPHYf9OTRAoBteLDZK+itz74xmu6yFrZPzmSX7bxdZg==" });
        }
    }
}
