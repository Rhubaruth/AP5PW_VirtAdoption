﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VanaKrizan.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_100_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    Sex = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InShelterSince = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImageSrc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Info = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Birth", "BreedId", "ImageSrc", "InShelterSince", "Info", "Name", "Sex" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 14, 15, 42, 51, 440, DateTimeKind.Local).AddTicks(6027), null, "/img/pets/produkty-01.jpg", new DateTime(2023, 11, 14, 15, 42, 51, 440, DateTimeKind.Local).AddTicks(6072), null, "Doggo", "M" },
                    { 2, null, null, "/img/pets/produkty-02.jpg", new DateTime(2023, 11, 14, 15, 42, 51, 440, DateTimeKind.Local).AddTicks(6079), null, "Oggod", "M" },
                    { 3, new DateTime(2023, 11, 14, 15, 42, 51, 440, DateTimeKind.Local).AddTicks(6082), null, "/img/pets/produkty-03.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kitty", " " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
