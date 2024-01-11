using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VanaKrizan.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sizes_Breeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isMixed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "InShelterSince", "SizeId" },
                values: new object[] { new DateTime(2023, 12, 26, 13, 11, 28, 870, DateTimeKind.Local).AddTicks(7588), new DateTime(2023, 12, 26, 13, 11, 28, 870, DateTimeKind.Local).AddTicks(7648), null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InShelterSince", "SizeId" },
                values: new object[] { new DateTime(2023, 12, 26, 13, 11, 28, 870, DateTimeKind.Local).AddTicks(7654), null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birth", "SizeId" },
                values: new object[] { new DateTime(2023, 12, 26, 13, 11, 28, 870, DateTimeKind.Local).AddTicks(7657), null });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -1, "Nezadáno" },
                    { 1, "malá" },
                    { 2, "střední" },
                    { 3, "velká" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "InShelterSince" },
                values: new object[] { new DateTime(2023, 12, 21, 16, 52, 48, 317, DateTimeKind.Local).AddTicks(8837), new DateTime(2023, 12, 21, 16, 52, 48, 317, DateTimeKind.Local).AddTicks(8888) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InShelterSince",
                value: new DateTime(2023, 12, 21, 16, 52, 48, 317, DateTimeKind.Local).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 21, 16, 52, 48, 317, DateTimeKind.Local).AddTicks(8898));
        }
    }
}
