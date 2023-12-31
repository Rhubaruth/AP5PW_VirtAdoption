﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanaKrizan.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Petcs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Pets",
                type: "varchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldMaxLength: 1)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "InShelterSince" },
                values: new object[] { new DateTime(2023, 12, 15, 13, 1, 40, 127, DateTimeKind.Local).AddTicks(3456), new DateTime(2023, 12, 15, 13, 1, 40, 127, DateTimeKind.Local).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InShelterSince",
                value: new DateTime(2023, 12, 15, 13, 1, 40, 127, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birth", "Sex" },
                values: new object[] { new DateTime(2023, 12, 15, 13, 1, 40, 127, DateTimeKind.Local).AddTicks(3519), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Sex",
                keyValue: null,
                column: "Sex",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Pets",
                type: "varchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldMaxLength: 1,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "InShelterSince" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 33, 27, 43, DateTimeKind.Local).AddTicks(9487), new DateTime(2023, 11, 28, 15, 33, 27, 43, DateTimeKind.Local).AddTicks(9531) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InShelterSince",
                value: new DateTime(2023, 11, 28, 15, 33, 27, 43, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birth", "Sex" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 33, 27, 43, DateTimeKind.Local).AddTicks(9538), " " });
        }
    }
}
