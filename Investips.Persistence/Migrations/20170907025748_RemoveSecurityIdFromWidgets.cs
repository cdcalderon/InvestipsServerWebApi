using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investips.Persistence.Migrations
{
    public partial class RemoveSecurityIdFromWidgets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetMultipointShapes_Securities_SecurityId",
                table: "WidgetMultipointShapes");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetShapes_Securities_SecurityId",
                table: "WidgetShapes");

            migrationBuilder.DropIndex(
                name: "IX_WidgetShapes_SecurityId",
                table: "WidgetShapes");

            migrationBuilder.DropIndex(
                name: "IX_WidgetMultipointShapes_SecurityId",
                table: "WidgetMultipointShapes");

            migrationBuilder.DropColumn(
                name: "SecurityId",
                table: "WidgetShapes");

            migrationBuilder.DropColumn(
                name: "SecurityId",
                table: "WidgetMultipointShapes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecurityId",
                table: "WidgetShapes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityId",
                table: "WidgetMultipointShapes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WidgetShapes_SecurityId",
                table: "WidgetShapes",
                column: "SecurityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetShapes_Securities_SecurityId",
                table: "WidgetShapes",
                column: "SecurityId",
                principalTable: "Securities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
