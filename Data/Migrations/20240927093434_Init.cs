using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Mercedes-Benz" },
                    { 4, "Jaguar" },
                    { 5, "Volkswagen" },
                    { 6, "Mazda" },
                    { 7, "Dodge" },
                    { 8, "Renault" },
                    { 9, "Volvo" },
                    { 10, "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SUV" },
                    { 2, "Coupe" },
                    { 3, "Sedan" },
                    { 4, "Station wagon" },
                    { 5, "Hatchback" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Capacity", "Type" },
                values: new object[,]
                {
                    { 1, 2.0, "Diesel" },
                    { 2, 2.0, "Petrol" },
                    { 3, 3.0, "Diesel" },
                    { 4, 3.0, "Petrol" },
                    { 5, 5.0, "Petrol" },
                    { 6, 2.5, "Petrol" },
                    { 7, 2.5, "Diesel" },
                    { 8, 1.3999999999999999, "Petrol" },
                    { 9, 1.6000000000000001, "Diesel" },
                    { 10, 5.0, "Diesel" },
                    { 11, 2.2000000000000002, "Diesel" },
                    { 12, 2.7000000000000002, "Petrol" },
                    { 13, 1.8, "Petrol" },
                    { 14, 1.8999999999999999, "Diesel" },
                    { 15, 5.5, "Petrol" },
                    { 16, 4.7000000000000002, "Petrol" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "Discount", "EngineId", "ImageUrl", "Model", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, null, 10, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVPmQmyQY3Y5l_OU-xBQ7gGe2TXtKLX5pFPA&s", "Q5", 21000m, 5, new DateTime(2016, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, 2, null, 5, 15, "https://cdn3.riastatic.com/photosnew/auto/photo/mercedes-benz_cls-class__486325818f.jpg", "CLS", 30000m, 2, new DateTime(2013, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 4, null, 15, 6, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqzKVeLR9AsFHMTk35UJYKqspSYu8t1NyjCg&s", "525I", 5500m, 10, new DateTime(2003, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Engines");
        }
    }
}
