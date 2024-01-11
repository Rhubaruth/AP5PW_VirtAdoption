using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanaKrizan.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Pet_HasChip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasChip",
                table: "Pets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "HasChip", "InShelterSince" },
                values: new object[] { new DateTime(2024, 1, 7, 0, 26, 38, 485, DateTimeKind.Local).AddTicks(9387), false, new DateTime(2024, 1, 7, 0, 26, 38, 485, DateTimeKind.Local).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HasChip", "InShelterSince" },
                values: new object[] { false, new DateTime(2024, 1, 7, 0, 26, 38, 485, DateTimeKind.Local).AddTicks(9453) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birth", "HasChip" },
                values: new object[] { new DateTime(2024, 1, 7, 0, 26, 38, 485, DateTimeKind.Local).AddTicks(9455), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasChip",
                table: "Pets");

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
        }
    }
}
