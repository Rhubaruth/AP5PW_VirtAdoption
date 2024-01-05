using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VanaKrizan.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserHasPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserHasPet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHasPet", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "InShelterSince" },
                values: new object[] { new DateTime(2023, 12, 27, 12, 56, 3, 611, DateTimeKind.Local).AddTicks(1776), new DateTime(2023, 12, 27, 12, 56, 3, 611, DateTimeKind.Local).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InShelterSince",
                value: new DateTime(2023, 12, 27, 12, 56, 3, 611, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 27, 12, 56, 3, 611, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.InsertData(
                table: "UserHasPet",
                columns: new[] { "Id", "PetId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHasPet");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "InShelterSince" },
                values: new object[] { new DateTime(2023, 12, 26, 14, 8, 27, 673, DateTimeKind.Local).AddTicks(1634), new DateTime(2023, 12, 26, 14, 8, 27, 673, DateTimeKind.Local).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InShelterSince",
                value: new DateTime(2023, 12, 26, 14, 8, 27, 673, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 26, 14, 8, 27, 673, DateTimeKind.Local).AddTicks(1702));
        }
    }
}
