using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investips.Persistence.Migrations
{
    public partial class RestructureWidgetSecurityRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetShapePoint_WidgetMultipointShapes_WidgetMultipointShapeId",
                table: "WidgetShapePoint");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetShapes_ShapeDefinition_ShapeDefinitionId",
                table: "WidgetShapes");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetShapes_WidgetShapePoint_ShapePointId",
                table: "WidgetShapes");

            migrationBuilder.DropTable(
                name: "SecurityWidgetMultipointShape");

            migrationBuilder.DropTable(
                name: "SecurityWidgetShape");

            migrationBuilder.DropTable(
                name: "WidgetMultipointShapes");

            migrationBuilder.DropTable(
                name: "ShapeDefinition");

            migrationBuilder.DropTable(
                name: "WidgetShapeOverrides");

            migrationBuilder.DropIndex(
                name: "IX_WidgetShapes_ShapeDefinitionId",
                table: "WidgetShapes");

            migrationBuilder.DropIndex(
                name: "IX_WidgetShapes_ShapePointId",
                table: "WidgetShapes");

            migrationBuilder.DropIndex(
                name: "IX_WidgetShapePoint_WidgetMultipointShapeId",
                table: "WidgetShapePoint");

            migrationBuilder.DropColumn(
                name: "ShapeDefinitionId",
                table: "WidgetShapes");

            migrationBuilder.DropColumn(
                name: "ShapePointId",
                table: "WidgetShapes");

            migrationBuilder.DropColumn(
                name: "WidgetMultipointShapeId",
                table: "WidgetShapePoint");

            migrationBuilder.AddColumn<int>(
                name: "SecurityId",
                table: "WidgetShapes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShapeType",
                table: "WidgetShapes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "WidgetShapes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WidgetShapeId",
                table: "WidgetShapePoint",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapes_SecurityId",
                table: "WidgetShapes",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapePoint_WidgetShapeId",
                table: "WidgetShapePoint",
                column: "WidgetShapeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetShapePoint_WidgetShapes_WidgetShapeId",
                table: "WidgetShapePoint",
                column: "WidgetShapeId",
                principalTable: "WidgetShapes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetShapes_Securities_SecurityId",
                table: "WidgetShapes",
                column: "SecurityId",
                principalTable: "Securities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetShapePoint_WidgetShapes_WidgetShapeId",
                table: "WidgetShapePoint");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetShapes_Securities_SecurityId",
                table: "WidgetShapes");

            migrationBuilder.DropIndex(
                name: "IX_WidgetShapes_SecurityId",
                table: "WidgetShapes");

            migrationBuilder.DropIndex(
                name: "IX_WidgetShapePoint_WidgetShapeId",
                table: "WidgetShapePoint");

            migrationBuilder.DropColumn(
                name: "SecurityId",
                table: "WidgetShapes");

            migrationBuilder.DropColumn(
                name: "ShapeType",
                table: "WidgetShapes");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "WidgetShapes");

            migrationBuilder.DropColumn(
                name: "WidgetShapeId",
                table: "WidgetShapePoint");

            migrationBuilder.AddColumn<int>(
                name: "ShapeDefinitionId",
                table: "WidgetShapes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShapePointId",
                table: "WidgetShapes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WidgetMultipointShapeId",
                table: "WidgetShapePoint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SecurityWidgetShape",
                columns: table => new
                {
                    SecurityId = table.Column<int>(nullable: false),
                    WidgetShapeId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "WidgetShapeOverrides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FontSize = table.Column<int>(nullable: false),
                    LineColor = table.Column<string>(nullable: true),
                    LineWidth = table.Column<int>(nullable: false),
                    ShowLabel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetShapeOverrides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShapeDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisableSave = table.Column<bool>(nullable: false),
                    DisableSelection = table.Column<bool>(nullable: false),
                    DisableUndo = table.Column<bool>(nullable: false),
                    Lock = table.Column<bool>(nullable: false),
                    OverridesId = table.Column<int>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    ZOrder = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShapeDefinitionId = table.Column<int>(nullable: true)
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
                name: "SecurityWidgetMultipointShape",
                columns: table => new
                {
                    SecurityId = table.Column<int>(nullable: false),
                    WidgetMultipointShapeId = table.Column<int>(nullable: false)
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
                name: "IX_WidgetShapes_ShapeDefinitionId",
                table: "WidgetShapes",
                column: "ShapeDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapes_ShapePointId",
                table: "WidgetShapes",
                column: "ShapePointId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapePoint_WidgetMultipointShapeId",
                table: "WidgetShapePoint",
                column: "WidgetMultipointShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityWidgetMultipointShape_WidgetMultipointShapeId",
                table: "SecurityWidgetMultipointShape",
                column: "WidgetMultipointShapeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetShapePoint_WidgetMultipointShapes_WidgetMultipointShapeId",
                table: "WidgetShapePoint",
                column: "WidgetMultipointShapeId",
                principalTable: "WidgetMultipointShapes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetShapes_ShapeDefinition_ShapeDefinitionId",
                table: "WidgetShapes",
                column: "ShapeDefinitionId",
                principalTable: "ShapeDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetShapes_WidgetShapePoint_ShapePointId",
                table: "WidgetShapes",
                column: "ShapePointId",
                principalTable: "WidgetShapePoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
