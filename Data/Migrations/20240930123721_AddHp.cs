using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HP",
                table: "Engines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 1,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 2,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 3,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 4,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 5,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 6,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 7,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 8,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 9,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 10,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 11,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 12,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 13,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 14,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 15,
                column: "HP",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 16,
                column: "HP",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HP",
                table: "Engines");
        }
    }
}
