using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanaKrizan.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class isMixed_not_required : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isMixed",
                table: "Breed",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isMixed",
                table: "Breed",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "InShelterSince" },
                values: new object[] { new DateTime(2023, 12, 26, 13, 11, 28, 870, DateTimeKind.Local).AddTicks(7588), new DateTime(2023, 12, 26, 13, 11, 28, 870, DateTimeKind.Local).AddTicks(7648) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InShelterSince",
                value: new DateTime(2023, 12, 26, 13, 11, 28, 870, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 26, 13, 11, 28, 870, DateTimeKind.Local).AddTicks(7657));
        }
    }
}
