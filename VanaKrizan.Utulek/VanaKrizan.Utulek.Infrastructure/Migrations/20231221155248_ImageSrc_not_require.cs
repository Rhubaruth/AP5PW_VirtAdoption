using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanaKrizan.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageSrc_not_require : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageSrc",
                table: "Pets",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "ImageSrc", "InShelterSince" },
                values: new object[] { new DateTime(2023, 12, 21, 16, 52, 48, 317, DateTimeKind.Local).AddTicks(8837), "/img/pets/peso1.jpg", new DateTime(2023, 12, 21, 16, 52, 48, 317, DateTimeKind.Local).AddTicks(8888) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageSrc", "InShelterSince" },
                values: new object[] { "/img/pets/peso2.jpg", new DateTime(2023, 12, 21, 16, 52, 48, 317, DateTimeKind.Local).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birth", "ImageSrc" },
                values: new object[] { new DateTime(2023, 12, 21, 16, 52, 48, 317, DateTimeKind.Local).AddTicks(8898), "/img/pets/kocka1.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "ImageSrc",
                keyValue: null,
                column: "ImageSrc",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageSrc",
                table: "Pets",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "ImageSrc", "InShelterSince" },
                values: new object[] { new DateTime(2023, 12, 15, 13, 1, 40, 127, DateTimeKind.Local).AddTicks(3456), "/img/pets/produkty-01.jpg", new DateTime(2023, 12, 15, 13, 1, 40, 127, DateTimeKind.Local).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageSrc", "InShelterSince" },
                values: new object[] { "/img/pets/produkty-02.jpg", new DateTime(2023, 12, 15, 13, 1, 40, 127, DateTimeKind.Local).AddTicks(3516) });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birth", "ImageSrc" },
                values: new object[] { new DateTime(2023, 12, 15, 13, 1, 40, 127, DateTimeKind.Local).AddTicks(3519), "/img/pets/produkty-03.jpg" });
        }
    }
}
