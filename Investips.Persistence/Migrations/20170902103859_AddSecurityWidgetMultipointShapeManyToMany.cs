using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investips.Persistence.Migrations
{
    public partial class AddSecurityWidgetMultipointShapeManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityWidgetMultipointShape",
                columns: table => new
                {
                    SecurityId = table.Column<int>(type: "int", nullable: false),
                    WidgetMultipointShapeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityWidgetMultipointShape", x => new { x.SecurityId, x.WidgetMultipointShapeId });
                    table.ForeignKey(
                        name: "FK_SecurityWidgetMultipointShape_Securities_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Securities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityWidgetMultipointShape_WidgetMultipointShapes_WidgetMultipointShapeId",
                        column: x => x.WidgetMultipointShapeId,
                        principalTable: "WidgetMultipointShapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityWidgetMultipointShape_WidgetMultipointShapeId",
                table: "SecurityWidgetMultipointShape",
                column: "WidgetMultipointShapeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityWidgetMultipointShape");
        }
    }
}
