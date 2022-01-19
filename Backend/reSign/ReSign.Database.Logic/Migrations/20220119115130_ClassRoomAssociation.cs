using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReSign.Database.Logic.Migrations
{
    public partial class ClassRoomAssociation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QRSessionCookies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRSessionCookies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_RoomId",
                table: "Classes",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Rooms_RoomId",
                table: "Classes",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Rooms_RoomId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "QRSessionCookies");

            migrationBuilder.DropIndex(
                name: "IX_Classes_RoomId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Classes");
        }
    }
}
