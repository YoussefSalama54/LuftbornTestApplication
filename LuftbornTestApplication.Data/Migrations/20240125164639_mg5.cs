using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuftbornTestApplication.Data.Migrations
{
    public partial class mg5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_OwnedByID",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "OwnedByID",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_OwnedByID",
                table: "Products",
                column: "OwnedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_OwnedByID",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "OwnedByID",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_OwnedByID",
                table: "Products",
                column: "OwnedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
