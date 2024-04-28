using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beachcombing_API.Migrations
{
    /// <inheritdoc />
    public partial class ApiUpdateandModelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8634a882-effd-40e8-a4eb-18db252c6626", "AQAAAAIAAYagAAAAELMhgDe2AJ00jEeaS7HXkpRaPoKVurNtcty1iH8fI1KlkS+QPDNMmSB76Uflxuhu7g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0282af83-86d5-40c1-b5f3-339d20e9fdfd", "AQAAAAIAAYagAAAAEAJs6hfe6YO+cnTj+bnkqo3ogIjw5oupDBP0yRNsV3A6K1mzaQE4CNbxDnwY1KEpqg==" });
        }
    }
}
