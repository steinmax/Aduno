using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReSign.Database.Logic.Migrations
{
    public partial class RenameTimestampTableAddRelationToQRToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timestamp_Room_RoomId",
                table: "Timestamp");

            migrationBuilder.DropForeignKey(
                name: "FK_Timestamp_User_UserId",
                table: "Timestamp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timestamp",
                table: "Timestamp");

            migrationBuilder.RenameTable(
                name: "Timestamp",
                newName: "Interaction");

            migrationBuilder.RenameIndex(
                name: "IX_Timestamp_UserId",
                table: "Interaction",
                newName: "IX_Interaction_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Timestamp_RoomId",
                table: "Interaction",
                newName: "IX_Interaction_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "QRTokenId",
                table: "Interaction",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interaction",
                table: "Interaction",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_QRTokenId",
                table: "Interaction",
                column: "QRTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_QRToken_QRTokenId",
                table: "Interaction",
                column: "QRTokenId",
                principalTable: "QRToken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_Room_RoomId",
                table: "Interaction",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_User_UserId",
                table: "Interaction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_QRToken_QRTokenId",
                table: "Interaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_Room_RoomId",
                table: "Interaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_User_UserId",
                table: "Interaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interaction",
                table: "Interaction");

            migrationBuilder.DropIndex(
                name: "IX_Interaction_QRTokenId",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "QRTokenId",
                table: "Interaction");

            migrationBuilder.RenameTable(
                name: "Interaction",
                newName: "Timestamp");

            migrationBuilder.RenameIndex(
                name: "IX_Interaction_UserId",
                table: "Timestamp",
                newName: "IX_Timestamp_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Interaction_RoomId",
                table: "Timestamp",
                newName: "IX_Timestamp_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timestamp",
                table: "Timestamp",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timestamp_Room_RoomId",
                table: "Timestamp",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timestamp_User_UserId",
                table: "Timestamp",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
