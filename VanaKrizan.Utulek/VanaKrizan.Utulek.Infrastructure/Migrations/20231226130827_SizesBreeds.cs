using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanaKrizan.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SizesBreeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breed",
                table: "Breed");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "Breed",
                newName: "Breeds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "Breeds",
                newName: "Breed");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breed",
                table: "Breed",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "InShelterSince" },
                values: new object[] { new DateTime(2023, 12, 26, 13, 12, 56, 119, DateTimeKind.Local).AddTicks(4371), new DateTime(2023, 12, 26, 13, 12, 56, 119, DateTimeKind.Local).AddTicks(4422) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InShelterSince",
                value: new DateTime(2023, 12, 26, 13, 12, 56, 119, DateTimeKind.Local).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 26, 13, 12, 56, 119, DateTimeKind.Local).AddTicks(4430));
        }
    }
}
