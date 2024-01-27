using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuftbornTestApplication.Data.Migrations
{
    public partial class mg6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_OwnedByID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OwnedByID",
                table: "Products",
                newName: "OwnedById");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OwnedByID",
                table: "Products",
                newName: "IX_Products_OwnedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_OwnedById",
                table: "Products",
                column: "OwnedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_OwnedById",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OwnedById",
                table: "Products",
                newName: "OwnedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OwnedById",
                table: "Products",
                newName: "IX_Products_OwnedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_OwnedByID",
                table: "Products",
                column: "OwnedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
