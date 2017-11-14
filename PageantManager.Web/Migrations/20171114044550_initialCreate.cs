using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PageantManager.Web.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumes",
                columns: table => new
                {
                    CostumeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    PageantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumes", x => x.CostumeId);
                });

            migrationBuilder.CreateTable(
                name: "Pageants",
                columns: table => new
                {
                    PageantId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pageants", x => x.PageantId);
                });

            migrationBuilder.CreateTable(
                name: "GarmentTypes",
                columns: table => new
                {
                    GarmentTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CostumeId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 75, nullable: true),
                    PageantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentTypes", x => x.GarmentTypeId);
                    table.ForeignKey(
                        name: "FK_GarmentTypes_Costumes_CostumeId",
                        column: x => x.CostumeId,
                        principalTable: "Costumes",
                        principalColumn: "CostumeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    PerformanceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApplicationStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PageantId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.PerformanceId);
                    table.ForeignKey(
                        name: "FK_Performances_Pageants_PageantId",
                        column: x => x.PageantId,
                        principalTable: "Pageants",
                        principalColumn: "PageantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garments",
                columns: table => new
                {
                    GarmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChestMax = table.Column<decimal>(type: "TEXT", nullable: true),
                    ChestMin = table.Column<decimal>(type: "TEXT", nullable: true),
                    GarmentTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    HeadMax = table.Column<decimal>(type: "TEXT", nullable: true),
                    HeadMin = table.Column<decimal>(type: "TEXT", nullable: true),
                    InseamMax = table.Column<decimal>(type: "TEXT", nullable: true),
                    InseamMin = table.Column<decimal>(type: "TEXT", nullable: true),
                    RetiredDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    WaistMax = table.Column<decimal>(type: "TEXT", nullable: true),
                    WaistMin = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garments", x => x.GarmentId);
                    table.ForeignKey(
                        name: "FK_Garments_GarmentTypes_GarmentTypeId",
                        column: x => x.GarmentTypeId,
                        principalTable: "GarmentTypes",
                        principalColumn: "GarmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garments_GarmentTypeId",
                table: "Garments",
                column: "GarmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentTypes_CostumeId",
                table: "GarmentTypes",
                column: "CostumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_PageantId",
                table: "Performances",
                column: "PageantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garments");

            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "GarmentTypes");

            migrationBuilder.DropTable(
                name: "Pageants");

            migrationBuilder.DropTable(
                name: "Costumes");
        }
    }
}
