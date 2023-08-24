using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Migratie2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94016c50-8d53-4014-a363-7c4b84d4e29b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e47c3101-ae70-4338-a211-1ab61b6cccda", "204adc0a-b717-4190-8b87-bc82dd84f08b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94016c50-8d53-4014-a363-7c4b84d4e29b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20a26bc5-0ae9-4eb9-930c-15735f131161", "deb020b6-a957-44fd-9f13-48fe030f2774" });
        }
    }
}
