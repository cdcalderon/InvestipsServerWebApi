using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investips.Persistence.Migrations
{
    public partial class AddWidgetShapeEntityToSecurities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WidgetShapeOverrides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FontSize = table.Column<int>(type: "int", nullable: false),
                    LineColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineWidth = table.Column<int>(type: "int", nullable: false),
                    ShowLabel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetShapeOverrides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShapeDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisableSave = table.Column<bool>(type: "bit", nullable: false),
                    DisableSelection = table.Column<bool>(type: "bit", nullable: false),
                    DisableUndo = table.Column<bool>(type: "bit", nullable: false),
                    Lock = table.Column<bool>(type: "bit", nullable: false),
                    OverridesId = table.Column<int>(type: "int", nullable: true),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZOrder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShapeDefinition_WidgetShapeOverrides_OverridesId",
                        column: x => x.OverridesId,
                        principalTable: "WidgetShapeOverrides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetMultipointShapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShapeDefinitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetMultipointShapes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetMultipointShapes_ShapeDefinition_ShapeDefinitionId",
                        column: x => x.ShapeDefinitionId,
                        principalTable: "ShapeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetShapePoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<long>(type: "bigint", nullable: false),
                    WidgetMultipointShapeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetShapePoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetShapePoint_WidgetMultipointShapes_WidgetMultipointShapeId",
                        column: x => x.WidgetMultipointShapeId,
                        principalTable: "WidgetMultipointShapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetShapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SecurityId = table.Column<int>(type: "int", nullable: true),
                    ShapeDefinitionId = table.Column<int>(type: "int", nullable: true),
                    ShapePointId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetShapes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetShapes_Securities_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Securities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetShapes_ShapeDefinition_ShapeDefinitionId",
                        column: x => x.ShapeDefinitionId,
                        principalTable: "ShapeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetShapes_WidgetShapePoint_ShapePointId",
                        column: x => x.ShapePointId,
                        principalTable: "WidgetShapePoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecurityWidgetShape",
                columns: table => new
                {
                    SecurityId = table.Column<int>(type: "int", nullable: false),
                    WidgetShapeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityWidgetShape", x => new { x.SecurityId, x.WidgetShapeId });
                    table.ForeignKey(
                        name: "FK_SecurityWidgetShape_Securities_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Securities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityWidgetShape_WidgetShapes_WidgetShapeId",
                        column: x => x.WidgetShapeId,
                        principalTable: "WidgetShapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityWidgetShape_WidgetShapeId",
                table: "SecurityWidgetShape",
                column: "WidgetShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShapeDefinition_OverridesId",
                table: "ShapeDefinition",
                column: "OverridesId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetMultipointShapes_ShapeDefinitionId",
                table: "WidgetMultipointShapes",
                column: "ShapeDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapePoint_WidgetMultipointShapeId",
                table: "WidgetShapePoint",
                column: "WidgetMultipointShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapes_SecurityId",
                table: "WidgetShapes",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapes_ShapeDefinitionId",
                table: "WidgetShapes",
                column: "ShapeDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapes_ShapePointId",
                table: "WidgetShapes",
                column: "ShapePointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityWidgetShape");

            migrationBuilder.DropTable(
                name: "WidgetShapes");

            migrationBuilder.DropTable(
                name: "WidgetShapePoint");

            migrationBuilder.DropTable(
                name: "WidgetMultipointShapes");

            migrationBuilder.DropTable(
                name: "ShapeDefinition");

            migrationBuilder.DropTable(
                name: "WidgetShapeOverrides");
        }
    }
}
