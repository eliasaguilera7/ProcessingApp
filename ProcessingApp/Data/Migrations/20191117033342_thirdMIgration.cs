using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessingApp.Data.Migrations
{
    public partial class thirdMIgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "PropertyModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PropertyModel");
        }
    }
}
