    using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuftbornTestApplication.Data.Migrations
{
    public partial class mg7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentHighestBid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaxBidBuyout",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "pictureUrl",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pictureUrl",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentHighestBid",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxBidBuyout",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }
    }
}
