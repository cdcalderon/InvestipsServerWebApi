using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investips.Persistence.Migrations
{
    public partial class AddWidgetMultipointShapesToSecurities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecurityId",
                table: "WidgetMultipointShapes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WidgetMultipointShapes_SecurityId",
                table: "WidgetMultipointShapes",
                column: "SecurityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetMultipointShapes_Securities_SecurityId",
                table: "WidgetMultipointShapes",
                column: "SecurityId",
                principalTable: "Securities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetMultipointShapes_Securities_SecurityId",
                table: "WidgetMultipointShapes");

            migrationBuilder.DropIndex(
                name: "IX_WidgetMultipointShapes_SecurityId",
                table: "WidgetMultipointShapes");

            migrationBuilder.DropColumn(
                name: "SecurityId",
                table: "WidgetMultipointShapes");
        }
    }
}
