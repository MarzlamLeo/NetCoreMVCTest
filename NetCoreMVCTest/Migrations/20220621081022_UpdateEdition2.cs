using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreMVCTest.Migrations
{
    public partial class UpdateEdition2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Users",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Users");
        }
    }
}
