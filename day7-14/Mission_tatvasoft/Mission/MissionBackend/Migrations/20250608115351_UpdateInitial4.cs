﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MissionBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MissionTitle = table.Column<string>(type: "text", nullable: false),
                    MissionDescription = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalSheets = table.Column<int>(type: "integer", nullable: true),
                    RegistrationDeadLine = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MissionThemeId = table.Column<int>(type: "integer", nullable: false),
                    MissionSkillId = table.Column<string>(type: "text", nullable: false),
                    MissionImages = table.Column<string>(type: "text", nullable: false),
                    MissionSkill = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mission_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mission_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mission_MissionTheme_MissionThemeId",
                        column: x => x.MissionThemeId,
                        principalTable: "MissionTheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName", "CountryId" },
                values: new object[,]
                {
                    { 1, "Ahmedabad", 1 },
                    { 2, "Rajkot", 1 },
                    { 3, "Surat", 1 },
                    { 4, "Jamnagar", 1 },
                    { 5, "New York", 2 },
                    { 6, "California", 2 },
                    { 7, "Texas", 2 },
                    { 8, "London", 3 },
                    { 9, "Manchester", 3 },
                    { 10, "Birmingham", 3 },
                    { 11, "Moscow", 4 },
                    { 12, "Saint Petersburg", 4 },
                    { 13, "Yekaterinburg", 4 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryName" },
                values: new object[,]
                {
                    { 1, "India" },
                    { 2, "USA" },
                    { 3, "UK" },
                    { 4, "Russia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mission_CityId",
                table: "Mission",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_CountryId",
                table: "Mission",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_MissionThemeId",
                table: "Mission",
                column: "MissionThemeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
