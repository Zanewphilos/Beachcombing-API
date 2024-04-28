using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beachcombing_API.Migrations
{
    /// <inheritdoc />
    public partial class Usermodelupdate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aaab7346-1007-46ff-a447-053c1c1ce0f3", "AQAAAAIAAYagAAAAEP5EuALsGJumkzRHwHpP2NIMW8ziMpkOp+y7mAKJxuw664my3tW3+k2e1tUlAzHVvQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf7acb36-5a14-4b83-b1bf-4edf8bb2a39e", "AQAAAAIAAYagAAAAEKoLnG1RDgwwp1oj4EbSPaXgdJdHUz6UE89uX1C8FW73kgKsTtcF5q/Wa+/uxrlV/A==" });
        }
    }
}
