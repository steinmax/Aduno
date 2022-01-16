using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReSign.Database.Logic.Migrations
{
    public partial class DisplayDesignationNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Rooms_CK_Room_Floor",
                table: "Rooms");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Rooms_Floor",
                table: "Rooms",
                sql: "Floor = 'U' or Floor = 'E' or Floor = '1' or Floor = '2'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Rooms_Floor",
                table: "Rooms");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Rooms_CK_Room_Floor",
                table: "Rooms",
                sql: "Floor = 'U' or Floor = 'E' or Floor = '1' or Floor = '2'");
        }
    }
}
