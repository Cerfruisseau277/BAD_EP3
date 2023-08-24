using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94016c50-8d53-4014-a363-7c4b84d4e29b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20a26bc5-0ae9-4eb9-930c-15735f131161", "deb020b6-a957-44fd-9f13-48fe030f2774" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94016c50-8d53-4014-a363-7c4b84d4e29b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6cc47468-35f4-4328-a26c-5b237cd7c033", "5d45a494-c7fc-4395-9bb4-d70f692b1b6d" });
        }
    }
}
