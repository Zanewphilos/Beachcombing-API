using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beachcombing_API.Migrations
{
    /// <inheritdoc />
    public partial class Usermodelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee51c7f0-81c4-4de9-9246-d71b2bf96259", "AQAAAAIAAYagAAAAELha7zxaHNDuB1VlR/UwqaPRUc1yDa18O2Z/o+UI23io5nQ0zrGn2c7pk4TOrC7/6A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8634a882-effd-40e8-a4eb-18db252c6626", "AQAAAAIAAYagAAAAELMhgDe2AJ00jEeaS7HXkpRaPoKVurNtcty1iH8fI1KlkS+QPDNMmSB76Uflxuhu7g==" });
        }
    }
}
