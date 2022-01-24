using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReSign.Database.Logic.Migrations
{
    public partial class AddCookieRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayId",
                table: "QRSessionCookie",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsedByDeviceId",
                table: "QRSessionCookie",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QRSessionCookie_DisplayId",
                table: "QRSessionCookie",
                column: "DisplayId");

            migrationBuilder.CreateIndex(
                name: "IX_QRSessionCookie_UsedByDeviceId",
                table: "QRSessionCookie",
                column: "UsedByDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_QRSessionCookie_Device_UsedByDeviceId",
                table: "QRSessionCookie",
                column: "UsedByDeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QRSessionCookie_Display_DisplayId",
                table: "QRSessionCookie",
                column: "DisplayId",
                principalTable: "Display",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QRSessionCookie_Device_UsedByDeviceId",
                table: "QRSessionCookie");

            migrationBuilder.DropForeignKey(
                name: "FK_QRSessionCookie_Display_DisplayId",
                table: "QRSessionCookie");

            migrationBuilder.DropIndex(
                name: "IX_QRSessionCookie_DisplayId",
                table: "QRSessionCookie");

            migrationBuilder.DropIndex(
                name: "IX_QRSessionCookie_UsedByDeviceId",
                table: "QRSessionCookie");

            migrationBuilder.DropColumn(
                name: "DisplayId",
                table: "QRSessionCookie");

            migrationBuilder.DropColumn(
                name: "UsedByDeviceId",
                table: "QRSessionCookie");
        }
    }
}
