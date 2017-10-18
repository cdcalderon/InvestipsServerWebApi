using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Investips.Persistence.Migrations
{
    public partial class AddUserTradingProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "TradingProfileId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TradingProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradingExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingProfile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TradingProfileId",
                table: "Users",
                column: "TradingProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TradingProfile_TradingProfileId",
                table: "Users",
                column: "TradingProfileId",
                principalTable: "TradingProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TradingProfile_TradingProfileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TradingProfile");

            migrationBuilder.DropIndex(
                name: "IX_Users_TradingProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TradingProfileId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);
        }
    }
}
