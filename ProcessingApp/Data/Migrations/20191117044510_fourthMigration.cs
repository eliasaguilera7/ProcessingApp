using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessingApp.Data.Migrations
{
    public partial class fourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyDescription",
                table: "PropertyModel",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyDescription",
                table: "PropertyModel");
        }
    }
}
