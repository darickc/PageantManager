using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PageantManager.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumes",
                columns: table => new
                {
                    CostumeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumes", x => x.CostumeId);
                });

            migrationBuilder.CreateTable(
                name: "GarmentTypes",
                columns: table => new
                {
                    GarmentTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 75, nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentTypes", x => x.GarmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementTypes",
                columns: table => new
                {
                    MeasurementTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypes", x => x.MeasurementTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CostumeGarments",
                columns: table => new
                {
                    CostumeGarmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CostumeId = table.Column<int>(nullable: false),
                    GarmentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostumeGarments", x => x.CostumeGarmentId);
                    table.ForeignKey(
                        name: "FK_CostumeGarments_Costumes_CostumeId",
                        column: x => x.CostumeId,
                        principalTable: "Costumes",
                        principalColumn: "CostumeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostumeGarments_GarmentTypes_GarmentTypeId",
                        column: x => x.GarmentTypeId,
                        principalTable: "GarmentTypes",
                        principalColumn: "GarmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garments",
                columns: table => new
                {
                    GarmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    CheckedOut = table.Column<bool>(nullable: false),
                    GarmentTypeId = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    PhotoName = table.Column<string>(nullable: true),
                    RetiredDate = table.Column<DateTime>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "GarmentMeasurementTypes",
                columns: table => new
                {
                    GarmentMeasurementTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GarmentTypeId = table.Column<int>(nullable: false),
                    MeasurementTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentMeasurementTypes", x => x.GarmentMeasurementTypeId);
                    table.ForeignKey(
                        name: "FK_GarmentMeasurementTypes_GarmentTypes_GarmentTypeId",
                        column: x => x.GarmentTypeId,
                        principalTable: "GarmentTypes",
                        principalColumn: "GarmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarmentMeasurementTypes_MeasurementTypes_MeasurementTypeId",
                        column: x => x.MeasurementTypeId,
                        principalTable: "MeasurementTypes",
                        principalColumn: "MeasurementTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarmentMeasurements",
                columns: table => new
                {
                    GarmentMeasurementId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GarmentId = table.Column<int>(nullable: false),
                    Max = table.Column<float>(nullable: false),
                    MeasurementTypeId = table.Column<int>(nullable: false),
                    Min = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentMeasurements", x => x.GarmentMeasurementId);
                    table.ForeignKey(
                        name: "FK_GarmentMeasurements_Garments_GarmentId",
                        column: x => x.GarmentId,
                        principalTable: "Garments",
                        principalColumn: "GarmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarmentMeasurements_MeasurementTypes_MeasurementTypeId",
                        column: x => x.MeasurementTypeId,
                        principalTable: "MeasurementTypes",
                        principalColumn: "MeasurementTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostumeGarments_CostumeId",
                table: "CostumeGarments",
                column: "CostumeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostumeGarments_GarmentTypeId",
                table: "CostumeGarments",
                column: "GarmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentMeasurements_GarmentId",
                table: "GarmentMeasurements",
                column: "GarmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentMeasurements_MeasurementTypeId",
                table: "GarmentMeasurements",
                column: "MeasurementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentMeasurementTypes_GarmentTypeId",
                table: "GarmentMeasurementTypes",
                column: "GarmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentMeasurementTypes_MeasurementTypeId",
                table: "GarmentMeasurementTypes",
                column: "MeasurementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Garments_GarmentTypeId",
                table: "Garments",
                column: "GarmentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostumeGarments");

            migrationBuilder.DropTable(
                name: "GarmentMeasurements");

            migrationBuilder.DropTable(
                name: "GarmentMeasurementTypes");

            migrationBuilder.DropTable(
                name: "Costumes");

            migrationBuilder.DropTable(
                name: "Garments");

            migrationBuilder.DropTable(
                name: "MeasurementTypes");

            migrationBuilder.DropTable(
                name: "GarmentTypes");
        }
    }
}
