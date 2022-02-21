using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReSign.Database.Logic.Migrations
{
    public partial class AddLoginFieldsToUserAndRemoveDeviceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QRToken_Device_UsedByDeviceId",
                table: "QRToken");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropIndex(
                name: "IX_QRToken_UsedByDeviceId",
                table: "QRToken");

            migrationBuilder.DropColumn(
                name: "UsedByDeviceId",
                table: "QRToken");

            migrationBuilder.AddColumn<string>(
                name: "GUID",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GUID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UsedByDeviceId",
                table: "QRToken",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    UniqueId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QRToken_UsedByDeviceId",
                table: "QRToken",
                column: "UsedByDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_UniqueId",
                table: "Device",
                column: "UniqueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Device_UserId",
                table: "Device",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QRToken_Device_UsedByDeviceId",
                table: "QRToken",
                column: "UsedByDeviceId",
                principalTable: "Device",
                principalColumn: "Id");
        }
    }
}
