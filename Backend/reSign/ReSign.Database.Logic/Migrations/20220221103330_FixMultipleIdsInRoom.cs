using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReSign.Database.Logic.Migrations
{
    public partial class FixMultipleIdsInRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Organisation_OrganisationId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "OranisationId",
                table: "Room");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Organisation_OrganisationId",
                table: "Room",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Organisation_OrganisationId",
                table: "Room");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Room",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "OranisationId",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Organisation_OrganisationId",
                table: "Room",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id");
        }
    }
}
