using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aduno.Database.Logic.Migrations
{
    public partial class RenameClassTableAddUniqueName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ClassSet_ClassId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSet",
                table: "ClassSet");

            migrationBuilder.RenameTable(
                name: "ClassSet",
                newName: "Class");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Name",
                table: "Class",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Class_ClassId",
                table: "User",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Class_ClassId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_Name",
                table: "Class");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "ClassSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSet",
                table: "ClassSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ClassSet_ClassId",
                table: "User",
                column: "ClassId",
                principalTable: "ClassSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
